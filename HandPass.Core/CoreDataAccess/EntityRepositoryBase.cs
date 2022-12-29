using HandPass.Core.Abstraction.Entity;
using HandPass.Core.Abstraction.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HandPass.Core.CoreDataAccess
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var result = context.Entry(entity);
                result.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var result = context.Remove(entity);
                result.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public TEntity GetByConditions(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).FirstOrDefault();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var result = context.Update(entity);
                result.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
