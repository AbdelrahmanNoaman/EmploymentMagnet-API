using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;

namespace ProgramCreation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseUrls("https://localhost:5000")
            .UseStartup<Startup>();
    }
}