using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockAnalyzer.Infrastructure.Scraping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace StockAnalyzer.IntegrationTests.Scraping
{
    public class ScraperTests
    {
        readonly string testDataPath = "TestData";
        readonly ConfigRepo configRepo=new ConfigRepo();

        [Fact]
        public void ExtractionOfBHW_Income()
        {
            string htmlPath = Path.Combine(testDataPath, "BHW_income.html");
            string html = File.ReadAllText(htmlPath);
            Scraper dataScraper = new Scraper(html);

            string jsonConfig = configRepo.GetByName("Income");
            dynamic result = dataScraper.GetResults(jsonConfig);
            var converted = JsonConvert.SerializeObject(result);
            Assert.Equal("2004", result.periods[0].ToString());
            Assert.Equal("IntrestIncome", result.rows[0].label.ToString());
            Assert.Equal("1727312", result.rows[0].vals[0].ToString());
        }
        [Fact]
        public void ExtractionOfBHW_Balance()
        {
            string htmlPath = Path.Combine(testDataPath, "BHW_balance.html");
            string html = File.ReadAllText(htmlPath);
            Scraper dataScraper = new Scraper(html);

            string jsonConfig = configRepo.GetByName("Balance");
            dynamic result = dataScraper.GetResults(jsonConfig);

            Assert.Equal("2004", result.periods[0].ToString());
            Assert.Equal("CashWithCentralBank", result.rows[0].label.ToString());
            Assert.Equal("841114", result.rows[0].vals[0].ToString());
        }
        [Fact]
        public void ExtractionOfBHW_Cashflow()
        {
            string htmlPath = Path.Combine(testDataPath, "BHW_cashflow.html");
            string html = File.ReadAllText(htmlPath);
            Scraper dataScraper = new Scraper(html);

            string jsonConfig = configRepo.GetByName("Cashflow");
            dynamic result = dataScraper.GetResults(jsonConfig);

            Assert.Equal("2004", result.periods[0].ToString());
            Assert.Equal("OperatingCashflow", result.rows[0].label.ToString());
            Assert.Equal("217139", result.rows[0].vals[0].ToString());
        }
    }
}
