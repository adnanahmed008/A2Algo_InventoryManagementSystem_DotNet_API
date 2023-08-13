using Core.Common;
using Core.DTOs;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISaleService
    {
        Task<IEnumerable<SaleReadDTO>> GetAllAsync();
        Task<IEnumerable<SaleReadDTO>> GetAllByProductIdAsync(Guid productId);
        Task<Result> Sell(Guid id, int quantity);
    }
}
