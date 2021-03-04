using StockAnalyzer.Core.StatementAggregate;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public class PeriodSerializer : ISerializer<Period>
    {
        string serialized;
        public string Serialize(Period period)
        {
            SetYear(period.Year);
            if (period.IsQuarterly)
            {
                AddQuarter(period.Quarter.Value);
            }
            return serialized;
        }
        void SetYear(int year)
        {
            serialized = @$"{year}";
        }
        void AddQuarter(int quarter)
        {
            serialized += @$"/Q{quarter}";
        }
    }
}
