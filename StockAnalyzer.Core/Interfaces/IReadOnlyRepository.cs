using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace StockAnalyzer.Core.Interfaces
{
    //https://riptutorial.com/design-patterns/example/21626/read-only-repositories--csharp-
    public interface IReadOnlyRepository<TKey, TEntity> where TEntity : BaseEntity
    {
            IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

            TEntity Get(TKey id);

    }
}
