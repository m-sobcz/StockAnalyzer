using HtmlAgilityPack;
using OpenScraping.Transformations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StockAnalyzer.Infrastructure.Scraping
{
    public class StripSpacesTransform : ITransformationFromObject, ITransformationFromHtml
    {
        private readonly Regex WhiteSpacesRegex = new Regex(@"\s", RegexOptions.Compiled);

        public object Transform(Dictionary<string, object> settings, object input)
        {
            if (input != null && input is string)
            {
                var text = (string)input;
                text = WhiteSpacesRegex.Replace(text, "");
                return text;
            }

            return null;
        }

        public object Transform(Dictionary<string, object> settings, HtmlNodeNavigator nodeNavigator, List<HtmlAgilityPack.HtmlNode> logicalParents)
        {
            var node = nodeNavigator?.CurrentNode;

            if (node != null)
            {
                var text = node.InnerText;

                if (text != null)
                {
                    text = HtmlEntity.DeEntitize(text).Trim();
                    text = WhiteSpacesRegex.Replace(text, "");
                    return text;
                }
            }

            return null;
        }
    }
}
