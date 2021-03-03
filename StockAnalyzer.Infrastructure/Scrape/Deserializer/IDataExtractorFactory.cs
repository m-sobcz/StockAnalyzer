using StockAnalyzer.Infrastructure.Scrape.RawDataSource;

namespace StockAnalyzer.Infrastructure.Scrape.Deserializer
{
    public interface IDataExtractorFactory<TRawData> where TRawData : IRawData
    {
        IDataExtractor<TRawData> CreateFromName(string scrapeConfig);
    }
}
