using FluentAssertions;
using Moq;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape.DomainRepository
{
    public class DomainRepositoryTests
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<IRepositorySource<Stock>> mockRepositorySource;


        public DomainRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockRepositorySource = this.mockRepository.Create<IRepositorySource<Stock>>();
            mockRepositorySource.Setup(x => x.Get()).Returns(Task.FromResult(GetSampleData()));
        }


        private DomainRepository<Stock> CreateRepository()
        {
            return new DomainRepository<Stock>(
                this.mockRepositorySource.Object);
        }
        IEnumerable<Stock> GetSampleData()
        {
            var sampleData = new List<Stock>
            {
                new Stock(1, "stock1", "s1") { ActualPrice = 100 },
                new Stock(2, "stock2", "s2") { ActualPrice = 200 },
                new Stock(3, "stock3", "s3") { ActualPrice = 300 }
            };
            return sampleData;
        }
        [Fact]
        public async Task Get_WithoutFilter_ReturnsCompleteDataAsync()
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            var result = await repository.Get();
            var expected = GetSampleData();

            // Assert
            result.Should().Equal(expected);
        }
        [Fact]
        public async Task Get_WithSampleFilter_ReturnsFilteredDataAsync()
        {
            // Arrange
            var repository = this.CreateRepository();
            Expression<Func<Stock, bool>> filter = (Stock stock) => stock.ActualPrice <= 200;

            // Act
            var result = await repository.Get(filter);
            var expected = GetSampleData().Where(filter.Compile());

            // Assert
            result.Should().HaveCount(2).And.Equal(expected);
        }
        [Fact]
        public async Task Get_GivenID_ReturnsMatchAsync()
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            var result = await repository.Get(2);

            // Assert
            result.Name.Should().Be("stock2");
            result.ActualPrice.Should().Be(200);
        }



    }
}
