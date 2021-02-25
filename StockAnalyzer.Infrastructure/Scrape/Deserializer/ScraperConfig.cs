using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.Deserializer
{
    public class ScraperConfig
    {
        public string ConfigName { get; protected set; }
        public ScraperConfig(string configName)
        {
            this.ConfigName = configName;
        }
    }
}
