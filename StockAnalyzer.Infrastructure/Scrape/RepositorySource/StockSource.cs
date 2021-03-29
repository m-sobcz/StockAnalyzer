using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using StockAnalyzer.Infrastructure.Scrape.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public class StockSource : IRepositorySource<Stock>
    {
        readonly IStockMapper mapper;
        readonly IRawDataSource<StockRawData> stockRawDataSource;
        readonly IStatementSource statementSource;
        public StockSource(IStockMapper mapper, IRawDataSource<StockRawData> stockRawDataSource, IStatementSource statementSource)
        {
            this.mapper = mapper;
            this.statementSource = statementSource;
            this.stockRawDataSource = stockRawDataSource;
        }

        public async Task<IEnumerable<Stock>> Get()
        {
            var stockRawData = await stockRawDataSource.Get();
            var stocks = new List<Stock>();
            foreach (var row in stockRawData.Rows)
            {
                var stock = ExtractStock(row);
                if (stock != null)
                {
                    await LoadStatements(stock);
                    stocks.Add(stock);
                }
            }
            return stocks;
        }

        Stock ExtractStock(StockRawData.Row row)
        {
            var stock = mapper.Map(row);
            Debug.WriteLine(@$"Extracting stock {stock.Name}");
            return stock.Name != null ? stock : null;
        }
        async Task LoadStatements(Stock stock)
        {
            var statements = await statementSource.Get(stock.Link);
            stock.SetStatements(statements);
        }
    }
}
