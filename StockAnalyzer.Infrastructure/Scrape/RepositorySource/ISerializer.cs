using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public interface ISerializer<T>
    {
        string Serialize(T obj);
    }
}
