using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Shared;

namespace Servicio.Datos.Repository
{
    public class BaseRepository<TEntity>  : IBaseRepository<TEntity> where TEntity : class 
    {
        internal DbSet<TEntity> dbSet;

        public BaseRepository()
        {
            this.dbSet =  ServicesContext._context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query).ToList();            
            
            return query.ToList();
        }

        public virtual IQueryable<TEntity> GetQueryList(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query);            
            
            return query;
        }

        public virtual TEntity GetById(object id)
        {
            return ServicesContext._context.Find<TEntity>(id);
        }
        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await ServicesContext._context.FindAsync<TEntity>(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
           return ServicesContext._context.Set<TEntity>().Where(expression);
        }
        
        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void AddAsync(TEntity entity)
        {
            dbSet.AddAsync(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            dbSet.AddRange(entity);
        }

        public virtual void AddRangeAsync(IEnumerable<TEntity> entity)
        {
            dbSet.AddRangeAsync(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (ServicesContext._context.Entry(entityToDelete).State == EntityState.Detached)
                dbSet.Attach(entityToDelete);

            dbSet.Remove(entityToDelete);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entitiesToDelete)
        {
            dbSet.RemoveRange(entitiesToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            ServicesContext._context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public int Save()
        {
            return ServicesContext._context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await ServicesContext._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            ServicesContext._context.Dispose();
        }

         public void BeginTransaction()
        {
            ServicesContext._context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            ServicesContext._context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            ServicesContext._context.Database.RollbackTransaction();
        }

        public void DisposeTransaction()
        {
            ServicesContext._context.Database.CurrentTransaction.Dispose();
        }
    }
}