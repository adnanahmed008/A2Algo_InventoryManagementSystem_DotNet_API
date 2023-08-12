using Core.Entities;
using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class, IEntityDefaults
    {
        #region | Create |
        Task<T> InsertAsync(T entity);
        #endregion

        #region | Read |
        Task<T?> GetAsync(Guid id);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetLastAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllWithIncludeAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetManyWithIncludeAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        #endregion

        #region | Update |
        void Update(T entity);
        #endregion

        #region | Delete |
        Task DeleteAsync(Guid id);
        void Delete(T entity);
        void Delete(Func<T, bool> predicate);
        #endregion
    }
}
