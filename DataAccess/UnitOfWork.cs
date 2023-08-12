using Core.Entities;
using DataAccess.Repositories.Concrete;
using DataAccess.Repositories.Interfaces;
//using DataAccess.Repositories.Concrete;
//using DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;

        public IPurchaseRepository Purchases { get; private set; }
        public ISaleRepository Sales { get; private set; }
        public IProductRepository Products { get; private set; }

        public UnitOfWork(InventoryDbContext context)
        {
            _context = context;

            InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            Purchases = new PurchaseRepository(_context);
            Sales = new SaleRepository(_context);
            Products = new ProductRepository(_context);
        }

        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
