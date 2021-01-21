using FluentAssertions;
using Moq;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape.RawDataSource
{
    public class HtmlDataSourceTests
    {
        private MockRepository mockRepository;

        private Mock<IDeserializer<StockRawData>> mockDeserializer;
        private Mock<IHtmlSource> mockHtmlSource;

        public HtmlDataSourceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDeserializer = this.mockRepository.Create<IDeserializer<StockRawData>>();
            mockDeserializer.Setup(x => x.Deserialize(It.IsAny<string>()))
                .Returns<string>(x => new StockRawData() { 
                    Rows = new List<StockRawData.Row>()
                    {
                        new StockRawData.Row { CombinedName = $"{x}Mod" }
                    }
                }); 
            this.mockHtmlSource = this.mockRepository.Create<IHtmlSource>();
            mockHtmlSource.Setup(x => x.GetHtml()).Returns("testHtml");
        }

        private HtmlDataSource<StockRawData> CreateHtmlDataExtractor()
        {
            return new HtmlDataSource<StockRawData>(
                this.mockDeserializer.Object,
                this.mockHtmlSource.Object);
        }
        [Fact]
        public void Get_GivenTestHtml_ReturnsTestHtmlMod()
        {
            // Arrange
            var htmlDataExtractor = this.CreateHtmlDataExtractor();

            // Act
            var result = htmlDataExtractor.Get();

            // Assert
            result.Rows[0].CombinedName.Should().Be("testHtmlMod");
        }
    }
}
