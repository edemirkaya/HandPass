using System.Linq.Expressions;
using HandPass.Core.Abstraction.Entity;

namespace HandPass.Core.Abstraction.Repository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetByConditions(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
