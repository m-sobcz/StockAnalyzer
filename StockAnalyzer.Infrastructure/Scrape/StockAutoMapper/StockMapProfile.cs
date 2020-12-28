using AutoMapper;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
//https://docs.automapper.org/en/stable/Custom-type-converters.html
//https://stackoverflow.com/questions/14177455/unit-test-the-automapper-profiles

namespace StockAnalyzer.Infrastructure.Scrape.StockAutoMapper
{
    public class StockMapProfile : Profile
    {
        readonly Regex nameRegex;
        readonly Regex tickerRegex;
        public StockMapProfile()
        {
            CreateMap<StockRawData.Row, Stock>()
                .ForMember(domain => domain.Name, config => config.MapFrom(data => GetName(data.CombinedName)))
                .ForMember(domain => domain.Ticker, config => config.MapFrom(data => GetTicker(data.CombinedName)))
                .ForMember(domain => domain.Id, config => config.Ignore())
                .ForMember(domain => domain.Indexes, config => config.Ignore());
            string namePattern = @"(?<=\()\w+(?=\))";
            nameRegex = new Regex(namePattern);
            string tickerPattern = @"\w+(?=\s*\()";
            tickerRegex = new Regex(tickerPattern);
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
    }
}
