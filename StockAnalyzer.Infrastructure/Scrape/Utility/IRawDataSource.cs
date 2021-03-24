using StockAnalyzer.Infrastructure.Scrape.RawData;

namespace StockAnalyzer.Infrastructure.Scrape.Utility
{
    public interface IRawDataSource<TRawData> where TRawData : IRawData
    {
        TRawData Get(string param = "");
    }
}
