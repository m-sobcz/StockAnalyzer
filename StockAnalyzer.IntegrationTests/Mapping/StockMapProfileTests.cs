using AutoMapper;
using KellermanSoftware.CompareNetObjects;
using Moq;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.Data;
using StockAnalyzer.Infrastructure.Scrape.Mapping;
using System;
using Xunit;

namespace StockAnalyzer.IntegrationTests.Mapping
{
    public class StockMapProfileTests
    {

        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<StockMapProfile>());

            // Assert
            config.AssertConfigurationIsValid();
        }
        public static TheoryData<StocksData.Row, Stock> StockData =>
        new TheoryData<StocksData.Row, Stock>
        {
            {
                new StocksData.Row()
            {
                CombinedName="06N (06MAGNA)"
                },
                new Stock()
                {
                    Name="06MAGNA",
                    Ticker="06N"
                }
            },
            {
                new StocksData.Row()
                {
                    CombinedName="CDR (CDPROJEKT)",
                    ActualPrice="123"
                },
                new Stock()
                {
                    Name="CDPROJEKT",
                    Ticker="CDR",
                    ActualPrice=123
                }
            }
        };
        [Theory]
        [MemberData(nameof(StockData), MemberType = typeof(StockMapProfileTests))]

        public void AutoMapper_Convert_IsValid(StocksData.Row row, Stock expected)
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<StockMapProfile>());
            var mapper = config.CreateMapper();

            // Act
            var result = mapper.Map<StocksData.Row, Stock>(row);
            CompareLogic compareLogic = new CompareLogic();
            var comparision = compareLogic.Compare(expected, result);

            // Assert
            Assert.True(comparision.AreEqual);
        }

    }
}
