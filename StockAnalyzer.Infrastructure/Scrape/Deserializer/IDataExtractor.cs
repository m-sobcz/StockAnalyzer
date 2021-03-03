using StockAnalyzer.Infrastructure.Scrape.RawDataSource;

namespace StockAnalyzer.Infrastructure.Scrape.Deserializer
{
    public interface IDataExtractor<TRawData> where TRawData : IRawData
    {

        TRawData Extract(string html);
    }
}
