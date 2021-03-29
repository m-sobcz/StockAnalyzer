using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.Repository
{
    public interface IRepositorySource<TDomain>
    {
        Task<IEnumerable<TDomain>> Get();
    }
}
