namespace StockAnalyzer.Core.StatementAggregate
{
    public class Cashflow : Finance
    {
        public decimal OperatingCashflow { get; set; }
        public decimal Amortization { get; set; }
        public decimal InvestingCashflow { get; set; }
        public decimal Capex { get; set; }
        public decimal FinancingCashflow { get; set; }
        public decimal ShareCapitalCash { get; set; }
        public decimal Dividend { get; set; }
        public decimal StockBuyback { get; set; }
        public decimal NetCashflow { get; set; }
        public decimal FCM { get; set; }
    }
}
