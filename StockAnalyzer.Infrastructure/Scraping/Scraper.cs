using Newtonsoft.Json.Linq;
using OpenScraping;
using OpenScraping.Config;
using System.Net;

namespace StockAnalyzer.Infrastructure.Scraping
{
    public class Scraper
    {
        readonly string html;

        public Scraper(string html)
        {
            this.html = html;
        }

        public JContainer GetResults(string jsonConfig)
        {
            ConfigSection config = StructuredDataConfig.ParseJsonString(jsonConfig);
            StructuredDataExtractor openScraping = new StructuredDataExtractor(config);
            JContainer scrapingResults = openScraping.Extract(html);
            return scrapingResults;
        }
        //todo: move to helper class/delete
        public string GetHtmlFromAdress(string address)
        {
            using WebClient client = new WebClient();
            string html = client.DownloadString(address);
            return html;
        }

    }
}
