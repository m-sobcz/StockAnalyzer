using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
{
    public interface IHtmlSource
    {
        string GetHtml();
    }
}
