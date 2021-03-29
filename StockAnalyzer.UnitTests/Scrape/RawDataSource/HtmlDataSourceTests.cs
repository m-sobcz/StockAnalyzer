using FluentAssertions;
using Moq;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            Func<string,Task<StockRawData>> extractGenFunc = ExtractSampleDataTask;
            this.mockDataExtractor = this.mockRepository.Create<IDataExtractor<StockRawData>>();
            mockDataExtractor.Setup(x => x.Extract(It.IsAny<string>())).Returns(extractGenFunc);
            this.mockHtmlSource = this.mockRepository.Create<IHtmlSource>();
            mockHtmlSource.Setup(x => x.GetHtml(It.IsAny<string>())).Returns(Task.FromResult("testHtml"));
        }
        Task<StockRawData> ExtractSampleDataTask(string testPrefix) 
        {
            var stockRawData= new StockRawData()
            {
                Rows = new List<StockRawData.Row>()
                    {
                        new StockRawData.Row { CombinedName = testPrefix+"Mod" }
                    }
            };
            return Task.FromResult(stockRawData);
        }

        private HtmlRawDataSource<StockRawData> CreateHtmlDataSource()
        {
            return new HtmlRawDataSource<StockRawData>(
                this.mockDataExtractor.Object,
                this.mockHtmlSource.Object);
        }
        [Fact]
        public void Get_GivenTestHtml_ReturnsTestHtmlMod()
        {
            // Arrange
            HtmlRawDataSource<StockRawData> htmlDataSource = CreateHtmlDataSource();

            // Act

            var result = htmlDataSource.Get().Result;
            // Assert
            result.Rows[0].CombinedName.Should().Be("testHtmlMod");
        }
    }
}
