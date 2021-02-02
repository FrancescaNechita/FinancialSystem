using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FinancialSystem.Domain.Base
{
    public interface IBaseRepository<T> where T : IBaseEntity
    {
        T GetById(int id);
        IReadOnlyCollection<T> GetAll();
        IReadOnlyCollection<T> Filter(Expression<Func<T, bool>> predicate,
            IEnumerable<Expression<Func<T, object>>> includeProperties = null);
        T Insert(T entity);
        void Update(T entity);
        void Save();
    }
}