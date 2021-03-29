using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StockAnalyzer.Core.Interfaces
{
    //https://riptutorial.com/design-patterns/example/21626/read-only-repositories--csharp-
    public interface IReadOnlyRepository<TKey, TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter=null);

        Task<TEntity> Get(TKey id);

    }
}
