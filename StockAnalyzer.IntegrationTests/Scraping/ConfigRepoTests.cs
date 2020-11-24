using StockAnalyzer.Infrastructure.Scraping;
using System;
using Xunit;

namespace StockAnalyzer.IntegrationTests.Scraping
{
   public class ConfigRepoTests
    {
        [Fact]
        public void DefaultRepoContainsEssentialConfigs()
        {
            ConfigRepo configRepo = new ConfigRepo();

            Assert.Contains("Income", configRepo.Names());
            Assert.Contains("Cashflow", configRepo.Names());
            Assert.Contains("Balance", configRepo.Names());
        }
        [Fact]
        public void GettingNonExistentRepoThrowsException()
        {
            ConfigRepo configRepo = new ConfigRepo();

            var exception = Record.Exception(() => configRepo.GetByName("nonExistent"));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }
    }
}
