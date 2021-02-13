using AutoMapper;
using Moq;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.StockMapping;
using System;
using Xunit;
using static StockAnalyzer.Infrastructure.Scrape.RawData.StockRawData;

namespace StockAnalyzer.UnitTests.Scrape.StockMapping
{
    public class StockAutoMapperTests
    {
        readonly string testName = "test123";
        private MockRepository mockRepository;

        private Mock<IMapper> mockMapper;

        public StockAutoMapperTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockMapper = this.mockRepository.Create<IMapper>();
            mockMapper.Setup(x => x.Map<StockRawData.Row, Stock>(It.IsAny<StockRawData.Row>()))
                .Returns<StockRawData.Row>(x => new Stock() { Name = testName });

        }

        private StockAutoMapper CreateStockAutoMapper()
        {
            return new StockAutoMapper(
                this.mockMapper.Object);
        }

        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stockAutoMapper = this.CreateStockAutoMapper();
            Row rawDataRow = null;

            // Act
            var result = stockAutoMapper.Map(
                rawDataRow);
            // Assert
            Assert.Equal(testName, result.Name);
            this.mockRepository.VerifyAll();
        }
    }
}
