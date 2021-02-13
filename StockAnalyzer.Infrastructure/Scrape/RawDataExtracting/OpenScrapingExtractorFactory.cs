using OpenScraping;
using OpenScraping.Config;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataExtracting
{
    public class OpenScrapingExtractorFactory<TRawData> : IDataExtractorFactory<TRawData> where TRawData : IRawData
    {
        readonly ConfigRepository configRepository;
        readonly Func<ConfigSection, IDataExtractor<TRawData>> getDataExtractor;
        public OpenScrapingExtractorFactory(Func<ConfigSection, IDataExtractor<TRawData>> getDataExtractor, ConfigRepository configRepository)
        {
            this.configRepository = configRepository;
            this.getDataExtractor = getDataExtractor;
        }
        public IDataExtractor<TRawData> Create(ScrapeConfig scrapeConfig)
        {
            string jsonConfig = configRepository.GetByConfig(scrapeConfig);
            return Create(jsonConfig);
        }

        public IDataExtractor<TRawData> Create(string jsonConfig)
        {
            ConfigSection config = StructuredDataConfig.ParseJsonString(jsonConfig);
            IDataExtractor<TRawData> dataExtractor = getDataExtractor(config);
            return dataExtractor;
        }
    }


}
