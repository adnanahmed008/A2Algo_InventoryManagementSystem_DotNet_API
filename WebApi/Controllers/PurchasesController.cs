using BusinessLogic.Interfaces;
using Core.Common;
using Core.DTOs;
using Core.Entities;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchasesController : ControllerBase
    {
        private readonly ILogger<PurchasesController> _logger;
        private readonly IPurchaseService _purchaseService;

        public PurchasesController(
            ILogger<PurchasesController> logger
            , IPurchaseService purchaseService
        )
        {
            _logger = logger;
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseReadDTO>>> GetAll()
        {
            IEnumerable<PurchaseReadDTO> purchases = await _purchaseService.GetAllAsync();
            return Ok(purchases);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<PurchaseReadDTO>> GetAllByProductId([FromRoute] Guid? productId)
        {
            if (!productId.HasValue)
                return BadRequest();

            IEnumerable<PurchaseReadDTO> purchases = await _purchaseService.GetAllByProductIdAsync(productId.Value);
            return Ok(purchases);
        }

        [HttpPost("{productId}/{quantity}")]
        public async Task<IActionResult> Purchase([FromRoute] Guid productId, [FromRoute] int quantity)
        {
            if (quantity == 0)
                return BadRequest();

            Result result = await _purchaseService.Purchase(productId, quantity);
            if (result.HasError)
            {
                if (result.Code == "NOT_FOUND")
                    return BadRequest("PRODUCT_NOT_FOUND");

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok();
        }
    }
}
