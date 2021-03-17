using AutoMapper;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
//https://docs.automapper.org/en/stable/Custom-type-converters.html
//https://stackoverflow.com/questions/14177455/unit-test-the-automapper-profiles

namespace StockAnalyzer.Infrastructure.Scrape.StockMapping
{
    public class StockMapProfile : Profile
    {
        readonly Regex nameRegex;
        readonly Regex tickerRegex;
        readonly Regex linkRegex;
        public StockMapProfile()
        {
            CreateMap<string, decimal>().ConvertUsing(s => Convert.ToDecimal(s, CultureInfo.InvariantCulture));
            CreateMap<StockRawData.Row, Stock>()
                .ForMember(domain => domain.Name, config => config.MapFrom(data => GetName(data.CombinedName)))
                .ForMember(domain => domain.Ticker, config => config.MapFrom(data => GetTicker(data.CombinedName)))
                .ForMember(domain => domain.Link, config => config.MapFrom(data => GetLink(data.QuotationLink)))
                .ForMember(domain => domain.Id, config => config.Ignore())
                .ForMember(domain => domain.Indexes, config => config.Ignore())
                .ForMember(domain => domain.Statements, config => config.Ignore());
            string namePattern = @"(?<=\()\w+(?=\))";
            nameRegex = new Regex(namePattern);
            string tickerPattern = @"\w+(?=\s*\()";
            tickerRegex = new Regex(tickerPattern);
            string linkPattern = @"(?<=/notowania/).+";
            linkRegex = new Regex(linkPattern);
        }

        string GetName(string fullname)
        {
            var name = nameRegex.Match(fullname).Value;
            return name;
        }
        string GetTicker(string fullname)
        {
            var ticker = tickerRegex.Match(fullname).Value;
            return ticker;
        }
        string GetLink(string quotationLink) 
        {
            var link = linkRegex.Match(quotationLink).Value;
            return link;
        }
    }
}
