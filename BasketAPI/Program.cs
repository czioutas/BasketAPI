using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BasketAPI.Data.Seed;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BasketAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();
            
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            using (var scope = host.Services.CreateScope())
            {
                
                var services = scope.ServiceProvider;

                await DemoSeed.SeedAsync(services);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://127.0.0.1:9005")
                .UseStartup<Startup>();
    }
}
