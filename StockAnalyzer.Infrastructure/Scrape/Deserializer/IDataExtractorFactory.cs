using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.Deserializer
{
    public interface IDataExtractorFactory<TRawData> where TRawData : IRawData
    {
        IDataExtractor<TRawData> Create(ScrapeConfig scrapeConfig);
        IDataExtractor<TRawData> Create(string scrapeConfig);
    }
}
