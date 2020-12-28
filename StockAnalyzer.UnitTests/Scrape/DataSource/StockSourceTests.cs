using FluentAssertions;
using Moq;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.DataSource;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape.DataSource
{
    public class StockSourceTests
    {
        private MockRepository mockRepository;

        private Mock<IStockMapper> mockStockMapper;

        public StockSourceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockStockMapper = this.mockRepository.Create<IStockMapper>();
            mockStockMapper.Setup(x => x.Map(It.IsAny<StockRawData.Row>())).Returns(new Stock());

        }

        private StockSource CreateStockSource()
        {
            return new StockSource(
                this.mockStockMapper.Object,
               GetStockRawData());
        }
        StockRawData GetStockRawData() 
        {
            StockRawData stockRawData = new StockRawData();
            stockRawData.Rows = new List<StockRawData.Row>();
            stockRawData.Rows.Add(new StockRawData.Row());
            stockRawData.Rows.Add(new StockRawData.Row());
            stockRawData.Rows.Add(new StockRawData.Row());
            return stockRawData;
        }
        [Fact]
        public void Get_Given3DataRows_MapsInto3Stocks()
        {
            // Arrange
            var stockSource = this.CreateStockSource();

            // Act
            var result = stockSource.Get();

            // Assert
            mockStockMapper.Verify(x => x.Map(It.IsAny<StockRawData.Row>()),Times.Exactly(3));
            result.Should().HaveCount(3);
        }
    }
}
