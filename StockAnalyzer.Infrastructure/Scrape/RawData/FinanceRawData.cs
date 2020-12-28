using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RawData
{
    public class FinanceRawData : IRawData
    {
        public List<string> Periods { get; set; }
        public List<Row> Rows { get; set; }
        public class Row
        {
            public string Label { get; set; }
            public string Description { get; set; }
            public List<string> Vals { get; set; }
        }

    }

}
