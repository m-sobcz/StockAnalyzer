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
        [Fact]
        public void ExtractionOfBHW_Income()
        {
            string htmlPath = Path.Combine(testDataPath, "BHW_income.html");
            string html = File.ReadAllText(htmlPath);
            Scraper dataScraper = new Scraper(html);
            ConfigRepo repo = new ConfigRepo();

            string jsonConfig = repo.GetByName("Income");
            dynamic result = dataScraper.GetResults(jsonConfig);

            Assert.Equal("2004", result.periods[0].ToString());
            Assert.Equal("IncomeIntrestIncome", result.rows[0].label.ToString());
            Assert.Equal("1727312", result.rows[0].vals[0].ToString());
        }
    }
}
