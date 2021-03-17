using StockAnalyzer.Core.StatementAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public interface IStatementSource
    {
        IEnumerable<Statement> Get(string param);

    }
}
