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
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PurchaseService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseReadDTO>> GetAllAsync()
        {
            IEnumerable<Purchase> purchases = await _unitOfWork.Purchases.GetAllAsync();
            IEnumerable<PurchaseReadDTO> dtos = _mapper.Map<IEnumerable<PurchaseReadDTO>>(purchases);

            return dtos;
        }

        public async Task<IEnumerable<PurchaseReadDTO>> GetAllByProductIdAsync(Guid productId)
        {
            IEnumerable<Purchase> purchases = await _unitOfWork.Purchases.GetAllByProductIdAsync(productId);
            IEnumerable<PurchaseReadDTO> dtos = _mapper.Map<IEnumerable<PurchaseReadDTO>>(purchases);

            return dtos;
        }

        public async Task<Result> Purchase(Guid id, int quantity)
        {
            Product? product = await _unitOfWork.Products.GetAsync(id);
            if (product == null)
                return new Result() { HasError = true, Code = "NOT_FOUND" };

            Purchase sale = new Purchase()
            {
                Dated = DateTime.UtcNow,
                ProductId = id,
                QuantityPurchased = quantity,
                TotalAmount = product.UnitPrice * quantity
            };

            product.Quantity += quantity;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.Purchases.InsertAsync(sale);
            await _unitOfWork.SaveAsync();

            return new Result() { HasError = false };
        }
    }
}
