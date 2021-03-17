using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using System;
using System.Collections.Generic;

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

        public IEnumerable<Stock> Get()
        {
            var stockRawData = stockRawDataSource.Get();
            var stocks = new List<Stock>();
            foreach (var row in stockRawData.Rows)
            {
                var stock = mapper.Map(row);
                Console.WriteLine(@$"Processing {stock.Name}");
                if (stock.Name != null)
                {
                    LoadStatements(stock);
                    stocks.Add(stock);
                }
            }
            return stocks;
        }
        public void LoadStatements(Stock stock)
        {
            var statements = statementSource.Get(stock.Link);
            stock.SetStatements(statements);
        }
    }
}
