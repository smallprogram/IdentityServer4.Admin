using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SP.Idp.Api.StartupExtenstions
{
    public static class ConfigureDBConnectionStr
    {
        public static string SP_ConfigureDBConnectionStr(this IServiceCollection services, IConfiguration Configuration)
        {
            var MachineName = System.Environment.MachineName;
            if (MachineName == "CGYYPC") //如果时单位机器
            {
                return Configuration.GetConnectionString("CgyyConnection");
                //ConnectionsString = configuration["ConnectionStrings:CgyyConnection"];
            }
            else
            {
                return Configuration.GetConnectionString("HomeConnection");
                //ConnectionsString = configuration["ConnectionStrings:HomeConnection"];
            }
        }
    }
}
