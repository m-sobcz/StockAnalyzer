using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public interface IStockMapper
    {
        Stock Map(StockRawData.Row rawDataRow);
    }
}
