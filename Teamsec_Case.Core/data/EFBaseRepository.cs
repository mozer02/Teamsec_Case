using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Teamsec_Case.Core
{
    public abstract class EFBaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : Entity where TContext : DbContext

    {

        protected TContext _dbContext;
        protected DbSet<TEntity> _dbSet;

        public EFBaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }


        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual TEntity Find(int Id)
        {
            return _dbSet.Where(x => x.Id == Id && !x.IsDeleted).SingleOrDefault();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.Where(x => !x.IsDeleted).AsNoTracking();
        }

        public virtual IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).Where(x => !x.IsDeleted).AsQueryable();
        }

        public virtual IQueryable GetSqlRawQuery(string query)
        {
            return _dbSet.AsQueryable();
        }

        public virtual void Remove(int Id)
        {
            var entity = Find(Id);
            entity.IsDeleted = true;
            Update(entity);
        }

        public virtual void Save()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
