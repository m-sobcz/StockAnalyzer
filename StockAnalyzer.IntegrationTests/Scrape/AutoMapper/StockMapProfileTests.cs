using AutoMapper;
using KellermanSoftware.CompareNetObjects;
using Moq;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.StockMapping;
using System;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape.StockMapper
{
    public class StockMapProfileTests
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new StockMapProfile()));

            // Assert
            config.AssertConfigurationIsValid();
        }

        public static TheoryData<StockRawData.Row, Stock> StockData =>
        new TheoryData<StockRawData.Row, Stock>
        {
            {
                new StockRawData.Row()
            {
                CombinedName="06N (06MAGNA)",
                UpdateTime="2020-12-21T16:14:08+0100"
                },
                new Stock()
                {
                    Name="06MAGNA",
                    Ticker="06N",
                    UpdateTime=new DateTimeOffset(2020,12,21,16,14,8,0,TimeSpan.FromMinutes(60))
                }
            },
            {
                new StockRawData.Row()
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

        public void AutoMapper_Convert_IsValid(StockRawData.Row row, Stock expected)
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new StockMapProfile()));
            var mapper = config.CreateMapper();

            // Act
            var result = mapper.Map<StockRawData.Row, Stock>(row);

            // Assert
            CompareLogic compareLogic = new CompareLogic();
            var comparision = compareLogic.Compare(expected, result);
            Assert.True(comparision.AreEqual);
        }
    }
}
