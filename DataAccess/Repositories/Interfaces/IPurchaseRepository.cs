﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IPurchaseRepository : IGenericRepository<Purchase>
    {
        #region | Create |
        #endregion

        #region | Read |
        Task<IEnumerable<Purchase>> GetAllByProductIdAsync(Guid productId);
        new Task<IEnumerable<Purchase>> GetAllAsync();
        #endregion

        #region | Update |
        #endregion

        #region | Delete |
        #endregion
    }
}
