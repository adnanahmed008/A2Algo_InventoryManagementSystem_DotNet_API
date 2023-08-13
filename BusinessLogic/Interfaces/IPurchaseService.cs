using Core.Common;
using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseReadDTO>> GetAllAsync();
        Task<IEnumerable<PurchaseReadDTO>> GetAllByProductIdAsync(Guid productId);
        Task<Result> Purchase(Guid id, int quantity);
    }
}
