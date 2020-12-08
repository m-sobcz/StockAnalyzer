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
        public List<Statement> Load(FinancesWithPeriods<Income> income,
            FinancesWithPeriods<Balance> balance,
            FinancesWithPeriods<Cashflow> cashflow)
        {
            List<Statement> statements = new List<Statement>();            
            int periodsCount = Math.Min(income.Periods.Count, Math.Min(balance.Periods.Count, cashflow.Periods.Count));
            for (int i = 0; i < periodsCount; i++)
            {
                Period cohesivePeriod = GetCohesivePeriod(income.Periods[i], balance.Periods[i], cashflow.Periods[i]);
                if (cohesivePeriod != null)
                {
                    Statement statement = new Statement()
                    {
                        Period = cohesivePeriod,
                        Balance = balance.Finances[i],
                        Cashflow = cashflow.Finances[i],
                        Income = income.Finances[i]
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

    }
}
