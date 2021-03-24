using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.StatementLoad
{
    public interface IFinanceLoader<TFinance> where TFinance : Finance
    {
        public List<Tuple<TFinance, Period>> GenerateFinanceWithPeriods(FinanceRawData rawData);
    }
}
