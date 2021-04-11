using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wage.Core.Interfaces.IRepositories
{
    public interface IBaseRepository<TEntity/*,TId*/> where TEntity : class //, IEntityID<TId>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> whereClause);
        Task<List<TEntity>> GetByFilterAsync(params Expression<Func<TEntity, bool>>[] filters);
        Task<TEntity> GetByIdAsync(/*TId id*/ object id);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> whereClause);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> EditAsync(TEntity entity);
        Task<bool> RemoveByIdAsync(/*TId id*/ object id);
        Task<bool> RemoveAsync(TEntity entity);

        Task<bool> IsExists(/*TId id*/ object id);
        Task<bool> IsExists(Expression<Func<TEntity, bool>> whereClause);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities) ;
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
        Task<int> AddOrUpdateAsync(TEntity entity, /*TId id*/ object id);



        /*
                Task<T> UpdateAsync(T entity, params Expression<Func<T, object>>[] updatedProperties);
                Task<bool> IsExists(T item);

                ValueTask<TEntity> GetByIdAsync(int id);
                IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
                Task<IEnumerable<TEntity>> GetAllAsync();
                Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
                Task AddAsync(TEntity entity);
                Task AddRangeAsync(IEnumerable<TEntity> entities);
                void Remove(TEntity entity);
                void RemoveRange(IEnumerable<TEntity> entities);

                */

    }
}
