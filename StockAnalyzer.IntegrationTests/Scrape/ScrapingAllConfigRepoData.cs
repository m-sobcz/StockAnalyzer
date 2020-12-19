using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape;
using StockAnalyzer.Infrastructure.Scrape.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using System.Linq;

namespace StockAnalyzer.IntegrationTests.Scrape
{
    public class ScrapingAllConfigRepoData
    {
        readonly string testDataPath = "TestData";
        readonly Repository configRepo = new Repository();

        [Fact]
        public void Scrape_GetIncome_ScrapsCorrect()
        {
            // Arrange
            string htmlPath = Path.Combine(testDataPath, "BHW_income.html");
            string html = File.ReadAllText(htmlPath);
            string jsonConfig = configRepo.GetByConfig(ScrapeConfig.Income);
            Scraper<FinanceData> dataScraper = new Scraper<FinanceData>(jsonConfig);

            // Act
            FinanceData scrapedData = dataScraper.Scrape(html);

            // Assert
            Assert.Equal("2004", scrapedData.Periods[0]);
            Assert.Equal("IntrestIncome", scrapedData.Rows[0].Label);
            Assert.Equal("1727312", scrapedData.Rows[0].Vals[0]);
        }
        [Fact]
        public void Scrape_GetBalance_ScrapsCorrect()
        {
            // Arrange
            string htmlPath = Path.Combine(testDataPath, "BHW_balance.html");
            string html = File.ReadAllText(htmlPath);
            string jsonConfig = configRepo.GetByConfig(ScrapeConfig.Balance);
            Scraper<FinanceData> dataScraper = new Scraper<FinanceData>(jsonConfig);


            // Act
            FinanceData scrapedData = dataScraper.Scrape(html);

            // Assert
            Assert.Equal("2004", scrapedData.Periods[0]);
            Assert.Equal("CashWithCentralBank", scrapedData.Rows[0].Label);
            Assert.Equal("841114", scrapedData.Rows[0].Vals[0]);
        }
        [Fact]
        public void Scrape_GetCashflow_ScrapsCorrect()
        {
            // Arrange
            string htmlPath = Path.Combine(testDataPath, "BHW_cashflow.html");
            string html = File.ReadAllText(htmlPath);
            string jsonConfig = configRepo.GetByConfig(ScrapeConfig.Cashflow);
            Scraper<FinanceData> dataScraper = new Scraper<FinanceData>(jsonConfig);

            // Act
            FinanceData scrapedData = dataScraper.Scrape(html);

            // Assert
            Assert.Equal("2004", scrapedData.Periods[0]);
            Assert.Equal("OperatingCashflow", scrapedData.Rows[0].Label);
            Assert.Equal("217139", scrapedData.Rows[0].Vals[0]);
        }
        [Fact]
        public void Scrape_GetStockData_ContainsStockNames()
        {
            // Arrange
            string htmlPath = Path.Combine(testDataPath, "GPW_stocks.html");
            string html = File.ReadAllText(htmlPath);
            string jsonConfig = configRepo.GetByConfig(ScrapeConfig.Stocks);
            Scraper<StocksData> dataScraper = new Scraper<StocksData>(jsonConfig);

            // Act
            StocksData scrapedData = dataScraper.Scrape(html);
            var firstFilledResult= scrapedData.Rows.First(x => x.CombinedName != null);

            // Assert
            Assert.Equal("06N (06MAGNA)", firstFilledResult.CombinedName
                );
            Assert.Equal("https://www.biznesradar.pl/notowania/06N", firstFilledResult.QuotationLink);
            Assert.Equal("1.50", firstFilledResult.ActualPrice);
            Assert.Equal("66494", firstFilledResult.Turnover);
            Assert.Equal("2020-12-09T17:00:00+0100", firstFilledResult.Time);    
        }
    }
}
