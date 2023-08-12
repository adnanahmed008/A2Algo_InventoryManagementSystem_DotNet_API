using Core.Entities;
using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        IPurchaseRepository Purchases { get; }
        ISaleRepository Sales { get; }
        IProductRepository Products { get; }

        Task<int> SaveAsync();
    }
}
