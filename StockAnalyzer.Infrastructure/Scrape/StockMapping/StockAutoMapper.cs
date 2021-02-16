using AutoMapper;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;
using StockAnalyzer.Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.StockMapping
{
    public class StockAutoMapper : IStockMapper
    {
        readonly IMapper mapper;
        public StockAutoMapper(IFactory<IMapper> mapperFactory)
        {
            this.mapper = mapperFactory.Create();
        }
        public Stock Map(StockRawData.Row rawDataRow)
        {
            Stock result = mapper.Map<StockRawData.Row, Stock>(rawDataRow);
            return result;
        }
    }
}
