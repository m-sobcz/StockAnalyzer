using Microsoft.EntityFrameworkCore;
using StockAnalyzer.Core.StockAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockAnalyzer.Infrastructure.EntityFramework
{

    public class StocksDbContext : DbContext
    {
        public StocksDbContext(DbContextOptions<StocksDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var decimalProperties = modelBuilder.Model.GetEntityTypes()
    .SelectMany(t => t.GetProperties())
    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));
            foreach (var property in decimalProperties)
            {
                property.SetColumnType("decimal(18,2)");
            }
                base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Stock> Stocks { get; set; }

    }
}
