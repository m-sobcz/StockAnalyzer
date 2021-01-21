using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Net;

namespace StockAnalyzer.Infrastructure.Scrape.Deserializer
{
    public class Scraper<TRawData> : IDeserializer<TRawData> where TRawData : IRawData
    {
        readonly IDataExtractor<TRawData> dataExtractor;
        protected static IDataExtractor<TRawData> CreateDataExtractor(IDataExtractorFactory<TRawData> factory, ScrapeConfig scrapeConfig)
        {
            IDataExtractor<TRawData> dataExtractor = factory.Create(scrapeConfig);
            return dataExtractor;
        }

        public Scraper(IDataExtractor<TRawData> dataExtractor)
        {
            this.dataExtractor = dataExtractor;
        }

        public TRawData Deserialize(string html)
        {
            TRawData scrapedObject = dataExtractor.Extract(html);
            return scrapedObject;
        }

    }
}
