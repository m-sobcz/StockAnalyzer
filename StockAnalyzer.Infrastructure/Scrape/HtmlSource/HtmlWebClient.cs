using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.HtmlSource
{
    public class HtmlWebClient
    {
        //example adress "http://www.java2s.com"
        protected string GetHtmlFromAdress(string address)
        {
            using WebClient client = new WebClient();
            string html = client.DownloadString(address);
            return html;
        }
    }
}
