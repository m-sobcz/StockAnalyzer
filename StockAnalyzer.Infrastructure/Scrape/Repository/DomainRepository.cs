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
        readonly IRepositorySource<TDomain> repositorySource;
        public DomainRepository(IRepositorySource<TDomain> repositorySource)
        {
            this.repositorySource = repositorySource;
        }
        public IEnumerable<TDomain> Get(Expression<Func<TDomain, bool>> filter = null)
        {
            var domains = repositorySource.Get();
            var filtered = filter == null ? domains : domains.Where(filter.Compile());
            return filtered;
        }

        public TDomain Get(long id)
        {
            var domains = repositorySource.Get();
            return domains.Where(x => x.Id == id).FirstOrDefault();
        }


    }
}
