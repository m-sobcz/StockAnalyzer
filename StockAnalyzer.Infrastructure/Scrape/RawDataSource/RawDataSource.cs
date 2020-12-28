using StockAnalyzer.Infrastructure.Scrape.DataSource;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
{
    public class RawDataSource : IRawDataSource<StockRawData>
    {
        readonly IDeserializer<StockRawData> deserializer;
        readonly IHtmlSource htmlSource;
        public RawDataSource(IDeserializer<StockRawData> deserializer, IHtmlSource htmlSource)
        {
            this.deserializer = deserializer;
            this.htmlSource = htmlSource;
        }
        public StockRawData Get()
        {
            string html = htmlSource.GetHtml();
            var rawData = deserializer.Deserialize(html);
            return rawData;
        }
    }
}
