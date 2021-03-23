using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockAnalyzer.Infrastructure.EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StocksDbContext>
    {
        public StocksDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../StockAnalyzer.Console/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<StocksDbContext>();
            var connectionString = configuration.GetConnectionString("LocalConnection");
            builder.UseSqlServer(connectionString);
            return new StocksDbContext(builder.Options);
        }
    }
}
