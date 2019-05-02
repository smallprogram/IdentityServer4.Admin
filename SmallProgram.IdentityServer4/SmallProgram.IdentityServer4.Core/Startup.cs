using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmallProgram.IdentityServer4.Core
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment environment,IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
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
                 policy.WithOrigins("http://localhost:4200")
                 .WithExposedHeaders("X-Pagination") //允许自定义header
                 .AllowAnyHeader()
                 .AllowAnyMethod());
            });

            //配置IdentityServer4
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();

        }
    }
}
