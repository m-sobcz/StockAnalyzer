using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.Deserializer
{
    public interface IDataExtractorFactory<TRawData> where TRawData : IRawData
    {
        IDataExtractor<TRawData> CreateFromName(string scrapeConfig);
        IDataExtractor<TRawData> BuildFromConfig(string scrapeConfig);
    }
}
