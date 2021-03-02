using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using StockAnalyzer.Infrastructure.Scrape;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StockAggregate;

namespace StockAnalyzer.Console
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // create service collection
            var services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            var serviceProvider = services.BuildServiceProvider();

            // entry to run app
            await serviceProvider.GetService<App>().Run(args);
            var x=serviceProvider.GetService<IReadOnlyRepository<long, Stock>>();
            var t = x.Get(x => x.ActualPrice > 100.0M);
            foreach (var s in t) 
            {
                System.Console.WriteLine(@$"Name: {s.Name}, Actual price: {s.ActualPrice}");
            }


        }
        private static void ConfigureServices(IServiceCollection services)
        {
            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            services.Configure<AppSettings>(configuration.GetSection("App"));

            // add services:
            // services.AddTransient<IMyRespository, MyConcreteRepository>();
            services.AddScraperServices();

            // add app
            services.AddTransient<App>();
        }
    }
}
