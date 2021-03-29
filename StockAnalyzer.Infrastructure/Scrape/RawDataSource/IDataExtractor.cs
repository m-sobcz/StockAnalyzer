using StockAnalyzer.Infrastructure.Scrape.RawData;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.Deserializer
{
    public interface IDataExtractor<TRawData> where TRawData : IRawData
    {

        Task<TRawData> Extract(string html);
    }
}
