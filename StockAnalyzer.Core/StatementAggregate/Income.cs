namespace StockAnalyzer.Core.StatementAggregate
{
    public class Income : Finance
    {
        public decimal InterestIncome { get; set; }
        public decimal IntrestExpense { get; set; }
        public decimal NetIntrestIncome { get; set; }
        public decimal FeeIncome { get; set; }
        public decimal FeeExpense { get; set; }
        public decimal NetFeeExpense { get; set; }
        public decimal DividendIncome { get; set; }
        public decimal RealisedGains { get; set; }
        public decimal NetOtherFinIncome { get; set; }
        public decimal NetOtherOperatingIncome { get; set; }
        public decimal ImpairmentLosses { get; set; }
        public decimal AdministrationCosts { get; set; }
        public decimal NetOtherOperatingCosts { get; set; }
        public decimal NetoperatingProfit { get; set; }
        public decimal RelatedIncome { get; set; }
        public decimal BeforeTaxProfit { get; set; }
        public decimal DiscontinuedProfit { get; set; }
        public decimal NetProfit { get; set; }
        public decimal ShareholderNetProfit { get; set; }
        public decimal EBITDA { get; set; }

    }
}
