using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SP.Idp.Api.StartupExtenstions;

namespace SP.Idp.Api
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            // 链接字符串配置
            var MachineName = System.Environment.MachineName;
            var ConnectionsString = "";
            if (MachineName == "CGYYPC") //如果时单位机器
            {
                ConnectionsString = Configuration.GetConnectionString("CgyyConnection");
                //ConnectionsString = configuration["ConnectionStrings:CgyyConnection"];
            }
            else
            {
                ConnectionsString = Configuration.GetConnectionString("HomeConnection");
                //ConnectionsString = configuration["ConnectionStrings:HomeConnection"];
            }

            // 基础配置
            services.SP_ConfigureBase(Configuration);

            // 配置Asp.net Core Identity
            services.SP_ConfigureAspNetCoreIdentity(ConnectionsString);

            // 配置IdentityServer4
            services.SP_ConfigureIdentityServer4(Environment, ConnectionsString);

            #region DI(依赖注入) 配置

            services.SP_DI();

            #endregion



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseIdentityServer();
            //app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
        }
    }
}
