using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Servicio.Datos.Repository
{
    public interface IBaseRepository <T> where T : class
    {
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                string includeProperties = "");
        IQueryable<T> GetQueryList(Expression<Func<T, bool>> filter = null,
                                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                string includeProperties = "");                                              
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        void AddRangeAsync(IEnumerable<T> entity);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        int Save();
        Task<int> SaveAsync();
    }
}