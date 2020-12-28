using Moq;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StockAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using FluentAssertions;
using StockAnalyzer.Core;
using StockAnalyzer.Infrastructure.Scrape.Repository;

namespace StockAnalyzer.UnitTests.Scrape.DomainRepository
{
    public class DomainRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<IRepositorySource<Stock>> mockRepositorySource;


        public DomainRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockRepositorySource = this.mockRepository.Create<IRepositorySource<Stock>>();
            mockRepositorySource.Setup(x => x.Get()).Returns(GetSampleData());
        }


        private DomainRepository<Stock> CreateRepository()
        {
            return new DomainRepository<Stock>(
                this.mockRepositorySource.Object);
        }
        IEnumerable<Stock> GetSampleData()
        {
            var sampleData = new List<Stock>();
            sampleData.Add(new Stock(1, "stock1", "s1") { ActualPrice = 100 });
            sampleData.Add(new Stock(2, "stock2", "s2") { ActualPrice = 200 });
            sampleData.Add(new Stock(3, "stock3", "s3") { ActualPrice = 300 });
            return sampleData;
        }
        [Fact]
        public void Get_WithoutFilter_ReturnsCompleteData()
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            var result = repository.Get();
            var expected = GetSampleData();

            // Assert
            result.Should().Equal(expected);
        }
        [Fact]
        public void Get_WithSampleFilter_ReturnsFilteredData()
        {
            // Arrange
            var repository = this.CreateRepository();
            Expression<Func<Stock, bool>> filter = (Stock stock)=>stock.ActualPrice<=200;

            // Act
            var result = repository.Get(filter);
            var expected = GetSampleData().Where(filter.Compile());

            // Assert
            result.Should().HaveCount(2).And.Equal(expected);
        }
        [Fact]
        public void Get_GivenID_ReturnsMatch()
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            var result = repository.Get(2);

            // Assert
            result.Name.Should().Be("stock2");
            result.ActualPrice.Should().Be(200);
        }



    }
}
