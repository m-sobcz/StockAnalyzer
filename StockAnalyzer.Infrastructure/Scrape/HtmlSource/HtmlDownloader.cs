using Microsoft.Extensions.Options;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System.Net;

namespace StockAnalyzer.Infrastructure.Scrape.HtmlSource
{
    class HtmlDownloader : IHtmlSource
    {
        readonly string adress;
        public HtmlDownloader(string adress)
        {
            this.adress = adress;
        }
        public string GetHtml()
        {
            using WebClient client = new WebClient();
            string html = client.DownloadString(adress);
            return html;
        }

    }
}
