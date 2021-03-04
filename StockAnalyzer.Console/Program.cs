using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape;
using System.IO;
using System.Threading.Tasks;

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
            // Stock test !
            var stockRepo = serviceProvider.GetService<IReadOnlyRepository<long, Stock>>();
            var filteredStocks = stockRepo.Get(x => x.ActualPrice > 100.0M);
            foreach (var s in filteredStocks)
            {
                System.Console.WriteLine(@$"Name: {s.Name}, Actual price: {s.ActualPrice}");
            }
            // Statement test !
            var statementRepo = serviceProvider.GetService<IReadOnlyRepository<long, Statement>>();
            var filteredStatements = statementRepo.Get(null);
            System.Console.WriteLine($@"---Sprawozdania BHW---");
            foreach (var s in filteredStatements)
            {               
                System.Console.WriteLine(@$"Period year: {s.Period.Year}, Balance goodwill: { s.Balance.Goodwill}, Income EBITDA: {s.Income.EBITDA}, Cashflow CAPEX: {s.Cashflow.Capex}");
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
