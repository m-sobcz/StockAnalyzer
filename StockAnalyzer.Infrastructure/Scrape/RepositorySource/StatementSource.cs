using StockAnalyzer.Core;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public class StatementSource : IRepositorySource<Statement>
    {
        readonly FinancesWithPeriods<Income> income;
        readonly FinancesWithPeriods<Balance> balance;
        readonly FinancesWithPeriods<Cashflow> cashflow;
        readonly ISerializer<Period> periodSerializer;
        public StatementSource(FinancesWithPeriods<Income> income,
            FinancesWithPeriods<Balance> balance,
            FinancesWithPeriods<Cashflow> cashflow,
            ISerializer<Period> periodSerializer)
        {
            this.income = income;
            this.balance = balance;
            this.cashflow = cashflow;
            this.periodSerializer = periodSerializer;
        }

        public IEnumerable<Statement> Get()
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
