using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
{
    public class HtmlDataSource<TRawData> : IRawDataSource<TRawData> where TRawData:IRawData
    {
        readonly IDeserializer<TRawData> deserializer;
        readonly IHtmlSource htmlSource;
        public HtmlDataSource(IDeserializer<TRawData> deserializer, IHtmlSource htmlSource)
        {
            this.deserializer = deserializer;
            this.htmlSource = htmlSource;
        }
        public TRawData Get()
        {
            string html = htmlSource.GetHtml();
            var rawData = deserializer.Deserialize(html);
            return rawData;
        }
    }
}
