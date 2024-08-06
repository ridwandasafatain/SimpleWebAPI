using System.Linq.Expressions;
using Web.Domain;

namespace Web.Infrastructure
{
    public interface IBaseRepository<T> where T : BaseEntity
    {        
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> GetQueryable();
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> predicate);
    }
}
