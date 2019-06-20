using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SP.Idp.Core.IdentityCore.IdentityModels.Entites;
using SP.Idp.Resources.AccountResources;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Idp.Api.Controller
{
    [SecurityHeaders]
    [AllowAnonymous]
    //[Route("api/Account")]
    //[ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityServerInteractionService identityServerInteractionService;
        private readonly IClientStore clientStore;
        private readonly IAuthenticationSchemeProvider schemeProvider;
        private readonly IEventService eventService;
        private readonly UserManager<IdpUser> userManager;
        private readonly SignInManager<IdpUser> signInManager;

        public AccountController(
            IIdentityServerInteractionService identityServerInteractionService,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService eventService,
            UserManager<IdpUser> userManager,
            SignInManager<IdpUser> signInManager
            
            )
        {
            this.identityServerInteractionService = identityServerInteractionService;
            this.clientStore = clientStore;
            this.schemeProvider = schemeProvider;
            this.eventService = eventService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        #region 帮助方法
        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await identityServerInteractionService.GetAuthorizationContextAsync(returnUrl);
            if (context?.IdP != null)
            {
                var local = context.IdP == IdentityServer4.IdentityServerConstants.LocalIdentityProvider;

                // this is meant to short circuit the UI and only trigger the one external IdP
                var vm = new LoginViewModel
                {
                    EnableLocalLogin = local,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                };

                if (!local)
                {
                    vm.ExternalProviders = new[] { new ExternalProvider { AuthenticationScheme = context.IdP } };
                }

                return vm;
            }

            var schemes = await schemeProvider.GetAllSchemesAsync();

            var providers = schemes
                .Where(x => x.DisplayName != null ||
                            (x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                )
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                }).ToList();

            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme)).ToList();
                    }
                }
            }

            return new LoginViewModel
            {
                AllowRememberLogin = AccountOptions.AllowRememberLogin,
                EnableLocalLogin = allowLocal && AccountOptions.AllowLocalLogin,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint,
                ExternalProviders = providers.ToArray()
            };
        }
        #endregion
    }
}