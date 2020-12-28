using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StockAnalyzer.Core.Interfaces
{

    //https://foreverframe.net/when-use-include-with-entity-framework/
    // https://codewithshadman.com/repository-pattern-csharp/
    public interface IRepository<TKey, TEntity> : IReadOnlyRepository<TKey, TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        TKey Add(TEntity entity);

        bool Delete(TKey id);

        TEntity Update(TKey id, TEntity entity);
    }
}
