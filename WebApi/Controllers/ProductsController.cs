using BusinessLogic.Interfaces;
using Core.Common;
using Core.DTOs;
using Core.Entities;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public ProductsController(
            ILogger<ProductsController> logger
            , IUnitOfWork unitOfWork
            , IProductService productService
        )
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<IActionResult> Create(ProductWriteDTO model)
        {
            if (!ModelState.IsValid)
            {
                // Get validation errors from ModelState
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList();

                return BadRequest(new Result
                {
                    HasError = true,
                    Code = "VALIDATION_ERROR",
                    Message = "One or more validation errors occurred.",
                    Data = errors
                });
            }

            Result<Guid> result = await _productService.CreateAsync(model);
            if (result.HasError)
                return StatusCode(StatusCodes.Status500InternalServerError, result.Code);

            return Ok(result.Data);
        }
    }
}