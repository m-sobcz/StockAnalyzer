using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.HtmlSource
{
    class StocksHtml : HtmlWebClient, IHtmlSource
    {
        public string GetHtml()
        {
            return GetHtmlFromAdress("https://www.biznesradar.pl/gielda/akcje_gpw");
        }

    }
}
