using Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) => RepositoryContext = repositoryContext;

        IQueryable<T> IRepositoryBase<T>.FindAll(bool trackChanges) =>
            !trackChanges ?
            RepositoryContext.Set<T>()
            .AsNoTracking() :
            RepositoryContext.Set<T>();

        IQueryable<T> IRepositoryBase<T>.FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            RepositoryContext.Set<T>()
            .Where(expression)
            .AsNoTracking() :
            RepositoryContext.Set<T>()
            .Where(expression);

        void IRepositoryBase<T>.Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        void IRepositoryBase<T>.Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        void IRepositoryBase<T>.Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
    }
}
