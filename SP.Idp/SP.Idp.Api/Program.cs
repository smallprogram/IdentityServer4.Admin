using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace SP.Idp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //serilog配置
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()  //最小日志输入级别
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information) //覆盖带有Microsoft的日志级别为Information
                .Enrich.FromLogContext()
                .WriteTo.Console()
                //.WriteTo.File(Path.Combine("logs", @"log.txt"), rollingInterval: RollingInterval.Day) //记录到文件，每天记录
                .CreateLogger();




            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
