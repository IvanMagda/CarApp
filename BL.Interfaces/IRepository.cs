using System;
using System.Linq;

namespace BL.Interfaces
{
    public interface IRepository : IDisposable
    {
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        void Insert<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<TEntity> Select<TEntity>() where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
    }
}
