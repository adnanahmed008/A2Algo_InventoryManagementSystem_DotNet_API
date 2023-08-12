using AutoMapper;
using BusinessLogic.Interfaces;
using Core.Common;
using Core.DTOs;
using Core.Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(
            IUnitOfWork unitOfWork
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductReadDTO> GetAsync(Guid id)
        {

            Product? product = await _unitOfWork.Products.GetAsync(id);
            ProductReadDTO dto = _mapper.Map<ProductReadDTO>(product);

            return dto;

        }

        public async Task<IEnumerable<ProductReadDTO>> GetAllAsync()
        {
            IEnumerable<Product> products = await _unitOfWork.Products.GetAllAsync();
            IEnumerable<ProductReadDTO> dtos = _mapper.Map<IEnumerable<ProductReadDTO>>(products);

            return dtos;
        }

        public async Task<Result<Guid>> CreateAsync(ProductWriteDTO model)
        {
            Product product = _mapper.Map<ProductWriteDTO, Product>(model);
            await _unitOfWork.Products.InsertAsync(product);

            await _unitOfWork.SaveAsync();

            return new Result<Guid>() { HasError = false, Data = product.Id };
        }

        public async Task<Result> UpdateAsync(Guid id, ProductWriteDTO model)
        {
            Product? product = await _unitOfWork.Products.GetAsync(id);
            if (product == null)
                return new Result() { HasError = true, Code = "NOT_FOUND" };

            product.Name = model.Name;
            product.Description = model.Description;
            product.UnitPrice = model.UnitPrice;

            _unitOfWork.Products.Update(product);

            await _unitOfWork.SaveAsync();
            return new Result() { HasError = false };
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            return new Result() { HasError = false };
        }
    }
}
