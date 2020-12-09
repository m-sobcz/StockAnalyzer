using Moq;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape;
using StockAnalyzer.Infrastructure.Scrape.Data;
using System;
using System.IO;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape
{
    public class ScraperTests
    {
        [Fact]
        public void Scrape_GetStockNames_ContainsStockNames()
        {
            // Arrange
            string html = GetTestHtml();
            string jsonConfig = GetTestJsonConfig();
            Scraper<StockNamesData> dataScraper = new Scraper<StockNamesData>(jsonConfig);

            // Act
            StockNamesData scrapedData = dataScraper.Scrape(html);

            // Assert
            Assert.Equal("06N (06MAGNA)", scrapedData.Names[0]);
        }


        string GetTestHtml()
        {
            return @"<tr id=""qtable-s-248"" class=""soid soid-248"">
<td><a class=""s_tt s_tt_sname_06N wname"" href=""https://www.biznesradar.pl/notowania/06N"">06N (06MAGNA)</a></td>
<td><time class=""q_ch_date"" datetime=""2020-12-09T17:00:00+0100"">17:00</time></td>
</tr>	
<tr id=""qtable-s-324"" class=""soid soid-324"">
<td><a class=""s_tt s_tt_sname_08N wname"" href=""https://www.biznesradar.pl/notowania/OCTAVA"">08N (08OCTAVA)</a></td>
<td><time class=""q_ch_date"" datetime=""2020-12-09T15:00:00+0100"">15:00</time></td>
</tr>	";
        }
        string GetTestJsonConfig()
        {
            return @"
{
  ""names"": {
    ""_xpath"": ""//td//a""
  }
}
";
        }


    }
}
