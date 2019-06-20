using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SP.Idp.Core.IdentityCore.IdentityContext;
using SP.Idp.Core.IdentityCore.IdentityModels.Entites;
using System;
using System.Reflection;

namespace SP.Idp.Api.StartupExtenstions
{
    public static class ConfigureIdentityServer4
    {
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
