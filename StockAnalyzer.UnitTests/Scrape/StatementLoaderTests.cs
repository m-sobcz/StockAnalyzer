using Moq;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape;
using System;
using System.Collections.Generic;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape
{
    public class StatementLoaderTests
    {
        private StatementLoader CreateStatementLoader()
        {
            return new StatementLoader();
        }
        List<Period> GetPeriodsList()
        {
            return new List<Period>()
                {
                    new Period(2000),
                    new Period(2001),
                };
        }

        List<Income> GetIncomes()
        {
            return new List<Income>()
                {
                    new Income(){ AdministrationCosts=1,BeforeTaxProfit=2,DiscontinuedProfit=3},
                    new Income(){ AdministrationCosts=10,BeforeTaxProfit=20,DiscontinuedProfit=30}
                };
        }
        List<Balance> GetBalances()
        {
            return new List<Balance>()
                {
                    new Balance(){ CashWithCentralBank=4,FinAssetsForTrading=5,Goodwill=6},
                    new Balance(){ CashWithCentralBank=40,FinAssetsForTrading=50,Goodwill=60}
                };
        }
        List<Cashflow> GetCashflows()
        {
            return new List<Cashflow>()
                {
                    new Cashflow(){Amortization=7,Capex=8,Dividend=9},
                    new Cashflow(){Amortization=70,Capex=80,Dividend=90}
                };
        }

        [Fact]
        public void Load_AllPeriodsMatch_CompleteStatementsReceived()
        {
            // Arrange
            var statementLoader = this.CreateStatementLoader();

            FinancesWithPeriods<Income> income = new FinancesWithPeriods<Income>()
            {
                Finances = GetIncomes(),
                Periods= GetPeriodsList()
            };
            FinancesWithPeriods<Balance> balance = new FinancesWithPeriods<Balance>()
            {
                Finances = GetBalances(),
                Periods = GetPeriodsList()
            };
            FinancesWithPeriods<Cashflow> cashflow = new FinancesWithPeriods<Cashflow>()
            {
                Finances = GetCashflows(),
                Periods = GetPeriodsList()
            };

            // Act
            var result = statementLoader.Load(
                income,
                balance,
                cashflow);

            // Assert
            Assert.Equal(2,result.Count);
            Assert.Equal(balance.Periods[1], result[1].Period);
            Assert.Equal(balance.Finances[0].CashWithCentralBank, result[0].Balance.CashWithCentralBank);
            Assert.Equal(balance.Finances[1].Goodwill, result[1].Balance.Goodwill);
            Assert.Equal(cashflow.Finances[1].Amortization, result[1].Cashflow.Amortization);
        }
        [Fact]
        public void Load_DifferentPeriods_ReturnsEmpty()
        {
            // Arrange
            var statementLoader = this.CreateStatementLoader();

            FinancesWithPeriods<Income> income = new FinancesWithPeriods<Income>()
            {
                Finances = GetIncomes(),
                Periods = GetPeriodsList()
            };
            FinancesWithPeriods<Balance> balance = new FinancesWithPeriods<Balance>()
            {
                Finances = GetBalances(),
                Periods = GetPeriodsList()
            };
            FinancesWithPeriods<Cashflow> cashflow = new FinancesWithPeriods<Cashflow>()
            {
                Finances = GetCashflows(),
                Periods = new List<Period>() 
                {
                    new Period(2010),
                     new Period(2011)
                }
            };

            // Act
            var result = statementLoader.Load(
                income,
                balance,
                cashflow);

            // Assert
            Assert.Empty(result);
        }
    }
}
