using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Servicio.Datos.Repository
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        /// <summary>
        /// Iniciar transaccion del context
        /// </summary>
        /// <returns></returns>
        void BeginTransaction();

        /// <summary>
        /// Aplicar transaccion del context
        /// </summary>
        /// <returns></returns>
        void CommitTransaction();

        /// <summary>
        /// Aplicar rollback a la transaccion del context
        /// </summary>
        /// <returns></returns>
        void RollbackTransaction();

        /// <summary>
        /// Destruir transaccion del context
        /// </summary>
        /// <returns></returns>
        void DisposeTransaction();

        /// <summary>
        /// Consultar datos a la base de datos sin cargar en memmoria
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryList(Expression<Func<TEntity, bool>> filter = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                string includeProperties = "");                                              
        /// <summary>
        /// Permite agregar multiples entidades del tipo <see cref="TEntity"/>
        /// </summary>
        /// <param name="elements">Listado de entidades</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        bool AddByRange(IEnumerable<TEntity> elements);

        /// <summary>
        /// Permite agregar multiples entidades del tipo <see cref="TEntity"/> de forma asíncrona
        /// </summary>
        /// <param name="elements">Listado de entidades</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        Task<bool> AddByRangeAsync(IEnumerable<TEntity> elements);

        /// <summary>
        /// Permite agregar una entidad del tipo <see cref="TEntity"/>
        /// </summary>
        /// <param name="element">Entidad a agregar</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        bool AddEntity(TEntity element);

        /// <summary>
        /// Permite agregar una entidad del tipo <see cref="TEntity"/> de forma asíncrona
        /// </summary>
        /// <param name="element">Entidad a agregar</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        Task<bool> AddEntityAsync(TEntity element);

        /// <summary>
        /// Indica si todos los elementos satisfacen la condición especificada en <paramref name="predicate"/>
        /// </summary>
        /// <param name="predicate">Condición a evaluar</param>
        /// <returns>Indicador si los elementos satisfacen o no la condición</returns>
        bool All(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Indica si todos los elementos satisfacen la condición especificada en <paramref name="predicate"/> de forma asíncrona
        /// </summary>
        /// <param name="predicate">Condición a evaluar</param>
        /// <returns>Indicador si los elementos satisfacen o no la condición</returns>
        Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Determina si alguno de los elementos satisface la condición especificada en <paramref name="predicate"/>. Si no se indica una condición, verifica si existe algún elemento
        /// </summary>
        /// <param name="predicate">Condición a evaluar</param>
        /// <returns>Indica si alguno de los elementos satisface la condición o si existe algún elemento</returns>
        bool Any(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Determina si alguno de los elementos satisface la condición especificada en <paramref name="predicate"/>. Si no se indica una condición, verifica si existe algún elemento. De forma asíncrona
        /// </summary>
        /// <param name="predicate">Condición a evaluar</param>
        /// <returns>Indica si alguno de los elementos satisface la condición o si existe algún elemento</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Concatena los elementos proporcionados en <paramref name="elements"/>
        /// </summary>
        /// <param name="elements">Listado de elementos</param>
        /// <returns>Entidad con elementos concatenados</returns>
        IEnumerable<TEntity> Concat(IEnumerable<TEntity> elements);

        /// <summary>
        /// Verifica si la secuencia contiene el elemento especificado por <paramref name="element"/>. Opcionalmente se puede indicar un proceso de comparación mediante <paramref name="comparer"/>
        /// </summary>
        /// <param name="element">Elemento a buscar</param>
        /// <param name="comparer">Proceso de comparación personalizado</param>
        /// <returns>Indica si se encontró el elemento o no</returns>
        bool Contains(TEntity element, IEqualityComparer<TEntity> comparer = null);

        /// <summary>
        /// Verifica si la secuencia contiene el elemento especificado por <paramref name="element"/> de forma asíncrona
        /// </summary>
        /// <param name="element">Elemento a buscar</param>
        /// <returns>Indica si se encontró el elemento o no</returns>
        Task<bool> ContainsAsync(TEntity element);

        /// <summary>
        /// Obtiene la cantidad de elementos. Si se especifica una expresión en <paramref name="predicate"/> se evalúa con dicha expresión
        /// </summary>
        /// <param name="predicate">Condición de evaluación</param>
        /// <returns>Cantidad de elementos en la secuencia</returns>
        int Count(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Obtiene la cantidad de elementos. Si se especifica una expresión en <paramref name="predicate"/> se evalúa con dicha expresión. Método asíncrono
        /// </summary>
        /// <param name="predicate">Condición de evaluación</param>
        /// <returns>Cantidad de elementos en la secuencia</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Retorna los distintos elementos de la secuencia. Opcionalmente puede especificarse un proceso de comparación mediante <paramref name="comparer"/>
        /// </summary>
        /// <param name="comparer">Proceso de comparación personalizado</param>
        /// <returns>Listado de elementos distintos de la secuencia</returns>
        IEnumerable<TEntity> Distinct(IEqualityComparer<TEntity> comparer = null);

        /// <summary>
        /// Retorna los distintos elementos de la secuencia condicionados
        /// /// Opcionalmente puede especificarse un proceso de comparación mediante <paramref name="comparer"/>
        /// </summary>
        /// <param name="where">Condición de filtrado</param>
        /// <param name="comparer">Proceso de comparación personalizado</param>
        /// <returns>Listado de elementos distintos de la secuencia</returns>
        IEnumerable<TEntity> Distinct(Expression<Func<TEntity, bool>> where, IEqualityComparer<TEntity> comparer = null);

        /// <summary>
        /// Devuelve el elemento que se encuentre en el índice especificado por <paramref name="index"/> o un valor por defecto.
        /// </summary>
        /// <param name="index">Índice de la secuencia</param>
        /// <returns>Elemento que se encuentr en el índice especificado</returns>
        TEntity ElementAtOrDefault(int index);

        /// <summary>
        /// Permite buscar un elemento por sus campos claves
        /// </summary>
        /// <param name="keys">Listado de valores para los campos clave</param>
        /// <returns>Entidad según criterio de búsqueda</returns>
        TEntity Find(params object[] keys);

        /// <summary>
        /// Permite buscar un elemento por sus campos claves de forma asíncrona
        /// </summary>
        /// <param name="keys">Listado de valores para los campos clave</param>
        /// <returns>Entidad según criterio de búsqueda</returns>
        Task<TEntity> FindAsync(params object[] keys);

        /// <summary>
        /// Devuelve el primer elemento de la secuencia. Si se especifica una condición en <paramref name="predicate"/> se utiliza dicho criterio para realizar la búsqueda.
        /// </summary>
        /// <param name="predicate">Criterio de búsqueda</param>
        /// <returns>Primer elemento de la secuencia que cumple las condiciones especificadas</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Devuelve el primer elemento de la secuencia. Si se especifica una condición en <paramref name="predicate"/> se utiliza dicho criterio para realizar la búsqueda. Método asíncrono
        /// </summary>
        /// <param name="predicate">Criterio de búsqueda</param>
        /// <returns>Primer elemento de la secuencia que cumple las condiciones especificadas</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);
       
        /// <summary>
        /// Obtiene un listado de elementos
        /// </summary>
        /// <param name="skip">Condicionar para iniciar a tomar los valores</param>
        /// <param name="take">Condicionar para tomar los valores</param>
        /// <param name="where">Condición de filtrado</param>
        /// <param name="orderBy">Criterio de ordenación</param>
        /// <param name="includes">Criterio de inclusión de datos relacionados</param>
        /// <returns>Listado de elementos</returns>
        List<TEntity> Get(int skip, int take,Expression<Func<TEntity, bool>> where = null, Action<IQueryable<TEntity>> orderBy = null, Action<IQueryable<TEntity>> includes = null);
       
        /// <summary>
        /// Obtiene un listado de elementos
        /// </summary>
        /// <param name="where">Condición de filtrado</param>
        /// <param name="orderBy">Criterio de ordenación</param>
        /// <param name="includes">Criterio de inclusión de datos relacionados</param>
        /// <returns>Listado de elementos</returns>
        List<TEntity> Get(Expression<Func<TEntity, bool>> where = null, Action<IQueryable<TEntity>> orderBy = null, Action<IQueryable<TEntity>> includes = null);
       
        /// <summary>
        /// Obtiene un listado de elementos de forma asíncrona
        /// </summary>
        /// <param name="skip">Condicionar para iniciar a tomar los valores</param>
        /// <param name="take">Condicionar para tomar los valores</param>
        /// <param name="where">Condición de filtrado</param>
        /// <param name="orderBy">Criterio de ordenación</param>
        /// <param name="includes">Criterio de inclusión de datos relacionados</param>
        /// <returns>Listado de elementos</returns>
        Task<List<TEntity>> GetAsync(int skip, int take, Expression<Func<TEntity, bool>> where = null, Action<IQueryable<TEntity>> orderBy = null, Action<IQueryable<TEntity>> includes = null);
       
        /// <summary>
        /// Obtiene un listado de elementos de forma asíncrona
        /// </summary>
        /// <param name="where">Condición de filtrado</param>
        /// <param name="orderBy">Criterio de ordenación</param>
        /// <param name="includes">Criterio de inclusión de datos relacionados</param>
        /// <returns>Listado de elementos</returns>
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where = null, Action<IQueryable<TEntity>> orderBy = null, Action<IQueryable<TEntity>> includes = null);
      
        Task<List<TResult>> GetCustomObjectAsync<TResult>(Expression<Func<TEntity, TResult>> select = null, Expression<Func<TEntity, bool>> where = null, Action<IQueryable<TEntity>> orderBy = null, Action<IQueryable<TEntity>> includes = null);

        /// <summary>
        /// Devuelve el último elemento de una secuencia de forma asíncrona
        /// </summary>
        /// <param name="predicate">Criterio de selección</param>
        /// <returns>Último elemento de una secuencia</returns>
        Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Devuelve la cantidad de elementos de una secuencia pero de tipo Long
        /// </summary>
        /// <param name="predicate">Criterio de selección adicional</param>
        /// <returns>Cantidad de elenentos de tipo Long</returns>
        long LongCount(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Devuelve la cantidad de elementos de una secuencia pero de tipo Long de forma asíncrona
        /// </summary>
        /// <param name="predicate">Criterio de selección adicional</param>
        /// <returns>Cantidad de elenentos de tipo Long</returns>
        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Elimina elementos de una secuencia según el criterio de selección especificado
        /// </summary>
        /// <param name="predicate">Criterio de selección</param>
        /// <returns>Indicador de éxito o fallo de la operación, listado de elementos eliminados</returns>
        (bool applied, IEnumerable<TEntity> entities) RemoveByFilter(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Elimina elementos de una secuencia según el criterio de selección especificado de forma asíncrona
        /// </summary>
        /// <param name="predicate">Criterio de selección</param>
        /// <returns>Indicador de éxito o fallo de la operación, listado de elementos eliminados</returns>
        Task<(bool applied, IEnumerable<TEntity> entities)> RemoveByFilterAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Elimina un elemento de una secuencia utilizando sus campos clave
        /// </summary>
        /// <param name="keys">Campos clave de selección</param>
        /// <returns>Indicador de éxito o fallo de la operación, elemento eliminado</returns>
        (bool applied, TEntity entity) RemoveByKeys(params object[] keys);

        /// <summary>
        /// Elimina un elemento de una secuencia utilizando sus campos clave de forma asíncrona
        /// </summary>
        /// <param name="keys">Campos clave de selección</param>
        /// <returns>Indicador de éxito o fallo de la operación, elemento eliminado</returns>
        Task<(bool applied, TEntity entity)> RemoveByKeysAsync(params object[] keys);

        /// <summary>
        /// Remueve un listado de elementos de una secuencia
        /// </summary>
        /// <param name="elements">Listado de elmentos a remover</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        bool RemoveByRange(IEnumerable<TEntity> elements);

        /// <summary>
        /// Remueve un listado de elementos de una secuencia de forma asíncrona
        /// </summary>
        /// <param name="elements">Listado de elmentos a remover</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        Task<bool> RemoveByRangeAsync(IEnumerable<TEntity> elements);

        /// <summary>
        /// Remueve un elemento de una secuencia
        /// </summary>
        /// <param name="element">Elemiento a remover</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        bool RemoveEntity(TEntity element);

        /// <summary>
        /// Remueve un elemento de una secuencia de forma asíncrona
        /// </summary>
        /// <param name="element">Elemiento a remover</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        Task<bool> RemoveEntityAsync(TEntity element);

        /// <summary>
        /// Devuelve un único elemento de la secuencia o null. Si hay más de un elemento, se genera una excepción
        /// </summary>
        /// <param name="predicate">Criterio de selección adicional</param>
        /// <returns>Elemento único de la secuencia</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Devuelve un único elemento de la secuencia o null. Si hay más de un elemento, se genera una excepción. Método asíncrono
        /// </summary>
        /// <param name="predicate">Criterio de selección adicional</param>
        /// <returns>Elemento único de la secuencia</returns>
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// Realiza la actualización de un elemento, recuperando sus datos originales por sus campos claves
        /// </summary>
        /// <param name="data">Datos a actualizar</param>
        /// <param name="keys">Valores de campo clave</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        bool UpdateByKeys(TEntity data, params object[] keys);

        /// <summary>
        /// Realiza la actualización de un elemento, recuperando sus datos originales por sus campos claves de forma asíncrona
        /// </summary>
        /// <param name="data">Datos a actualizar</param>
        /// <param name="keys">Valores de campo clave</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        Task<bool> UpdateByKeysAsync(TEntity data, params object[] keys);

        /// <summary>
        /// Actualiza un listado de elementos
        /// </summary>
        /// <param name="elements">Elementos con datos actualizados</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        bool UpdateByRange(IEnumerable<TEntity> elements);

        /// <summary>
        /// Actualiza un listado de elementos de forma asíncrona
        /// </summary>
        /// <param name="elements">Elementos con datos actualizados</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        Task<bool> UpdateByRangeAsync(IEnumerable<TEntity> elements);

        /// <summary>
        /// Actualiza un elemento 
        /// </summary>
        /// <param name="element">Datos actualizados del elemento</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        bool UpdateEntity(TEntity element);

        /// <summary>
        /// Actualiza un elemento de forma asíncrona
        /// </summary>
        /// <param name="element">Datos actualizados del elemento</param>
        /// <returns>Indicador de éxito o fallo de la operación</returns>
        Task<bool> UpdateEntityAsync(TEntity element);

        /// <summary>
        /// Obtiene  el minimo de un elemento
        /// </summary>
        /// <param name="select">Criterio de campo a ordernar</param>
        /// <param name="where">Condición de filtrado</param>
        /// <returns>Listado de elementos</returns>
        TResult Min<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// Obtiene  el minimo de un elemento
        /// </summary>
        /// <param name="select">Criterio de campo a ordernar</param>
        /// <param name="where">Condición de filtrado</param>
        /// <returns>Listado de elementos</returns>
        Task<TResult> MinAsync<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where = null);
              
        /// <summary>
        /// Obtiene  el maximo de un elemento
        /// </summary>
        /// <param name="select">Criterio de campo a ordernar</param>
        /// <param name="where">Condición de filtrado</param>
        /// <returns>Listado de elementos</returns>
        TResult Max<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where = null);

        /// <summary>
        /// Obtiene  el maximo de un elemento
        /// </summary>
        /// <param name="select">Criterio de campo a ordernar</param>
        /// <param name="where">Condición de filtrado</param>
        /// <returns>Listado de elementos</returns>
        Task<TResult> MaxAsynx<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> where = null);
    }
}