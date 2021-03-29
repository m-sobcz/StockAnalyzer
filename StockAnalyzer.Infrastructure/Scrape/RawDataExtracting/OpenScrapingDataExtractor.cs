using OpenScraping;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataExtracting
{
    public class OpenScrapingDataExtractor<TRawData> : IDataExtractor<TRawData> where TRawData : IRawData
    {
        readonly StructuredDataExtractor dataExtractor;
        public OpenScrapingDataExtractor(StructuredDataExtractor dataExtractor)
        {
            this.dataExtractor = dataExtractor;
        }
        public async Task<TRawData> Extract(string html)
        {
            var extractedData = await Task.Run(() => dataExtractor.Extract(html));
            var rawData = extractedData.ToObject<TRawData>();
            return rawData;
        }
    }
}
