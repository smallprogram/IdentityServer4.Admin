using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Idp.Resources.AccountResources
{
    public class ExternalProvider
    {
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 认证方案
        /// </summary>
        public string AuthenticationScheme { get; set; }
    }
}
