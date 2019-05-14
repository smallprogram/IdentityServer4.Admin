using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Idp.Resources.AccountResources
{
    public class AccountOptions
    {
        public static bool AllowLocalLogin = true;
        public static bool AllowRememberLogin = true;
        //记住登录的持续时间
        public static TimeSpan RememberMeLoginDuration = TimeSpan.FromDays(30);
        //是否显示登出页面
        public static bool ShowLogoutPrompt = true;
        //注销后是否自动重定向
        public static bool AutomaticRedirectAfterSignOut = false;

        // 指定正在使用的Windows身份验证方案
        public static readonly string WindowsAuthenticationSchemeName = Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme;
        // 如果用户使用windows auth，我们是否应该从windows加载组
        public static bool IncludeWindowsGroups = false;
        
        //无效凭据的错误信息
        public static string InvalidCredentialsErrorMessage = "错误的用户名和密码";
    }
}
