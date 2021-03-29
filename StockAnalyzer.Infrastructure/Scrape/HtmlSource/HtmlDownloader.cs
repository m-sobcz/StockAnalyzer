using Microsoft.Extensions.Options;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.HtmlSource
{
    class HtmlDownloader : IHtmlSource
    {
        public string BaseAdress { get; set; }
        public HtmlDownloader(string baseAdress)
        {
            this.BaseAdress = baseAdress;
        }
        public async Task<string> GetHtml(string adressSuffix="")
        {
            if (BaseAdress is null) throw new InvalidOperationException("Adress is null!");
            using WebClient client = new WebClient();
            string adress = BaseAdress + adressSuffix;
            string html=await client.DownloadStringTaskAsync(new Uri(adress));
            return html;
        }


    }
}
