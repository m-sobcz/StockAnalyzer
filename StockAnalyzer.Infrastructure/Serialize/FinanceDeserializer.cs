using StockAnalyzer.Core.FinanceAggregate;
using StockAnalyzer.Infrastructure.Scrape;
using System;
using System.Collections.Generic;

namespace StockAnalyzer.Infrastructure.Serialize
{
    class FinanceDeserializer
    {
        readonly Func<Finance> getFinance;
        readonly PeriodDeserializer periodDeserializer;
        readonly FinancePropertiesLoader<Finance> financeDataFiller;
        public FinanceDeserializer(Func<Finance> getFinance, PeriodDeserializer periodDeserializer, FinancePropertiesLoader<Finance> financeDataFiller)
        {
            this.getFinance = getFinance;
            this.periodDeserializer = periodDeserializer;
            this.financeDataFiller = financeDataFiller;
        }
        List<Finance> Deserialize(ScrapedData scrapedData)
        {
            List<Finance> finances = new List<Finance>();
            for (int i = 0; i < scrapedData.Periods.Count; i++)
            {
                finances.Add(getFinance());
                finances[i].Period = periodDeserializer.Deserialize(scrapedData.Periods[i]);
            }
            financeDataFiller.LoadFinancesWithData(finances, scrapedData);
            return finances;
        }


    }
}
