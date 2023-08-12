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
    public interface IProductService
    {
        Task<ProductReadDTO> GetAsync(Guid id);
        Task<IEnumerable<ProductReadDTO>> GetAllAsync();
        Task<Result<Guid>> CreateAsync(ProductWriteDTO model);
        Task<Result> UpdateAsync(Guid id, ProductWriteDTO model);
        Task<Result> DeleteAsync(Guid id);
    }
}
