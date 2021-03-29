using StockAnalyzer.Core.StatementAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public interface IStatementSource
    {
        Task<IEnumerable<Statement>> Get(string param);

    }
}
