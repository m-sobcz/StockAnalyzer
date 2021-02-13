using HtmlAgilityPack;
using OpenScraping.Transformations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataExtracting
{
    class RegexValueRemoveTransform : ITransformationFromHtml
    {
        static readonly Dictionary<string, Regex> regexes = new Dictionary<string, Regex>();
        Regex regex;
        string regexPattern;
        int? maxCount;
        Dictionary<string, object> settings;
        public object Transform(Dictionary<string, object> settings, HtmlNodeNavigator nodeNavigator, List<HtmlNode> logicalParents)
        {
            string text = nodeNavigator?.Value;
            if (text != null)
            {
                this.settings = settings;
                LoadSettings();
                text = HtmlEntity.DeEntitize(text).Trim();
                return RemovePatternsFromText(text);
            }
            return null;
        }

        void LoadSettings()
        {
            LoadRegexSetting();
            LoadMaxCountSettings();
        }
        void LoadRegexSetting()
        {
            if (!settings.TryGetValue("_regex", out object regexPatternObj))
            {
                throw new ArgumentException("Could not find a _regex setting");
            }
            regexPattern = regexPatternObj.ToString();
        }
        void LoadMaxCountSettings()
        {
            if (settings.TryGetValue("_maxCount", out object maxCountObj))
            {
                try
                {
                    maxCount = int.Parse(maxCountObj.ToString());
                }
                catch (Exception)
                {
                    throw new ArgumentException("_maxCount setting non parsable to int");
                }
            }
            else
            {
                maxCount = null;
            }
        }
        string RemovePatternsFromText(in string inText)
        {
            if (!regexes.TryGetValue(regexPattern, out regex))
            {
                regex = new Regex(regexPattern, RegexOptions.Compiled);
                regexes.Add(regexPattern, regex);
            }
            string outText = maxCount.HasValue ? regex.Replace(inText, string.Empty, maxCount.Value) : regex.Replace(inText, string.Empty);
            return outText;
        }
    }
}
