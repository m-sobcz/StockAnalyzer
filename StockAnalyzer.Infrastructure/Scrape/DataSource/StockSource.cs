using StockAnalyzer.Core;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.DataSource
{
    public class StockSource : IRepositorySource<Stock>
    {
        readonly IStockMapper mapper;
        readonly StockRawData stockRawData;
        public StockSource(IStockMapper mapper, StockRawData stockRawData)
        {
            this.mapper = mapper;
            this.stockRawData = stockRawData;
        }

        public IEnumerable<Stock> Get()
        {
            var stocks = new List<Stock>();
            foreach (var row in stockRawData.Rows)
            {
                var stock = mapper.Map(row);
                stocks.Add(stock);
            }
            return stocks;
        }
    }
}
