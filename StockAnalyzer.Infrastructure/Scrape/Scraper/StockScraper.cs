using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.Scraper
{
    public class StockScraper : Scraper<StockRawData>
    {
        public StockScraper(IDataExtractorFactory<StockRawData> dataExtractorFactory) : base(CreateDataExtractor(dataExtractorFactory, ScrapeConfig.Stocks))
        {
        }
        
    }
}
