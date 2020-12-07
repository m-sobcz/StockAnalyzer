using StockAnalyzer.Infrastructure.Scrape;
using System;
using Xunit;

namespace StockAnalyzer.IntegrationTests.Scrape
{
    public class ConfigRepoTests
    {
        [Fact]
        public void DefaultRepoContainsEssentialConfigs()
        {
            Repository configRepo = new Repository();
            foreach (var config in Enum.GetValues(typeof(ConfigType)))
            {
                Assert.Contains(config.ToString(), configRepo.Names());
            }
        }
        [Fact]
        public void GettingIncomeConfigReturnsSomeResult()
        {
            Repository configRepo = new Repository();
            var config = configRepo.GetByConfig(ConfigType.Income);

            Assert.NotNull(config);
            Assert.True(config.Length > 0);
        }
        [Fact]
        public void GettingNonExistentRepoThrowsException()
        {
            Repository configRepo = new Repository();

            var exception = Record.Exception(() => configRepo.GetByName("nonExistent"));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }
    }
}
