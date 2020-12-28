using StockAnalyzer.Core;
using StockAnalyzer.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StockAnalyzer.Infrastructure.Scrape.Repository
{
    public class DomainRepository<TDomain> : IReadOnlyRepository<long, TDomain> where TDomain : BaseEntity
    {
        readonly IEnumerable<TDomain> domains;
        public DomainRepository(IRepositorySource<TDomain> repositorySource)
        {
            domains = repositorySource.Get();
        }
        public IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> filter = null)
        {
            var filtered = filter == null ? domains : domains.Where(filter.Compile());
            return filtered;
        }

        public TDomain Get(long id)
        {
            return domains.Where(x => x.Id == id).FirstOrDefault();
        }


    }
}
