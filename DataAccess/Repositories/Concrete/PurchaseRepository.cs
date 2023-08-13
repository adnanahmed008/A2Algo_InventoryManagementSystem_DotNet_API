using Core.Entities;
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
    public class PurchaseRepository : GenericRepository<Purchase>, IPurchaseRepository
    {

        public PurchaseRepository(InventoryDbContext context)
        : base(context)
        {
        }

        #region | Create |
        #endregion

        #region | Read |
        public Task<IEnumerable<Purchase>> GetAllByProductIdAsync(Guid productId)
        {
            return base.GetManyWithIncludeAsync(x => x.ProductId == productId, x => x.Product);
        }

        public new Task<IEnumerable<Purchase>> GetAllAsync()
        {

            return base.GetAllWithIncludeAsync(x => x.Product);
        }
        #endregion

        #region | Update |
        #endregion

        #region | Delete |
        #endregion
    }
}
