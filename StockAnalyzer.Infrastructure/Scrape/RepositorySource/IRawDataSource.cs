using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public interface IRawDataSource<TRawData> where TRawData : IRawData
    {
        TRawData Get();
    }
}
