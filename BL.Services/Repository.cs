using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BL.Interfaces;
using Domain;

namespace BL.Services
{
    public class Repository : IRepository
    {
        private EFDbContext context;

        public Repository()
        {
            context = new EFDbContext();
        }
        public IQueryable<TEntity> Select<TEntity>() where TEntity : class
        {
            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
            return context.Set<TEntity>();
        }

        public void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
            context.Entry<TEntity>(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        private bool disposedValue = false; 
        public virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
