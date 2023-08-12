using Core.Entities;
using Core.Entities.Common;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntityDefaults
    {
        protected readonly InventoryDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(InventoryDbContext context)
        {
            this._context = context;
            _dbSet = this._context.Set<T>();
        }

        #region | Create |
        public async Task<T> InsertAsync(T entity)
        {
            //entity.AddLog();
            return (await _dbSet.AddAsync(entity)).Entity;
        }
        #endregion

        #region | Read |
        public async Task<T?> GetAsync(Guid id)
        {
            T? entity = await _dbSet.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return null;

            return entity;
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            T? entity = await _dbSet.FirstOrDefaultAsync(predicate: predicate);
            if (entity == null || entity.IsDeleted)
                return null;

            return entity;
        }

        public async Task<T?> GetLastAsync(Expression<Func<T, bool>> predicate)
        {
            T? entity = await _dbSet.Where(predicate).LastOrDefaultAsync();
            if (entity == null || entity.IsDeleted)
                return null;

            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetManyWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).ToListAsync();
        }
        #endregion

        #region | Update |
        public void Update(T entity)
        {
            //entity.UpdateLog();
            _context.Entry(entity).State = EntityState.Modified;
        }
        #endregion

        #region | Delete |
        public async Task DeleteAsync(Guid id)
        {
            T? entity = await GetAsync(id);

            if (entity == null || entity.IsDeleted)
                return;

            entity.IsDeleted = true;
            //entity.UpdateLog();
            Update(entity);
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            entity.IsDeleted = true;
            //entity.UpdateLog();
            Update(entity);
        }

        public void Delete(Func<T, bool> predicate)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(predicate).AsEnumerable();

            foreach (T obj in objects)
            {
                obj.IsDeleted = true;
                Update(obj);
            }
        }
        #endregion
    }
}
