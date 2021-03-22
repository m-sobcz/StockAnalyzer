namespace StockAnalyzer.Core.StatementAggregate
{
    public class Balance : Finance
    {
        public decimal NoncurrentAssets { get; set; }
        public decimal IntangibleAssets { get; set; }
        public decimal Goodwill { get; set; }
        public decimal Property { get; set; }
        public decimal RightToUseAssets { get; set; }
        public decimal NoncurrentReceivables { get; set; }
        public decimal NoncurrInvestments { get; set; }
        public decimal OtherNoncurrentAssets { get; set; }
        public decimal CurrentAssets { get; set; }
        public decimal Inventory { get; set; }
        public decimal CurrentReceivables { get; set; }
        public decimal CurrentInvestments { get; set; }
        public decimal Cash { get; set; }
        public decimal OtherCurrentAssets { get; set; }
        public decimal AssetsForSale { get; set; }
        public decimal TotalAssets { get; set; }
        public decimal Capital { get; set; }
        public decimal ShareCapital { get; set; }
        public decimal OwnShares { get; set; }
        public decimal Reserve { get; set; }
        public decimal NonshareCapital { get; set; }
        public decimal NoncurrentLiabilities { get; set; }
        public decimal NoncurrentTradeLiabilities { get; set; }
        public decimal NoncurrentBorrowings { get; set; }
        public decimal NoncurrentObligations { get; set; }
        public decimal NoncurrentLeasing { get; set; }
        public decimal NoncurrentOtherLiabilities { get; set; }
        public decimal CurrentLiabilities { get; set; }
        public decimal CurrentTradePayablesv { get; set; }
        public decimal CurrentBorrowings { get; set; }
        public decimal CurrentObligations { get; set; }
        public decimal CurrentLeasing { get; set; }
        public decimal CurrentOtherLiabilities { get; set; }
        public decimal Reckoning { get; set; }
        public decimal TotalEquityAndLiabilities { get; set; }
        public decimal CashWithCentralBank { get; set; }
        public decimal LoansToBanks { get; set; }
        public decimal FinAssetsForTrading { get; set; }
        public decimal HeldFinancialAssets { get; set; }
        public decimal LoansToCustomers { get; set; }
        public decimal OtherFinAssets { get; set; }
        public decimal InvestInSubsidiaries { get; set; }
        public decimal TaxAssets { get; set; }
        public decimal OtherAssets { get; set; }
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
        public decimal SharePremium { get; set; }
        public decimal RevaluationReserves { get; set; }
        public decimal RetainedReserves { get; set; }
        public decimal YearProfit { get; set; }
        public decimal NonControlProfit { get; set; }
        public decimal TotalCapital { get; set; }

    }
}
