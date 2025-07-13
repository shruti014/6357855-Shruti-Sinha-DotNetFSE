using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace exercise3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Entry point for ASP.NET Core Web Host
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Use Startup.cs to configure services and middleware
                    webBuilder.UseStartup<Startup>();
                });
    }
}