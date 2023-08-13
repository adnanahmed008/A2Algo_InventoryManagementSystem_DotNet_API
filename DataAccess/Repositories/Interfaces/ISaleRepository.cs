using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface ISaleRepository : IGenericRepository<Sale>
    {
        #region | Create |
        #endregion

        #region | Read |
        Task<IEnumerable<Sale>> GetAllByProductIdAsync(Guid productId);
        new Task<IEnumerable<Sale>> GetAllAsync();
        #endregion

        #region | Update |
        #endregion

        #region | Delete |
        #endregion
    }
}
