using FluentAssertions;
using Moq;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape.DataSource
{
    public class StockSourceTests
    {
        private MockRepository mockRepository;

        private Mock<IStockMapper> mockStockMapper;
        private Mock<IRawDataSource<StockRawData>> mockRawDataSource;

        public StockSourceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockStockMapper = this.mockRepository.Create<IStockMapper>();
            mockStockMapper.Setup(x => x.Map(It.IsAny<StockRawData.Row>())).Returns<StockRawData.Row>(x=>new Stock() { Name=x.CombinedName+"Mod"});
            this.mockRawDataSource = this.mockRepository.Create<IRawDataSource<StockRawData>>();
            mockRawDataSource.Setup(x => x.Get()).Returns(GetStockRawData());

        }

        private StockSource CreateStockSource()
        {
            return new StockSource(
                this.mockStockMapper.Object,
               this.mockRawDataSource.Object);
        }
        StockRawData GetStockRawData()
        {
            StockRawData stockRawData = new StockRawData();
            stockRawData.Rows = new List<StockRawData.Row>();
            stockRawData.Rows.Add(new StockRawData.Row() { CombinedName = "name1" });
            stockRawData.Rows.Add(new StockRawData.Row() { CombinedName = "name2" });
            stockRawData.Rows.Add(new StockRawData.Row() { CombinedName = "name3" });
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
            List<Stock> expected = new List<Stock>
            {
                new Stock() { Name = "name1Mod" },
                new Stock() { Name = "name2Mod" },
                new Stock() { Name = "name3Mod" }
            };
            mockStockMapper.Verify(x => x.Map(It.IsAny<StockRawData.Row>()), Times.Exactly(3));
            result.Select(x => x.Name).Should().Equal(expected.Select(x => x.Name));
        }
    }
}
