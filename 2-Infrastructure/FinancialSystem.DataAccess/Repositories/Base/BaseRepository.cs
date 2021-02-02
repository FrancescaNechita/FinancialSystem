using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FinancialSystem.Common.Exceptions;
using FinancialSystem.DataAccess.Context;
using FinancialSystem.Domain.Base;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FinancialSystem.DataAccess.Repositories.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {
        protected readonly AppDbContext Context;

        protected BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public virtual T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual IReadOnlyCollection<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IReadOnlyCollection<T> Filter(Expression<Func<T, bool>> predicate, IEnumerable<Expression<Func<T, object>>> includeProperties = null)
        {
            var entities = Context.Set<T>().Where(predicate);

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    entities = entities.Include(includeProperty);
                }
            }

            return entities.ToList();
        }

        public T Insert(T entity)
        {
            return TryToExecute(() =>
            {
                var savedEntity = Context.Add(entity);

                return savedEntity.Entity;
            });
        }

        public void Update(T entity)
        {
            TryToExecute(() =>
            {
                Context.Entry(entity).State = EntityState.Modified;
                return entity;
            });
        }

        public void Save()
        {
            TryToExecute(() => Context.SaveChanges());
        }

        protected TResult TryToExecute<TResult>(Func<TResult> function)
        {
            try
            {
                return function();
            }
            catch (DbUpdateException e)
            {
                throw new BadRequestException(ExceptionMessageKeys.BadRequest, e);
            }
            catch (SqlException e)
            {
                if (IsSqlConnectionOpened(e))
                {
                    throw new BadRequestException(ExceptionMessageKeys.BadRequest, e);
                }

                throw;
            }
        }

        private bool IsSqlConnectionOpened(SqlException e)
        {
            return e.Class < 20;
        }
    }
}
