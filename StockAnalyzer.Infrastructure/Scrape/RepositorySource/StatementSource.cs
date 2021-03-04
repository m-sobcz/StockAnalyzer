using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using System;
using System.Collections.Generic;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public class StatementSource : IRepositorySource<Statement>
    {
        readonly IFinanceLoader<Income> incomeLoader;
        readonly IFinanceLoader<Balance> balanceLoader;
        readonly IFinanceLoader<Cashflow> cashflowLoader;
        IRawDataSource<IncomeRawData> incomeRawDataSource;
        IRawDataSource<BalanceRawData> balanceRawDataSource;
        IRawDataSource<CashflowRawData> cashflowRawDataSource;
        public StatementSource(IFinanceLoader<Income> incomeLoader,
            IFinanceLoader<Balance> balanceLoader,
            IFinanceLoader<Cashflow> cashflowLoader,
            IRawDataSource<IncomeRawData> incomeRawDataSource,
            IRawDataSource<BalanceRawData> balanceRawDataSource,
            IRawDataSource<CashflowRawData> cashflowRawDataSource
            )
        {
            this.incomeLoader = incomeLoader;
            this.balanceLoader = balanceLoader;
            this.cashflowLoader = cashflowLoader;
            this.incomeRawDataSource = incomeRawDataSource;
            this.balanceRawDataSource = balanceRawDataSource;
            this.cashflowRawDataSource = cashflowRawDataSource;
        }

        public IEnumerable<Statement> Get()
        {
            FinanceRawData incomeRawData =incomeRawDataSource.Get();
            FinanceRawData balanceRawData = balanceRawDataSource.Get();
            FinanceRawData cashflowRawData = cashflowRawDataSource.Get();
            List<Tuple<Income, Period>> incomes = incomeLoader.GenerateFinanceWithPeriods(incomeRawData);
            List<Tuple<Balance, Period>> balances =balanceLoader.GenerateFinanceWithPeriods(balanceRawData);
            List<Tuple<Cashflow, Period>> cashflows =cashflowLoader.GenerateFinanceWithPeriods(cashflowRawData);
            List<Statement> statements = new List<Statement>();
            int periodsCount = Math.Min(incomes.Count, Math.Min(balances.Count, cashflows.Count));
            for (int i = 0; i < periodsCount; i++)
            {
                Period cohesivePeriod = GetCohesivePeriod(incomes[i].Item2, balances[i].Item2, cashflows[i].Item2);
                if (cohesivePeriod != null)
                {
                    Statement statement = new Statement()
                    {
                        Period = cohesivePeriod,
                        Balance = balances[i].Item1,
                        Cashflow = cashflows[i].Item1,
                        Income = incomes[i].Item1
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
