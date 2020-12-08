using Moq;
using StockAnalyzer.Infrastructure.Serialize;
using System;
using Xunit;

namespace StockAnalyzer.UnitTests.Serialize
{
    public class PeriodDeserializerTests
    {

        private PeriodDeserializer CreatePeriodDeserializer()
        {
            return new PeriodDeserializer();
        }

        [Fact]
        public void Deserialize_Yearly_SetsProperties()
        {
            // Arrange
            var periodDeserializer = this.CreatePeriodDeserializer();
            string description = "2004";

            // Act
            var result = periodDeserializer.Deserialize(
                description);

            // Assert
            Assert.Equal(2004, result.Year);
            Assert.False(result.Quarter.HasValue);
            Assert.True(result.IsYearly);
        }
        [Fact]
        public void Deserialize_Quarterly_SetsProperties()
        {
            // Arrange
            var periodDeserializer = this.CreatePeriodDeserializer();
            string description = "2005/Q3";

            // Act
            var result = periodDeserializer.Deserialize(
                description);

            // Assert
            Assert.Equal(2005, result.Year);
            Assert.Equal(3, result.Quarter.Value);
            Assert.False(result.IsYearly);
        }
        [Fact]
        public void Deserialize_WrongFormat_ReturnsNull()
        {
            // Arrange
            var periodDeserializer = this.CreatePeriodDeserializer();
            string description = "nonYear";

            // Act
            var result = periodDeserializer.Deserialize(
                description);

            // Assert
            Assert.Null(result);
        }
    }
}
