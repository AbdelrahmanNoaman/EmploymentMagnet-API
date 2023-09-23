using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;

namespace ProgramCreation
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
            .Build();

            string host = configuration["DatabaseInfo:host"];
            string port = configuration["DatabaseInfo:port"];

            return WebHost.CreateDefaultBuilder(args)
            .UseUrls($"https://{host}:{port}")
            .UseStartup<Startup>();
        }
    }
}