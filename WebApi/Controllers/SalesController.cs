using BusinessLogic.Concreate;
using BusinessLogic.Interfaces;
using Core.Common;
using Core.DTOs;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;
        private readonly ISaleService _saleService;

        public SalesController(
            ILogger<SalesController> logger
            , ISaleService saleService
        )
        {
            _logger = logger;
            _saleService = saleService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleReadDTO>>> GetAll()
        {
            IEnumerable<SaleReadDTO> purchases = await _saleService.GetAllAsync();
            return Ok(purchases);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<SaleReadDTO>> GetAllByProductId([FromRoute] Guid? productId)
        {
            if (!productId.HasValue)
                return BadRequest();

            IEnumerable<SaleReadDTO> purchases = await _saleService.GetAllByProductIdAsync(productId.Value);
            return Ok(purchases);
        }

        [HttpPost("{productId}/{quantity}")]
        public async Task<IActionResult> Sell([FromRoute] Guid productId, [FromRoute] int quantity)
        {
            if (quantity == 0)
                return BadRequest();

            Result result = await _saleService.Sell(productId, quantity);
            if (result.HasError)
            {
                if (result.Code == "NOT_FOUND")
                    return BadRequest("PRODUCT_NOT_FOUND");

                if (result.Code == "OVER_QUANTITY")
                    return BadRequest("QUANTITY_EXCEEDS_STOCK");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
