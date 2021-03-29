using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.Utility;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
{
    public class HtmlRawDataSource<TRawData> : IRawDataSource<TRawData> where TRawData : IRawData, new()
    {
        readonly IDataExtractor<TRawData> extractor;
        readonly IHtmlSource htmlSource;
        public HtmlRawDataSource(IDataExtractor<TRawData> extractor, IHtmlSource htmlSource)
        {
            this.extractor = extractor;
            this.htmlSource = htmlSource;
        }
        public async Task<TRawData> Get(string param="")
        {
            string html = await htmlSource.GetHtml(param);
            TRawData rawData = await extractor.Extract(html); 
            return rawData;
        }
    }
}
