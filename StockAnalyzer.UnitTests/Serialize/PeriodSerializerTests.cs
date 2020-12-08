using Moq;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Serialize;
using System;
using Xunit;

namespace StockAnalyzer.UnitTests.Serialize
{
    public class PeriodSerializerTests
    {

        private PeriodSerializer CreatePeriodSerializer()
        {
            return new PeriodSerializer();
        }

        [Fact]
        public void Serialize_Yearly_ReturnsYearOnly()
        {
            // Arrange
            var periodSerializer = this.CreatePeriodSerializer();
            Period period = new Period(2020);

            // Act
            var result = periodSerializer.Serialize(
                period);

            // Assert
            Assert.Equal("2020", result);
        }
        [Fact]
        public void Serialize_Quarterly_ReturnsYearAndQuarter()
        {
            // Arrange
            var periodSerializer = this.CreatePeriodSerializer();
            Period period = new Period(2020,1);

            // Act
            var result = periodSerializer.Serialize(
                period);

            // Assert
            Assert.Equal("2020/Q1", result);
        }
    }
}
