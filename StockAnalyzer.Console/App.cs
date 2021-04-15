using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
namespace StockAnalyzer.Console
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly AppSettings _appSettings;

        public App(IOptions<AppSettings> appSettings, ILogger<App> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
        }

        public async Task Run()
        {
            _logger.LogInformation("Starting...");

            System.Console.WriteLine("Hello world!");
            System.Console.WriteLine(_appSettings.TempDirectory);

            _logger.LogInformation("Finished!");

            await Task.CompletedTask;
        }
    }
}