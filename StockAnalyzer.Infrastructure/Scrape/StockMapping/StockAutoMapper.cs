using AutoMapper;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.StockMapping
{
    public class StockAutoMapper : IStockMapper
    {
        readonly IMapper mapper;
        public StockAutoMapper()
        {
            IConfigurationProvider config = new MapperConfiguration(cfg => cfg.AddProfile<StockMapProfile>());
            IMapper mapper = config.CreateMapper();
        }
        public Stock Map(StockRawData.Row rawDataRow)
        {
            Stock result = mapper.Map<StockRawData.Row, Stock>(rawDataRow);
            return result;
        }
    }
}
