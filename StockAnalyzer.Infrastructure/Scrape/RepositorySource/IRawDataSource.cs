using StockAnalyzer.Infrastructure.Scrape.RawDataSource;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public interface IRawDataSource<TRawData> where TRawData : IRawData
    {
        TRawData Get();
    }
}
