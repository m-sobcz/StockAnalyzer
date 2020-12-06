using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Core.StatementAggregate
{
    public class Balance : Finance
    {
        public decimal CashWithCentralBank { get; set; }
        public decimal LoansToBanks { get; set; }
        public decimal FinAssetsForTrading { get; set; }
        public decimal HeldFinancialAssets { get; set; }
        public decimal LoansToCustomers { get; set; }
        public decimal OtherFinAssets { get; set; }
        public decimal InvestInSubsidiaries { get; set; }
        public decimal IntangibleAssets { get; set; }
        public decimal Goodwill { get; set; }
        public decimal Property { get; set; }
        public decimal TaxAssets { get; set; }
        public decimal OtherAssets { get; set; }
        public decimal TotalAssets { get; set; }
        public decimal LiabilitiesToCentralBank { get; set; }
        public decimal LiabilitiesToBanks { get; set; }
        public decimal HeldFinancialLiabilities { get; set; }
        public decimal FinLiabilitiesForTrading { get; set; }
        public decimal LiabilitiesToCustomers { get; set; }
        public decimal DebtSecurities { get; set; }
        public decimal SubodinatedLiabilities { get; set; }
        public decimal TaxLiabilities { get; set; }
        public decimal OtherLiabilities { get; set; }
        public decimal TotalLiabilities { get; set; }
        public decimal OwnCapital { get; set; }
        public decimal ShareCapital { get; set; }
        public decimal SharePremium { get; set; }
        public decimal RevaluationReserves { get; set; }
        public decimal RetainedReserves { get; set; }
        public decimal YearProfit { get; set; }
        public decimal NonControlProfit { get; set; }
        public decimal TotalCapital { get; set; }
        public decimal TotalEquityAndLiabilities { get; set; }

	}
}
