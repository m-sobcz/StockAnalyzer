using Newtonsoft.Json.Linq;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.Scraper
{
    public interface  IDataExtractor<TRawData>  where TRawData : IRawData
    {

        TRawData Extract(string html);
    }
}
