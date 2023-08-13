using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        #region | Create |
        #endregion

        #region | Read |
        new Task<IEnumerable<Product>> GetAllAsync();
        #endregion

        #region | Update |
        #endregion

        #region | Delete |
        #endregion
    }
}
