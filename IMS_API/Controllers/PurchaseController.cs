using IMS_API.Dtos.Purchase;
using IMS_API.Dtos.Sale;
using IMS_API.Repositories.Purchase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseRepository purchaseRepository;

        public PurchaseController(IPurchaseRepository purchaseRepository)
        {
            this.purchaseRepository = purchaseRepository;
        }

        [HttpPost("made-product-purchase")]
        public async Task<IActionResult> AddProductSaleRecord(PurchaseDto request)
        {
            var data = await this.purchaseRepository.AddPurchaseProductRecord(request);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
