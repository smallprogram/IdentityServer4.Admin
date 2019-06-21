using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SP.Idp.Core.IdentityCore.IdentityContext;
using SP.Idp.Core.IdentityCore.IdentityModels.Entites;
using System;
using System.Reflection;

namespace SP.Idp.Api.StartupExtenstions
{
    public static class StartupServicesExtenstionMethod
    {
        /// <summary>
        /// 基础配置扩展方法
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration">IConfiguration 实例</param>
        public static void SP_ConfigureBase(this IServiceCollection services, IConfiguration Configuration)
        {
            //设置MVC框架为Asp.net Core 2.2
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2);

            //配置IIS认证方式
            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });


            //https支持
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                // options.ExcludedHosts.Add("example.com");
                // options.ExcludedHosts.Add("www.example.com");
            });


            //配置允许跨域请求
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDevOrigin", policy =>
                 policy.WithOrigins(Configuration["CorsUrl:ClientUrl_1"])
                 .WithExposedHeaders("X-Pagination") //允许自定义header
                 .AllowAnyHeader()
                 .AllowAnyMethod());
            });
        }

        /// <summary>
        /// Asp.Net Core Identity配置扩展方法
        /// </summary>
        /// <param name="services"></param>
        /// <param name="ConnectionsString">MSSQL链接字符串</param>
        public static void SP_ConfigureAspNetCoreIdentity(this IServiceCollection services, string ConnectionsString)
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

        /// <summary>
        /// IdentityServer4配置扩展方法
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Environment">IHostingEnvironment 实例</param>
        /// <param name="ConnectionsString">MSSQL链接字符串</param>
        public static void SP_ConfigureIdentityServer4(this IServiceCollection services, IHostingEnvironment Environment, string ConnectionsString)
        {
            var ConfigureDbMigrationsAssembly = typeof(IdpConfigurationDbContext).GetTypeInfo().Assembly.GetName().Name;
            var PersistedGrantDbMigrationsAssembly = typeof(IdpPersistedGrantDbContext).GetTypeInfo().Assembly.GetName().Name;
            //配置IdentityServer4
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })

            //.AddTestUsers()
            //使用Asp.net core identity作为用户管理
            .AddAspNetIdentity<IdpUser>()

            //配置IdentityServer的配置数据持久化，（clients,resources）
            //使用扩展的DbContext进行配置
            .AddConfigurationStore<IdpConfigurationDbContext>(options =>
            {

                options.ConfigureDbContext = b =>
                b.UseSqlServer(ConnectionsString, sql => sql.MigrationsAssembly(ConfigureDbMigrationsAssembly));
            })

            //配置IdentityServer的运营数据持久化，（codes,tokens,consents)
            //使用扩展的DbContext进行配置
            .AddOperationalStore<IdpPersistedGrantDbContext>(options =>
            {
                options.ConfigureDbContext = b =>
                b.UseSqlServer(ConnectionsString, sql => sql.MigrationsAssembly(PersistedGrantDbMigrationsAssembly));

                //自动清除token，可选配置
                options.EnableTokenCleanup = true;
            });

            //配置IdentityServer4的证书
            if (Environment.IsDevelopment())
            {
                //临时证书
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                //生产证书
                throw new Exception("need to configure key material");
                //builder.AddSigningCredential("key");
                //builder.AddValidationKey("key");
            }
        }
    }
}
