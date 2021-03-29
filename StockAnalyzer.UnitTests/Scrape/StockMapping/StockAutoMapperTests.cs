using AutoMapper;
using Moq;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.StockMapping;
using Xunit;
using static StockAnalyzer.Infrastructure.Scrape.RawData.StockRawData;

namespace StockAnalyzer.UnitTests.Scrape.StockMapping
{
    public class StockAutoMapperTests
    {

        private readonly MockRepository mockRepository;


        public StockAutoMapperTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

        }

        private StockAutoMapper CreateStockAutoMapper()
        {
            return new StockAutoMapper();
        }

        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stockAutoMapper = this.CreateStockAutoMapper();
            Row rawDataRow = new Row() { CombinedName = "06N (06MAGNA)" };

            // Act
            var result = stockAutoMapper.Map(
                rawDataRow);

            // Assert
            Assert.Equal("06MAGNA", result.Name);
            this.mockRepository.VerifyAll();
        }
    }
}
