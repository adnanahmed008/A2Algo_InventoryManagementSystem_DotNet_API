using AutoMapper;
using BusinessLogic.Interfaces;
using Core.Common;
using Core.DTOs;
using Core.Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concreate
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaleService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SaleReadDTO>> GetAllAsync()
        {
            IEnumerable<Sale> sales = await _unitOfWork.Sales.GetAllAsync();
            IEnumerable<SaleReadDTO> dtos = _mapper.Map<IEnumerable<SaleReadDTO>>(sales);

            return dtos;
        }

        public async Task<IEnumerable<SaleReadDTO>> GetAllByProductIdAsync(Guid productId)
        {
            IEnumerable<Sale> sales = await _unitOfWork.Sales.GetAllByProductIdAsync(productId);
            IEnumerable<SaleReadDTO> dtos = _mapper.Map<IEnumerable<SaleReadDTO>>(sales);

            return dtos;
        }

        public async Task<Result> Sell(Guid id, int quantity)
        {
            Product? product = await _unitOfWork.Products.GetAsync(id);
            if (product == null)
                return new Result() { HasError = true, Code = "NOT_FOUND" };

            if ((product.Quantity - quantity) < 0)
                return new Result() { HasError = true, Code = "OVER_QUANTITY" };

            Sale sale = new Sale()
            {
                Dated = DateTime.UtcNow,
                ProductId = id,
                QuantitySold = quantity,
                TotalAmount = product.UnitPrice * quantity
            };

            product.Quantity -= quantity;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.Sales.InsertAsync(sale);
            await _unitOfWork.SaveAsync();

            return new Result() { HasError = false };
        }
    }
}
