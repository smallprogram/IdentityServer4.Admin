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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdpUser>(b =>
            {
                b.ToTable("Identity_Users");
            });
            builder.Entity<IdpUserClaim>(b =>
            {
                b.ToTable("Identity_UserClaims");
            });
            builder.Entity<IdpUserLogin>(b =>
            {
                b.ToTable("Identity_UserLogins");
            });
            builder.Entity<IdpUserRole>(b =>
            {
                b.ToTable("Identity_UsersRoles");
            });
            builder.Entity<IdpRole>(b =>
            {
                b.ToTable("Identity_Roles");
            });
            builder.Entity<IdpRoleClaim>(b =>
            {
                b.ToTable("Identity_RoleClaims");
            });
            builder.Entity<IdpUserToken>(b =>
            {
                b.ToTable("Identity_UserTokens");
            });
        }
    }
}
