using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.Config;
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
        public List<Statement> Load(ScrapedData incomesData, ScrapedData balancesData, ScrapedData cashflowsData)
        {
            List<Statement> statements = new List<Statement>();
            List<Period> incomePeriods = DeserializePeriods(incomesData.Periods);
            List<Period> balancePeriods = DeserializePeriods(balancesData.Periods);
            List<Period> cashflowPeriods = DeserializePeriods(cashflowsData.Periods);
            
            List<Income> incomes = incomeLoader.Load(incomesData.Rows);
            List<Balance> balances = balanceLoader.Load(balancesData.Rows);
            List<Cashflow> cashflows = cashflowLoader.Load(cashflowsData.Rows);

            int periodsCount = Math.Min(incomePeriods.Count, Math.Min(balancePeriods.Count, cashflowPeriods.Count));
            for (int i = 0; i < periodsCount; i++)
            {
                Period cohesivePeriod = GetCohesivePeriod(incomePeriods[i], balancePeriods[i], cashflowPeriods[i]);
                if (cohesivePeriod != null)
                {
                    Statement statement = new Statement()
                    {
                        Period = cohesivePeriod,
                        Balance = balances[i],
                        Cashflow = cashflows[i],
                        Income = incomes[i]
                    };
                    statements.Add(statement);
                }
            }
            return statements;
        }
        Period GetCohesivePeriod(Period p1, Period p2, Period p3)
        {
            if (p1 != null && p1.Equals(p2) && p2.Equals(p3)) return p1;
            else return null;
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
