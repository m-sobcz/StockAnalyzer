using Microsoft.Extensions.Options;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Net;

namespace StockAnalyzer.Infrastructure.Scrape.HtmlSource
{
    class HtmlDownloader : IHtmlSource
    {
        public string BaseAdress { get; set; }
        public HtmlDownloader(string baseAdress)
        {
            this.BaseAdress = baseAdress;
        }
        public string GetHtml(string adressSuffix="")
        {
            if (BaseAdress is null) throw new InvalidOperationException("Adress is null!");
            using WebClient client = new WebClient();
            string adress = BaseAdress + adressSuffix;
            string html = client.DownloadString(adress);
            return html;
        }

    }
}
