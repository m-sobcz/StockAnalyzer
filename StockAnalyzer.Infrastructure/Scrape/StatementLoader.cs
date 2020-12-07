using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape
{
    public class StatementLoader
    {
        readonly IScrapedLoader<Income> incomeLoader;
        readonly IScrapedLoader<Balance> balanceLoader;
        readonly IScrapedLoader<Cashflow> cashflowLoader;
        readonly IDeserializer<Period> periodDeserializer;
        public StatementLoader(IDeserializer<Period> periodDeserializer, IScrapedLoader<Income> incomeLoader,
            IScrapedLoader<Balance> balanceLoader, IScrapedLoader<Cashflow> cashflowLoader)
        {
            this.periodDeserializer = periodDeserializer;
            this.incomeLoader = incomeLoader;
            this.balanceLoader = balanceLoader;
            this.cashflowLoader = cashflowLoader;
        }
        public List<Statement> Load(ScrapedData scrapedData)
        {
            List<Statement> statements = new List<Statement>();
            List<Period> periods = DeserializePeriods(scrapedData.Periods);
            List<Income> incomes = incomeLoader.Load(scrapedData.Rows);
            List<Balance> balances = balanceLoader.Load(scrapedData.Rows);
            List<Cashflow> cashflows = cashflowLoader.Load(scrapedData.Rows);
            for (int i = 0; i < periods.Count; i++)
            {
                if (periods[i] != null) 
                {
                    Statement statement = new Statement()
                    {
                        Period = periods[i],
                        Balance = balances[i],
                        Cashflow = cashflows[i],
                        Income = incomes[i]
                    };
                    statements.Add(statement);
                }
            }
            return statements;
        }

        List<Period> DeserializePeriods(List<string> serializedPeriods)
        {
            List<Period> periods = new List<Period>();
            foreach (var serialized in serializedPeriods)
            {
                Period period = periodDeserializer.Deserialize(serialized);
                    periods.Add(period);
            }
            return periods;
        }

    }
}
