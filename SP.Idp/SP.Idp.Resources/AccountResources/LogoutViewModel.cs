using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Idp.Resources.AccountResources
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
