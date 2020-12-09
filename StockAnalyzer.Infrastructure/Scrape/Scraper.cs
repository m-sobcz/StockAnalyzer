using Newtonsoft.Json.Linq;
using OpenScraping;
using OpenScraping.Config;
using System.Net;

namespace StockAnalyzer.Infrastructure.Scrape
{
    public class Scraper<T>
    {
        string html;
        string jsonConfig;

        public Scraper(string jsonConfig)
        {
            this.jsonConfig = jsonConfig;
        }

        public T Scrape(string html)
        {
            this.html = html;
            JContainer container = GetScrapingResult();
            T scrapedObject = container.ToObject<T>();
            return scrapedObject;
        }
        JContainer GetScrapingResult()
        {
            ConfigSection config = StructuredDataConfig.ParseJsonString(jsonConfig);
            StructuredDataExtractor openScraping = new StructuredDataExtractor(config);
            JContainer scrapingResult = openScraping.Extract(html);
            return scrapingResult;
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
