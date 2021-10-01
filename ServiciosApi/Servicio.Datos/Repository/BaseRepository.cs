using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Servicio.Datos.Context;
using Servicio.Datos.Shared;
using Servicio.Entidad.interfaces;

namespace Servicio.Datos.Repository
{
    public class BaseRepository<TEntity>  : IBaseRepository<TEntity> where TEntity : class , IEntity
    {
        internal ApplicationDbContext _db;
        internal DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            this._db =  context;
            this._dbSet =  this._db.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetQueryList(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query);            
            
            return query;
        }
 
        public void Dispose()
        {
            _db.Dispose();
        }

         public void BeginTransaction()
        {
            _db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _db.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _db.Database.RollbackTransaction();
        }

        public void DisposeTransaction()
        {
            _db.Database.CurrentTransaction.Dispose();
        }

       public virtual bool AddByRange(IEnumerable<TEntity> elements)
        {
            _dbSet.AddRange(elements);
            return _db.SaveChanges() > 0;
        }

        public virtual async Task<bool> AddByRangeAsync(IEnumerable<TEntity> elements)
        {
            await _dbSet.AddRangeAsync(elements);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual bool AddEntity(TEntity element)
        {
            _dbSet.Add(element);
            return _db.SaveChanges() > 0;
        }

        public virtual async Task<bool> AddEntityAsync(TEntity element)
        {
            await _dbSet.AddAsync(element);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual bool All(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.All(predicate);
        }

        public virtual async Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AllAsync(predicate);
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Any(predicate);
            }
            return _dbSet.Any();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.AnyAsync(predicate);
            }
            return await _dbSet.AnyAsync();
        }

        public virtual IEnumerable<TEntity> Concat(IEnumerable<TEntity> elements)
        {
            return _dbSet.Concat(elements);
        }

        public virtual bool Contains(TEntity element, IEqualityComparer<TEntity> comparer = null)
        {
            if (comparer != null)
            {
                return _dbSet.Contains(element, comparer);
            }
            return _dbSet.Contains(element);
        }

        public virtual async Task<bool> ContainsAsync(TEntity element)
        {
            return await _dbSet.ContainsAsync(element);
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Count(predicate);
            }
            return _dbSet.Count();
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.CountAsync(predicate);
            }
            return await _dbSet.CountAsync();
        }

        public virtual IEnumerable<TEntity> Distinct(IEqualityComparer<TEntity> comparer = null)
        {
            if (comparer != null)
            {
                return _dbSet.Distinct(comparer);
            }
            return _dbSet.Distinct();
        }

        public virtual IEnumerable<TEntity> Distinct(Expression<Func<TEntity, bool>> where, IEqualityComparer<TEntity> comparer = null)
        {
            IQueryable<TEntity> query = _dbSet; 
            if (where != null)
            {
                query = query.Where(where);
            }  
            if (comparer != null)
            {
                return query.Distinct(comparer);
            }
            return query.Distinct();
        }

        public virtual TEntity ElementAtOrDefault(int index)
        {
            return _dbSet.ElementAtOrDefault(index);
        }

        public virtual TEntity Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public virtual async Task<TEntity> FindAsync(params object[] keys)
        {
            return await _dbSet.FindAsync(keys);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.FirstOrDefault(predicate);
            }
            return _dbSet.FirstOrDefault();
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.FirstOrDefaultAsync(predicate);
            }
            return await _dbSet.FirstOrDefaultAsync();
        }

        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Action<IQueryable<TEntity>> orderBy = null, Action<IQueryable<TEntity>> includes = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
            {
                includes.Invoke(query);
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderBy != null)
            {
                orderBy.Invoke(query);
            }
            return query.ToList();
        }

        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null, Action<IQueryable<TEntity>> orderBy = null, Action<IQueryable<TEntity>> includes = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (includes != null)
            {
                includes.Invoke(query);
            }
            if (where != null)
            {
                query = query.Where(where);
            }
            if (orderBy != null)
            {
                orderBy.Invoke(query);
            }
            return await query.ToListAsync();
        }

        public virtual async Task<List<TResult>> GetCustomObjectAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression < Func<TEntity, bool>> where = null, Action<IQueryable<TEntity>> orderBy = null, Action<IQueryable<TEntity>> includes = null)
        {
            IQueryable<TEntity> query = _dbSet;
            IQueryable<TResult> queryResult = new List<TResult>().AsQueryable();

            if (includes != null)
            {
                includes.Invoke(query);
            }
            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderBy != null)
            {
                orderBy.Invoke(query);
            }

            if (select != null)
            {
                queryResult = query.Select(select);
            }

            return await queryResult.ToListAsync();
            
        }

        public virtual async Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.LastOrDefaultAsync(predicate);
            }
            return await _dbSet.LastOrDefaultAsync();
        }

        public virtual long LongCount(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.LongCount(predicate);
            }
            return _dbSet.LongCount();
        }

        public virtual async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.LongCountAsync(predicate);
            }
            return await _dbSet.LongCountAsync();
        }

        public virtual (bool applied, IEnumerable<TEntity> entities) RemoveByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            bool applied = false;
            IEnumerable<TEntity> result = null;

            IEnumerable<TEntity> elements = _dbSet.Where(predicate);
            if (elements != null)
            {
                _dbSet.RemoveRange(elements);
                applied = _db.SaveChanges() > 0;
                result = elements;
            }
            return (applied, result);
        }

        public virtual async Task<(bool applied, IEnumerable<TEntity> entities)> RemoveByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            bool applied = false;
            IEnumerable<TEntity> result = null;

            IEnumerable<TEntity> elements = _dbSet.Where(predicate);
            if (elements != null)
            {
                _dbSet.RemoveRange(elements);
                applied = await _db.SaveChangesAsync() > 0;
                result = elements;
            }
            return (applied, result);
        }

        public virtual (bool applied, TEntity entity) RemoveByKeys(params object[] keys)
        {
            bool applied = false;
            TEntity result = null;

            TEntity element = Find(keys);
            if (element != null)
            {
                _dbSet.Remove(element);
                applied = _db.SaveChanges() > 0;
                result = element;
            }
            return (applied, result);
        }

        public virtual async Task<(bool applied, TEntity entity)> RemoveByKeysAsync(params object[] keys)
        {
            bool applied = false;
            TEntity result = null;

            TEntity element = await FindAsync(keys);
            if (element != null)
            {
                _dbSet.Remove(element);
                applied = await _db.SaveChangesAsync() > 0;
                result = element;
            }
            return (applied, result);
        }

        public virtual bool RemoveByRange(IEnumerable<TEntity> elements)
        {
            if (elements != null && elements.Count() > 0)
            {
                _dbSet.RemoveRange(elements);
            }
            return _db.SaveChanges() > 0;
        }

        public virtual async Task<bool> RemoveByRangeAsync(IEnumerable<TEntity> elements)
        {
            if (elements != null)
            {
                _dbSet.RemoveRange(elements);
            }
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual bool RemoveEntity(TEntity element)
        {
            if (element != null)
            {
                _dbSet.Remove(element);
            }
            return _db.SaveChanges() > 0;
        }

        public virtual async Task<bool> RemoveEntityAsync(TEntity element)
        {
            if (element != null)
            {
                _dbSet.Remove(element);
            }
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Single(predicate);
            }
            return _dbSet.Single();
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await _dbSet.SingleOrDefaultAsync(predicate);
            }
            return await _dbSet.SingleOrDefaultAsync();
        }

        public virtual bool UpdateByKeys(TEntity data, params object[] keys)
        {
            TEntity result = Find(keys);
            if (result != null)
            {
                _db.Entry(result).CurrentValues.SetValues(data);
            }
            return _db.SaveChanges() > 0;
        }

        public virtual async Task<bool> UpdateByKeysAsync(TEntity data, params object[] keys)
        {
            TEntity result = await FindAsync(keys);
            if (result != null)
            {
                _db.Entry(result).CurrentValues.SetValues(data);
            }
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual bool UpdateByRange(IEnumerable<TEntity> elements)
        {
            _dbSet.UpdateRange(elements);
            return _db.SaveChanges() > 0;
        }

        public virtual async Task<bool> UpdateByRangeAsync(IEnumerable<TEntity> elements)
        {
            _dbSet.UpdateRange(elements);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual bool UpdateEntity(TEntity element)
        {
            _dbSet.Update(element);
            return _db.SaveChanges() > 0;
        }

        public virtual async Task<bool> UpdateEntityAsync(TEntity element)
        {
            _dbSet.Update(element);
            return await _db.SaveChangesAsync() > 0;
        }
 
    }
}