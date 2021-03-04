using StockAnalyzer.Core.StatementAggregate;
using System.Collections.Generic;

namespace StockAnalyzer.Infrastructure.Scrape.RawData
{
    public class FinancesWithPeriods<T> where T : Finance
    {

        public List<T> Finances { get; set; }
        public List<Period> Periods { get; set; }
    }
}
