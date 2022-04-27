using System.Linq.Expressions;

namespace Services.Shared.Data.Repository
{
    public interface IRepository<T> : IDisposable where T : class, new()
    {
        IRepository<T> Add(T entity);
        IRepository<T> Update(T entity);
        IRepository<T> Delete(Guid entityId);
        T? FirstOrDefault(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAllAsNoTracking();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAllAsNoTracking(int offset, int limit);
        IEnumerable<T> GetAllAsNoTracking(Expression<Func<T, bool>> predicate, int offset, int limit);
        bool SaveChanges();

    }
}
