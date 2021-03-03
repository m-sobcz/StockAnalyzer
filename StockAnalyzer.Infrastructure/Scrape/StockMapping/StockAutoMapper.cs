using AutoMapper;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;
using StockAnalyzer.Infrastructure.Utility;

namespace StockAnalyzer.Infrastructure.Scrape.StockMapping
{
    public class StockAutoMapper : IStockMapper
    {
        readonly IMapper mapper;
        public StockAutoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<StockMapProfile>());
            mapper = config.CreateMapper();
        }
        public Stock Map(StockRawData.Row rawDataRow)
        {
            Stock result = mapper.Map<StockRawData.Row, Stock>(rawDataRow);
            return result;
        }
    }
}
