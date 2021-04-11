using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wage.Core.Interfaces.IRepositories;

namespace Wage.Data.Repositories
{
    public abstract class BaseRepository<TEntity/*, TId*/> : IBaseRepository<TEntity/*, TId*/> where TEntity : class //, IEntityID<TId>
    {
        protected readonly WageDbContext Context;

        public BaseRepository(WageDbContext context)
        {
            this.Context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                //throw ex;
                return null;
            }
        }
        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> whereClause)
        {
            try
            {
                return await Context.Set<TEntity>().Where(whereClause).ToListAsync();
            }
            catch (Exception ex)
            {
                //throw ex;
                return null;
            }
        }
        public virtual async Task<List<TEntity>> GetByFilterAsync(params Expression<Func<TEntity, bool>>[] filters)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(/*TId id*/ object id)
        {
            try
            {
                return await Context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                //throw ex;
                return null;
            }
        }
        public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> whereClause)
        {
            try
            {
                var entity = await Context.Set<TEntity>().FirstOrDefaultAsync(whereClause);
                return entity;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex;
            }
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            try
            {
                await Context.Set<TEntity>().AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex;
            }

        }
        public virtual async Task<TEntity> EditAsync(TEntity entity)
        {
            try
            {
                Context.Set<TEntity>().Update(entity);
                //Context.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            catch (Exception ex)
            {
                return null;
                //throw ex;
            }
        }

        public virtual async Task<bool> RemoveByIdAsync(/*TId id*/ object id)
        {
            var res = false;
            try
            {
                var entity = await this.GetByIdAsync(id);
                if (entity != null)
                {
                    Context.Set<TEntity>().Remove(entity);
                    res = true;
                }
                //Context.Entry(entity).State = EntityState.Modified;

            }
            catch (Exception ex)
            {
                //return null;
                //throw ex;
            }
            return res;
        }

        public virtual async Task<bool> RemoveAsync(TEntity entity)
        {
            var res = false;
            try
            {
                Context.Set<TEntity>().Remove(entity);
                res = true;
            }
            catch (Exception ex)
            {
                //return null;
                //throw ex;
            }
            return res;
        }

        public virtual async Task<bool> IsExists(/*TId id*/ object id)
        {
            var res = false;
            try
            {
                res = await Context.Set<TEntity>().FindAsync(id) != null;
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public virtual async Task<bool> IsExists(Expression<Func<TEntity, bool>> whereClause)
        {
            var res = false;
            try
            {
                res = await Context.Set<TEntity>().AnyAsync(whereClause);
            }
            catch (Exception ex)
            {
                //return null;
                //throw ex;
            }
            return res;
        }


        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual async Task<int> AddOrUpdateAsync(TEntity entity, /*TId id*/ object id)
        {
            //1=update
            //x=add  where x>1
            //-1=error in update
            //-2=error in add            
            var res = 0;
            if (decimal.Parse(id.ToString()) > 0 && this.GetByIdAsync(id) != null)
            {
                try
                {
                    Context.Set<TEntity>().Update(entity);
                    res = 1;
                }
                catch (Exception ex)
                {
                    res = -1;
                    //throw ex;
                }
            }
            else
            {
                try
                {
                    await Context.Set<TEntity>().AddAsync(entity);
                    //catch x when savechange is called
                }
                catch (Exception ex)
                {
                    res = -2;
                    //throw ex;
                }
            }
            return res;
        }

      






        //public virtual async Task<TEntity> UpdateAsync(TEntity entity, params Expression<Func<TEntity, object>>[] updatedProperties)
        //{
        //    try
        //    {
        //        //dbEntityEntry.State = EntityState.Modified; --- I cannot do this.

        //        //Ensure only modified fields are updated.
        //        var dbEntityEntry = Context.Entry(entity);
        //        if (updatedProperties.Any())
        //        {
        //            //update explicitly mentioned properties
        //            foreach (var property in updatedProperties)
        //            {
        //                dbEntityEntry.Property(property).IsModified = true;
        //            }
        //        }
        //        else
        //        {
        //            //no items mentioned, so find out the updated entries
        //            foreach (var property in dbEntityEntry.OriginalValues.Properties)
        //            {
        //                var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
        //                var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
        //                if (original != null && !original.Equals(current))
        //                    dbEntityEntry.Property(property).IsModified = true;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //        return null;
        //    }
        //}

        //public bool IsExists(TEntity item)
        //{
        //    throw new NotImplementedException();
        //}


        //public virtual async Task<TEntity> EditAsync(object Id, TEntity entity)
        //{
        //    try
        //    {
        //        if (entity == null || string.IsNullOrEmpty(Id?.ToString())) return null;
        //        TEntity exist = await Context.Set<TEntity>().FindAsync(Id);
        //        if (exist != null)
        //        {
        //            Context.Entry(exist).CurrentValues.SetValues(entity);
        //            //Context.Entry<TEntity>(item).State = EntityState.Modified;
        //            //await Context.SaveChangesAsync();
        //        }
        //        return exist;

        //        //Context.Set<TEntity>().Update(item);
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //        return null;
        //    }

        //}
    }
}