using IMS_API.Dtos.Sale;
using IMS_API.Repositories.Sale;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        [HttpGet("get-all-products-for-sale")]
        public async Task<IActionResult> GetAllProductsForSale() 
        { 
            var data = await this.saleRepository.GetAllProductsForSale();
            if (data == null) 
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("made-product-sale")]
        public async Task<IActionResult> AddProductSaleRecord(SaleDto request)
        {
            var data = await this.saleRepository.AddSaleProductRecord(request);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
