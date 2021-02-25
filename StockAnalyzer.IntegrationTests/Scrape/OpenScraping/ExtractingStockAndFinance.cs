using System.IO;
using Xunit;
using System.Linq;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using OpenScraping;
using StockAnalyzer.Infrastructure.Scrape.RawDataExtracting;

namespace StockAnalyzer.IntegrationTests.Scrape
{
    public class ExtractingStockAndFinance
    {
        readonly string testDataPath = "Scrape//TestData";
        readonly ConfigRepository configRepo = new ConfigRepository();
        OpenScrapingExtractorFactory<FinanceRawData> financeExtractorFactory;
        OpenScrapingExtractorFactory<StockRawData> stocksExtractorFactory;
        public ExtractingStockAndFinance()
        {
            financeExtractorFactory = new OpenScrapingExtractorFactory<FinanceRawData>(configSection => new OpenScrapingDataExtractor<FinanceRawData>(new StructuredDataExtractor(configSection)),configRepo);
            stocksExtractorFactory = new OpenScrapingExtractorFactory<StockRawData>(configSection => new OpenScrapingDataExtractor<StockRawData>(new StructuredDataExtractor(configSection)), configRepo);
        }

        [Fact]
        public void Scrape_GetIncome_ScrapsCorrect()
        {
            // Arrange
            string htmlPath = Path.Combine(testDataPath, "BHW_income.html");
            string html = File.ReadAllText(htmlPath);
            var dataScraper = financeExtractorFactory.CreateFromName("Income");

            // Act
            FinanceRawData scrapedData = dataScraper.Extract(html);

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
            var dataScraper = financeExtractorFactory.CreateFromName("Balance");

            // Act
            FinanceRawData scrapedData = dataScraper.Extract(html);

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
            var dataScraper = financeExtractorFactory.CreateFromName("Cashflow");

            // Act
            FinanceRawData scrapedData = dataScraper.Extract(html);

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
            var dataScraper = stocksExtractorFactory.CreateFromName("Stocks");

            // Act
            StockRawData scrapedData = dataScraper.Extract(html);
            var firstFilledResult= scrapedData.Rows.First(x => x.CombinedName != null);

            // Assert
            Assert.Equal("06N (06MAGNA)", firstFilledResult.CombinedName
                );
            Assert.Equal("https://www.biznesradar.pl/notowania/06N", firstFilledResult.QuotationLink);
            Assert.Equal("1.50", firstFilledResult.ActualPrice);
            Assert.Equal("66494", firstFilledResult.Turnover);
            Assert.Equal("2020-12-09T17:00:00+0100", firstFilledResult.UpdateTime);    
        }
    }
}
