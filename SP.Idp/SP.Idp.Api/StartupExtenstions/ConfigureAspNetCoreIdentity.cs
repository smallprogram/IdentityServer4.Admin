using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SP.Idp.Core.IdentityCore.IdentityContext;
using SP.Idp.Core.IdentityCore.IdentityModels.Entites;
using System;
using System.Reflection;

namespace SP.Idp.Api.StartupExtenstions
{
    public static class ConfigureAspNetCoreIdentity
    {
        public static void SP_ConfigureAspNetCoreIdentity(this IServiceCollection services,string ConnectionsString)
        {
            //获取AspNetCore Identity程序集
            var AspNetCoreIdentityMigrationsAssembly = typeof(IdentityCoreContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<IdentityCoreContext>(options =>
                options.UseSqlServer(ConnectionsString, sql => sql.MigrationsAssembly(AspNetCoreIdentityMigrationsAssembly)));

            services.AddIdentity<IdpUser, IdpRole>()
                .AddEntityFrameworkStores<IdentityCoreContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }
    }
}
