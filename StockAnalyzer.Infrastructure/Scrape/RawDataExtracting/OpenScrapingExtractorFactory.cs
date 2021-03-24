using OpenScraping.Config;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataExtracting
{
    public class OpenScrapingExtractorFactory<TRawData> : IDataExtractorFactory<TRawData> where TRawData : IRawData
    {
        readonly static string defaultConfigPath = Path.Combine("Scrape", "RawDataExtracting");
        readonly static string jsonExtension = ".json";
        readonly Dictionary<string, string> files = new Dictionary<string, string>();
        public IReadOnlyCollection<string> Names() => files.Keys.ToList().AsReadOnly();
        readonly Func<ConfigSection, IDataExtractor<TRawData>> getDataExtractor;
        public OpenScrapingExtractorFactory(Func<ConfigSection, IDataExtractor<TRawData>> getDataExtractor)
        {
            this.getDataExtractor = getDataExtractor;
            string[] jsonPaths = Directory.GetFiles(defaultConfigPath, "*" + jsonExtension);
            foreach (var jsonPath in jsonPaths)
            {
                string fileContent = File.ReadAllText(jsonPath);
                string fileName = Path.GetFileNameWithoutExtension(jsonPath);
                files.Add(fileName, fileContent);
            }
        }
        public IDataExtractor<TRawData> CreateFromName(string name)
        {
            string jsonConfig = GetByName(name);
            ConfigSection config = StructuredDataConfig.ParseJsonString(jsonConfig);
            IDataExtractor<TRawData> dataExtractor = getDataExtractor(config);
            return dataExtractor;
        }
        public string GetByName(string name)
        {
            bool success = files.TryGetValue(name, out string json);
            if (success == false) throw new ArgumentException("File with specified name doesnt exist in repo !");
            return json ?? "";
        }

    }


}
