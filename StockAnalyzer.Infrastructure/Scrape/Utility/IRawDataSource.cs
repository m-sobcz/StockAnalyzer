using StockAnalyzer.Infrastructure.Scrape.RawData;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.Utility
{
    public interface IRawDataSource<TRawData> where TRawData : IRawData
    {
        Task<TRawData> Get(string param = "");
    }
}
