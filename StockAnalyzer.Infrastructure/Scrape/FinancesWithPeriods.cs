using StockAnalyzer.Core.StatementAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape
{
    public class FinancesWithPeriods<T> where T : Finance
    {

        public List<T> Finances { get; set; }
        public List<Period> Periods{get;set;}
}
}
