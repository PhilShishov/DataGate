
namespace Pharus.App
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, log) =>
                {
                    log.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    log.AddConsole();
                })
                .UseStartup<Startup>();
    }
}
