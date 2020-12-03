using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockAnalyzer.Infrastructure.Scrape;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace StockAnalyzer.IntegrationTests.Scrape
{
    public class ScraperTests
    {
        readonly string testDataPath = "TestData";
        readonly Repository configRepo = new Repository();

        [Fact]
        public void ExtractionOfBHW_Income()
        {
            string htmlPath = Path.Combine(testDataPath, "BHW_income.html");
            string html = File.ReadAllText(htmlPath);
            Scraper dataScraper = new Scraper(html);

            string jsonConfig = configRepo.GetByConfig(Config.Income);
            ScrapedData scrapedData = dataScraper.GetScrapedFinanceData(jsonConfig);

            Assert.Equal("2004", scrapedData.Periods[0]);
            Assert.Equal("IntrestIncome", scrapedData.Rows[0].Label);
            Assert.Equal("1727312", scrapedData.Rows[0].Vals[0]);
        }
        [Fact]
        public void ExtractionOfBHW_Balance()
        {
            string htmlPath = Path.Combine(testDataPath, "BHW_balance.html");
            string html = File.ReadAllText(htmlPath);
            Scraper dataScraper = new Scraper(html);

            string jsonConfig = configRepo.GetByConfig(Config.Balance);
            ScrapedData scrapedData = dataScraper.GetScrapedFinanceData(jsonConfig);

            Assert.Equal("2004", scrapedData.Periods[0]);
            Assert.Equal("CashWithCentralBank", scrapedData.Rows[0].Label);
            Assert.Equal("841114", scrapedData.Rows[0].Vals[0]);
        }
        [Fact]
        public void ExtractionOfBHW_Cashflow()
        {
            string htmlPath = Path.Combine(testDataPath, "BHW_cashflow.html");
            string html = File.ReadAllText(htmlPath);
            Scraper dataScraper = new Scraper(html);

            string jsonConfig = configRepo.GetByConfig(Config.Cashflow);
            ScrapedData scrapedData = dataScraper.GetScrapedFinanceData(jsonConfig);

            Assert.Equal("2004", scrapedData.Periods[0]);
            Assert.Equal("OperatingCashflow", scrapedData.Rows[0].Label);
            Assert.Equal("217139", scrapedData.Rows[0].Vals[0]);
        }
    }
}
