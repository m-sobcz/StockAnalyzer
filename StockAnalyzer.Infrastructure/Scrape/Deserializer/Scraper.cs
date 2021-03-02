using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Net;

namespace StockAnalyzer.Infrastructure.Scrape.Deserializer
{
    public class Scraper<TRawData> : IDeserializer<TRawData> where TRawData : IRawData
    {
        readonly IDataExtractor<TRawData> dataExtractor;
        private IDataExtractorFactory<StockRawData> factory;
        private string config;

        protected static IDataExtractor<TRawData> CreateDataExtractor(IDataExtractorFactory<TRawData> factory, ScraperConfig scrapeConfig)
        {
            IDataExtractor<TRawData> dataExtractor = factory.BuildFromConfig(scrapeConfig.ConfigName);
            return dataExtractor;
        }

        public Scraper(IDataExtractorFactory<TRawData> factory, ScraperConfig config)
        {
            this.dataExtractor = factory.CreateFromName(config.ConfigName);
        }


        public TRawData Deserialize(string html)
        {
            TRawData scrapedObject = dataExtractor.Extract(html);
            return scrapedObject;
        }

    }
}
