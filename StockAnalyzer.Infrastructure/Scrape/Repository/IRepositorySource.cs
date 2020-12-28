using System.Collections.Generic;

namespace StockAnalyzer.Infrastructure.Scrape.Repository
{
    public interface IRepositorySource<TDomain>
    {
        IEnumerable<TDomain> Get();
    }
}
