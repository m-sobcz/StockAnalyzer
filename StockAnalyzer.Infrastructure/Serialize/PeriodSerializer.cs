using StockAnalyzer.Core.FinanceAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Serialize
{
    public class PeriodSerializer
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
