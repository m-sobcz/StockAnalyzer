using Moq;
using StockAnalyzer.Infrastructure.Scrape;
using System;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape
{
    public class RepositoryTests
    {
        private MockRepository mockRepository;
        public RepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Repository CreateRepository()
        {
            return new Repository();
        }

        [Fact]
        public void Names_CreatedWithNoArgumentsConstructor_ContainsAllConfigTypes()
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            var result = repository.Names();

            // Assert
            foreach (var config in Enum.GetValues(typeof(ConfigType)))
            {
                Assert.Contains(config.ToString(), result);
            }
            this.mockRepository.VerifyAll();
        }

        [Theory()]
        [InlineData(ConfigType.Income)]
        [InlineData(ConfigType.Balance)]
        [InlineData(ConfigType.Cashflow)]
        public void GetByConfig_WithAllBaseConfigs_ReturnsNonNull(ConfigType config)
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            var result = repository.GetByConfig(
                config);

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        [Fact]
        public void GetByName_Balance_ReturnsNonNull()
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            var result = repository.GetByName(
                "Balance");

            // Assert
            Assert.NotNull(result);
            this.mockRepository.VerifyAll();
        }
        [Fact]
        public void GetByName_GivenNonExistent_ThrowsArgumentException()
        {
            // Arrange
            var repository = this.CreateRepository();

            // Act
            var exception = Record.Exception(
                () => repository.GetByName("nonExistent")
                );

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
        }


    }
}
