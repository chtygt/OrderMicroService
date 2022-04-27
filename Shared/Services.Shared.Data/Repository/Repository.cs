using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Services.Shared.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        protected Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public IRepository<T> Add(T entity)
        {
            _dbSet.Add(entity);
            return this;
        }

        public IRepository<T> Update(T entity)
        {
            _dbSet.Update(entity);
            return this;
        }

        public IRepository<T> Delete(Guid entityId)
        {
            var entity = _dbSet.Find(entityId);
            if (entity != null) _dbSet.Remove(entity);

            return this;
        }

        public T? FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public int Count()
        {
            return _dbSet.Count();
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count(predicate);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAllAsNoTracking()
        {
            return _dbSet.AsNoTracking().AsEnumerable();
        }

        public IEnumerable<T> GetAllAsNoTracking(int offset, int limit)
        {
            return _dbSet.AsNoTracking().Skip(offset).Take(limit).AsEnumerable();
        }
        public IEnumerable<T> GetAllAsNoTracking(Expression<Func<T, bool>> predicate, int offset, int limit)
        {
            return _dbSet.AsNoTracking().Where(predicate).Skip(offset).Take(limit).AsEnumerable();
        }

        public bool SaveChanges()
        {
            try
            {
                foreach (var item in _context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
                {
                    if (item.Properties.Any(x => x.Metadata.Name == "ConcurrencyStamp"))
                        item.Property("ConcurrencyStamp").CurrentValue = Guid.NewGuid();

                    if (item.Properties.Any(x => x.Metadata.Name == "UpdateDate"))
                        item.Property("UpdateDate").CurrentValue = DateTime.UtcNow;
                }
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new DbUpdateConcurrencyException("Güncellemeye çalıştığınız bilgiler daha önce başkası tarafından güncellenmiş. Lütfen kontrol edin.");
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
