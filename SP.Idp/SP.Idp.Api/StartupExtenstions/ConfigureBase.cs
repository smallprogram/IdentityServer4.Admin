using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SP.Idp.Api.StartupExtenstions
{
    public static class ConfigureBase
    {
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
    }
}
