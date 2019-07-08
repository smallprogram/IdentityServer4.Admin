using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SP.Idp.Web.StartupExtenstions;

namespace SP.Idp.Web
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
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Á´½Ó×Ö·û´®ÅäÖÃ
            var MachineName = System.Environment.MachineName;
            var ConnectionsString = "";
            if (MachineName == "CGYYPC") //Èç¹ûÊ±µ¥Î»»úÆ÷
            {
                ConnectionsString = Configuration.GetConnectionString("CgyyConnection");
                //ConnectionsString = configuration["ConnectionStrings:CgyyConnection"];
            }
            else
            {
                ConnectionsString = Configuration.GetConnectionString("HomeConnection");
                //ConnectionsString = configuration["ConnectionStrings:HomeConnection"];
            }

            // »ù´¡ÅäÖÃ
            services.SP_ConfigureBase(Configuration);

            // ÅäÖÃAsp.net Core Identity
            services.SP_ConfigureAspNetCoreIdentity(ConnectionsString);

            // ÅäÖÃIdentityServer4
            services.SP_ConfigureIdentityServer4(Environment, ConnectionsString);

            #region DI(ÒÀÀµ×¢Èë) ÅäÖÃ

            services.SP_DI();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseIdentityServer();

            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
