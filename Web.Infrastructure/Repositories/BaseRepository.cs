using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web.Domain;

namespace Web.Infrastructure
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public T Add(T entity)
        {
            entity.CreatedBy = entity.CreatedBy;
            entity.CreatedAt = DateTime.Now;
            entity.ModifiedBy = null;
            entity.ModifiedAt = null;
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }
       
        public void Update(T entity)
        {
            entity.ModifiedBy = entity.ModifiedBy;
            entity.ModifiedAt = DateTime.Now;
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().AsNoTracking().Where(predicate);
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }
    }
}
