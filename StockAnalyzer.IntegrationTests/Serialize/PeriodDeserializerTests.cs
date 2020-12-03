using StockAnalyzer.Core.FinanceAggregate;
using StockAnalyzer.Infrastructure.Serialize;
using Xunit;

namespace StockAnalyzer.IntegrationTests.Serialize
{
    public class PeriodDeserializerTests
    {

        [Fact]
        public void YearlyPeriodDeserializesCorrect()
        {
            PeriodDeserializer periodDeserialzier = new PeriodDeserializer();
            Period period = periodDeserialzier.Deserialize("2004");
            Assert.True(period.IsYearly);
            Assert.Equal(2004, period.Year);
            Assert.False(period.Quarter.HasValue);
        }
        [Fact]
        public void QuarterlyPeriodDeserializesCorrect()
        {
            PeriodDeserializer periodDeserialzier = new PeriodDeserializer();
            Period period = periodDeserialzier.Deserialize("2005/Q3");
            Assert.True(period.IsQuarterly);
            Assert.Equal(2005, period.Year);
            Assert.Equal(3, period.Quarter.Value);
        }

        [Fact]
        public void WrongFormatReturnsNull()
        {
            PeriodDeserializer periodDeserialzier = new PeriodDeserializer();
            Period period = periodDeserialzier.Deserialize("txt");
            Assert.Null(period);
        }
    }
}
