using Newtonsoft.Json.Linq;
using OpenScraping;
using OpenScraping.Config;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataExtracting
{
    public class OpenScrapingDataExtractor<TRawData> : IDataExtractor<TRawData> where TRawData : IRawData
    {
        readonly StructuredDataExtractor dataExtractor;
        public OpenScrapingDataExtractor(StructuredDataExtractor dataExtractor)
        {
            this.dataExtractor = dataExtractor;
        }
        public TRawData Extract(string html)
        {
            var extractedData = dataExtractor.Extract(html);
            var rawData = extractedData.ToObject<TRawData>();
            return rawData;
        }
    }
}
