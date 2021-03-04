using Moq;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape.RawDataSource
{
    public class PeriodDeserializerTests
    {
        private MockRepository mockRepository;



        public PeriodDeserializerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private PeriodDeserializer CreatePeriodDeserializer()
        {
            return new PeriodDeserializer();
        }

        [Fact]
        public void Deserialize_GivenYearOnly_DeserializesCorrect()
        {
            // Arrange
            var periodDeserializer = this.CreatePeriodDeserializer();
            string description = "2021";

            // Act
            var result = periodDeserializer.Deserialize(
                description);

            // Assert
            var expected = new Period(2021);
            Assert.Equal(expected, result);
            this.mockRepository.VerifyAll();
        }
        [Fact]
        public void Deserialize_GivenYearAndQuarter_DeserializesCorrect()
        {
            // Arrange
            var periodDeserializer = this.CreatePeriodDeserializer();
            string description = @"2008/Q3";

            // Act
            var result = periodDeserializer.Deserialize(
                description);

            // Assert
            var expected = new Period(2008,3);
            Assert.Equal(expected, result);
            this.mockRepository.VerifyAll();
        }
        [Theory]
        [InlineData(@"abc")]
        [InlineData(@"2011_")]
        [InlineData(@"2008/W5")]
        public void Deserialize_GivenWrongFormat_ThrowsArgumentException(string description)
        {
            // Arrange
            var periodDeserializer = this.CreatePeriodDeserializer();
            // Act


            // Assert
            Assert.Throws<ArgumentException>(
                ()=>periodDeserializer.Deserialize(description)
                );
            this.mockRepository.VerifyAll();
        }
    }
}
