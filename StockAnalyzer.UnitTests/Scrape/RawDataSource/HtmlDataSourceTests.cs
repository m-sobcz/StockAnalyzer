using FluentAssertions;
using Moq;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape.RawDataSource
{
    public class HtmlDataSourceTests
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<IDataExtractor<StockRawData>> mockDataExtractor;
        private readonly Mock<IHtmlSource> mockHtmlSource;

        public HtmlDataSourceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDataExtractor = this.mockRepository.Create<IDataExtractor<StockRawData>>();
            mockDataExtractor.Setup(x => x.Extract(It.IsAny<string>()))
                .Returns<string>(x => new StockRawData()
                {
                    Rows = new List<StockRawData.Row>()
                    {
                        new StockRawData.Row { CombinedName = $"{x}Mod" }
                    }
                });
            this.mockHtmlSource = this.mockRepository.Create<IHtmlSource>();
            mockHtmlSource.Setup(x => x.GetHtml("")).Returns("testHtml");
        }

        private HtmlDataSource<StockRawData> CreateHtmlDataSource()
        {
            return new HtmlDataSource<StockRawData>(
                this.mockDataExtractor.Object,
                this.mockHtmlSource.Object);
        }
        [Fact]
        public void Get_GivenTestHtml_ReturnsTestHtmlMod()
        {
            // Arrange
            var htmlDataExtractor = this.CreateHtmlDataSource();

            // Act
            var result = htmlDataExtractor.Get();

            // Assert
            result.Rows[0].CombinedName.Should().Be("testHtmlMod");
        }
    }
}
