using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Idp.Core.IdentityCore.IdentityModels.Entites
{
    public class IdpUser : IdentityUser<Guid>
    {
        public virtual ICollection<IdpUserClaim> Claims { get; set; }
        public virtual ICollection<IdpUserLogin> Logins { get; set; }
        public virtual ICollection<IdpUserToken> Tokens { get; set; }
        public virtual ICollection<IdpUserRole> UserRoles { get; set; }
    }
}
