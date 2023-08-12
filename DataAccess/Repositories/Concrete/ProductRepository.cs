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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        public ProductRepository(InventoryDbContext context)
        : base(context)
        {
        }

        #region | Create |
        public new Task<IEnumerable<Product>> GetAllAsync() {

            return base.GetAllWithIncludeAsync(x => x.Sales, x => x.Purchases);
        }
        #endregion

        #region | Read |
        #endregion

        #region | Update |
        #endregion

        #region | Delete |
        #endregion
    }
}
