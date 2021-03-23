using Microsoft.EntityFrameworkCore;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StockAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.EntityFramework
{
    public class DataSetter
    {
        StocksDbContext dbContext;
        IReadOnlyRepository<long, Stock> stockRepository;
        public DataSetter(StocksDbContext dbContext, IReadOnlyRepository<long, Stock> stockRepository)
        {
            this.dbContext = dbContext;
            this.stockRepository = stockRepository;
        }
        public void Reload() 
        {
            dbContext.Stocks.RemoveRange(dbContext.Stocks);
            var data = stockRepository.Get();
            dbContext.Stocks.AddRange(data);
            var rowsChanged=dbContext.SaveChanges();
        }
    }
}
