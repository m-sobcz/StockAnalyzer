using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Serialize;
using Xunit;

namespace StockAnalyzer.IntegrationTests.Serialize
{
    public class PeriodSerializerTests
    {

        [Fact]
        public void YearlyPeriodSerializesCorrect()
        {
            PeriodSerializer periodSerializer = new PeriodSerializer();
            string period =periodSerializer.Serialize(new Period(2020));
            Assert.Equal("2020", period);
        }
        [Fact]
        public void QuarterlyPeriodSerializesCorrect()
        {
            PeriodSerializer periodSerializer = new PeriodSerializer();
            string period = periodSerializer.Serialize(new Period(2020,1));
            Assert.Equal("2020/Q1", period);
        }

    }
}
