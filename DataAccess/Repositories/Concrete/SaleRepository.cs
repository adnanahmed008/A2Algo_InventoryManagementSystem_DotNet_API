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
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {

        public SaleRepository(InventoryDbContext context)
        : base(context)
        {
        }

        #region | Create |
        #endregion

        #region | Read |
        #endregion

        #region | Update |
        #endregion

        #region | Delete |
        #endregion
    }
}
