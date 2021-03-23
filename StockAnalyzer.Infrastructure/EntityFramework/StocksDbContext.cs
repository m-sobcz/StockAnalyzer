using Microsoft.EntityFrameworkCore;
using StockAnalyzer.Core.StockAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.EntityFramework
{

    public class StocksDbContext : DbContext
    {
        public StocksDbContext(DbContextOptions<StocksDbContext> options) : base(options) { }

        public virtual DbSet<Stock> Stocks { get; set; }
    }
}
