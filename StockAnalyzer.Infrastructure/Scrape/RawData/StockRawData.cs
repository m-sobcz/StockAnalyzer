using System.Collections.Generic;

namespace StockAnalyzer.Infrastructure.Scrape.RawData
{
    public class StockRawData : IRawData
    {
        public List<Row> Rows { get; set; }
        public class Row
        {
            public string CombinedName { get; set; }
            public string QuotationLink { get; set; }
            public string UpdateTime { get; set; }
            public string ActualPrice { get; set; }
            public string OpeningPrice { get; set; }
            public string MinPrice { get; set; }
            public string MaxPrice { get; set; }
            public string Volume { get; set; }
            public string Turnover { get; set; }
        }
    }
}