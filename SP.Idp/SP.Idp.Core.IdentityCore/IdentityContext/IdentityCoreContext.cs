using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SP.Idp.Core.IdentityCore.IdentityModels.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace SP.Idp.Core.IdentityCore.IdentityContext
{
    public class IdentityCoreContext :
        IdentityDbContext<IdpUser, IdpRole, Guid, IdpUserClaim, IdpUserRole, IdpUserLogin, IdpRoleClaim, IdpUserToken>
    {
        public IdentityCoreContext(DbContextOptions<IdentityCoreContext> options) : base(options)
        {

        }
    }
}
