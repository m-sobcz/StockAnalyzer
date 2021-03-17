using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
{
    public class HtmlDataSource<TRawData> : IRawDataSource<TRawData> where TRawData : IRawData
    {
        readonly IDataExtractor<TRawData> extractor;
        readonly IHtmlSource htmlSource;
        public HtmlDataSource(IDataExtractor<TRawData> extractor, IHtmlSource htmlSource)
        {
            this.extractor = extractor;
            this.htmlSource = htmlSource;
        }
        public TRawData Get(string param="")
        {
            string html = htmlSource.GetHtml(param);
            var rawData = extractor.Extract(html);
            return rawData;
        }
    }
}
