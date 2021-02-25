﻿using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataExtracting
{
    public class ConfigRepository
    {
        readonly static string defaultConfigPath = Path.Combine("Scrape", "RawDataExtracting");
        readonly static string jsonExtension = ".json";
        readonly Dictionary<string, string> files = new Dictionary<string, string>();
        public IReadOnlyCollection<string> Names() => files.Keys.ToList().AsReadOnly();

        public ConfigRepository() : this(defaultConfigPath)
        {
        }
        public ConfigRepository(string folderPath)
        {
            string[] jsonPaths = Directory.GetFiles(folderPath, "*" + jsonExtension);
            foreach (var jsonPath in jsonPaths)
            {
                string fileContent = File.ReadAllText(jsonPath);
                string fileName = Path.GetFileNameWithoutExtension(jsonPath);
                files.Add(fileName, fileContent);
            }
        }
        public string GetByName(string name)
        {
            bool success = files.TryGetValue(name, out string json);
            if (success == false) throw new ArgumentException("File with specified name doesnt exist in repo !");
            return json ?? "";
        }
    }
}
