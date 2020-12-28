using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.DataSource
{
    public interface ISerializer<T>
    {
        string Serialize(T obj);
    }
}
