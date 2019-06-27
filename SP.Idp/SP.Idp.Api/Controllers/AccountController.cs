using IdentityModel;
using IdentityServer4.Extensions;
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

namespace SP.Idp.Api.Controllers
{
    [SecurityHeaders]
    [AllowAnonymous]
    //[Route("api/Account")]
    //[ApiController]
    public class AccountController : Controller
    {
        private readonly IIdentityServerInteractionService _IdentityServerInteractionService;
        private readonly IClientStore _ClientStore;
        private readonly IAuthenticationSchemeProvider _SchemeProvider;
        private readonly IEventService _EventService;
        private readonly UserManager<IdpUser> _UserManager;
        private readonly SignInManager<IdpUser> _SignInManager;

        public AccountController(
            IIdentityServerInteractionService identityServerInteractionService,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider,
            IEventService eventService,
            UserManager<IdpUser> userManager,
            SignInManager<IdpUser> signInManager
            
            )
        {
            _IdentityServerInteractionService = identityServerInteractionService;
            _ClientStore = clientStore;
            _SchemeProvider = schemeProvider;
            _EventService = eventService;
            _UserManager = userManager;
            _SignInManager = signInManager;
        }

        // <summary>
        // 进入登录工作流程的入口点
        // </summary>
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            // 建立一个模型，以便我们知道在登录页面上显示什么
            var vm = await BuildLoginViewModelAsync(returnUrl);

            //如果是外部idp登录
            if (vm.IsExternalLoginOnly)
            {
                // 我们只有一个登录选项，它是一个外部提供商
                return RedirectToAction("Challenge", "External", new { provider = vm.ExternalLoginScheme, returnUrl });
            }

            return View(vm);
        }



        #region 帮助方法

        /// <summary>
        /// 生成登录试图模型
        /// </summary>
        /// <param name="returnUrl">跳转回的客户端uri</param>
        /// <returns>LoginViewModel</returns>
        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            //获取AuthorizationURI中得参数保存至AuthorizationRequest实体上
            var context = await _IdentityServerInteractionService.GetAuthorizationContextAsync(returnUrl);
            //如果AuthorizationRequest包好IDP信息，则为外部IDP，如果没有，则为本地IDP
            if (context?.IdP != null)
            {
                // this is meant to short circuit the UI and only trigger the one external IdP
                // 触发一个外部IdP
                return new LoginViewModel
                {
                    EnableLocalLogin = false,
                    ReturnUrl = returnUrl,
                    Username = context?.LoginHint,
                    ExternalProviders = new ExternalProvider[] { new ExternalProvider { AuthenticationScheme = context.IdP } }
                };
            }
            //获取所有认证方案
            var schemes = await _SchemeProvider.GetAllSchemesAsync();

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
                var client = await _ClientStore.FindEnabledClientByIdAsync(context.ClientId);
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

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginInputModel model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            vm.RememberLogin = model.RememberLogin;
            return vm;
        }

        private async Task<LogoutViewModel> BuildLogoutViewModelAsync(string logoutId)
        {
            var vm = new LogoutViewModel { LogoutId = logoutId, ShowLogoutPrompt = AccountOptions.ShowLogoutPrompt };

            if (User?.Identity.IsAuthenticated != true)
            {
                // 如果用户没有认证则直接显示登出UI
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            var context = await _IdentityServerInteractionService.GetLogoutContextAsync(logoutId);
            if (context?.ShowSignoutPrompt == false)
            {
                // 自动注销是安全的
                vm.ShowLogoutPrompt = false;
                return vm;
            }

            // 显示注销提示。 这可以防止用户攻击
            // 由另一个恶意网页自动注销。
            return vm;
        }


        private async Task<LoggedOutViewModel> BuildLoggedOutViewModelAsync(string logoutId)
        {
            // 获取上下文信息（联合注销的客户端名称，发布注销重定向URI和iframe）
            var logout = await _IdentityServerInteractionService.GetLogoutContextAsync(logoutId);

            var vm = new LoggedOutViewModel
            {
                AutomaticRedirectAfterSignOut = AccountOptions.AutomaticRedirectAfterSignOut,
                PostLogoutRedirectUri = logout?.PostLogoutRedirectUri,
                ClientName = string.IsNullOrEmpty(logout?.ClientName) ? logout?.ClientId : logout?.ClientName,
                SignOutIframeUrl = logout?.SignOutIFrameUrl,
                LogoutId = logoutId
            };

            if (User?.Identity.IsAuthenticated == true)
            {
                var idp = User.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
                if (idp != null && idp != IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await HttpContext.GetSchemeSupportsSignOutAsync(idp);
                    if (providerSupportsSignout)
                    {
                        if (vm.LogoutId == null)
                        {
                            // 如果没有当前的注销上下文，我们需要创建一个
                            // 这会捕获当前登录用户的必要信息
                            // 在我们退出并重定向到外部IdP以进行注销之前
                            vm.LogoutId = await _IdentityServerInteractionService.CreateLogoutContextAsync();
                        }

                        vm.ExternalAuthenticationScheme = idp;
                    }
                }
            }

            return vm;
        }


        #endregion
    }
}