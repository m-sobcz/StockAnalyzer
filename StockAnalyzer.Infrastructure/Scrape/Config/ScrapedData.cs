using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.Config
{
    public class ScrapedData
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
