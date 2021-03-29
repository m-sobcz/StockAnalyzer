using StockAnalyzer.Core;
using StockAnalyzer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.Repository
{
    public class DomainRepository<TDomain> : IReadOnlyRepository<long, TDomain> where TDomain : BaseEntity
    {
        readonly IRepositorySource<TDomain> repositorySource;
        public DomainRepository(IRepositorySource<TDomain> repositorySource)
        {
            this.repositorySource = repositorySource;
        }
        public async Task<IEnumerable<TDomain>> Get(Expression<Func<TDomain, bool>> filter = null)
        {
            var domains =  await repositorySource.Get();
            var filtered = filter == null ? domains : domains.Where(filter.Compile());
            return filtered;
        }

        public async Task<TDomain> Get(long id)
        {
            var domains = await repositorySource.Get();
            return domains.Where(x => x.Id == id).FirstOrDefault();
        }


    }
}
