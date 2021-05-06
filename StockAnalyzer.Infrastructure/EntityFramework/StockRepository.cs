using Microsoft.EntityFrameworkCore;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StockAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.EntityFramework
{
    public class StockRepository : IRepository<long, Stock>
    {
        private readonly StocksDbContext dbContext;

        public StockRepository(StocksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public long Add(Stock entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stock> Get(Expression<Func<Stock, bool>> filter = null)
        {
            //Expression<Func<Stock, Stock>> selector=x=> new Stock{x.Name, x.Ticker};
            //var queryables = dbContext.Stocks.Select(x => new { x.Ticker });
            var stocks = dbContext.Stocks;
            IEnumerable<Stock> filtered = filter == null ? stocks : stocks.Where(filter.Compile());
            return filtered;
        }

        public Stock Get(long id)
        {
            throw new NotImplementedException();
        }

        public Stock Update(long id, Stock entity)
        {
            throw new NotImplementedException();
        }
    }
}
