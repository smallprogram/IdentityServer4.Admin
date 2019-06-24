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
            //获取AuthorizationURI中得参数保存至AuthorizationRequest实体上
            var context = await identityServerInteractionService.GetAuthorizationContextAsync(returnUrl);
            //如果AuthorizationRequest包好IDP信息，则为外部IDP，如果没有，则为本地IDP
            if (context?.IdP != null)
            {
                //判断是否是使用本地idp
                var local = context.IdP == IdentityServer4.IdentityServerConstants.LocalIdentityProvider;

                // this is meant to short circuit the UI and only trigger the one external IdP
                // 触发一个外部IdP
                var vm = new LoginViewModel
                {
                    //设置Login不使用本地IDP
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
            //获取所有认证方案
            var schemes = await schemeProvider.GetAllSchemesAsync();
            //获取所有外部idp
            var providers = schemes
                .Where(x => x.DisplayName != null ||
                            (x.Name.Equals(AccountOptions.WindowsAuthenticationSchemeName, StringComparison.OrdinalIgnoreCase))
                )
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                }).ToList();

            //允许本地认证
            var allowLocal = true;
            if (context?.ClientId != null)
            {
                //通过Request的ClientId从IDP中检索目前启用状态的Client配置，并返回Client实例
                var client = await clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    //获取该客户端是否允许本地登录
                    allowLocal = client.EnableLocalLogin;

                    //判断，是否配置了可以与客户端一起使用的外部Idp，如果为IdentityProviderRestrictions为空，则允许所有idp，该值默认为null
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