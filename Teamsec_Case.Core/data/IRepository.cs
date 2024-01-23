using System;
using System.Linq;
using System.Linq.Expressions;

namespace Teamsec_Case.Core
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);
        void Remove(int id);
        void Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity Find(int id);
        IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter);
        IQueryable GetSqlRawQuery(string query);
        void Save();
    }
}
