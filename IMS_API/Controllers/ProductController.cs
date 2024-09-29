using IMS_API.Dtos.Product;
using IMS_API.Repositories.Product;
using Microsoft.AspNetCore.Mvc;

namespace IMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }


        [HttpGet("get-all-prodects")]
        public async Task<IActionResult> GetAllProducts()
        {
            var data = await productRepository.GetAllProducts();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("get-product-by-id")]
        public async Task<IActionResult> GetProductById(long productId)
        {
            var data = await productRepository.GetProductById(productId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProdunct(ProductDto request)
        {
            var resp = await productRepository.AddProduct(request);
            return Ok(resp);
        }

        [HttpPut("update-product/{produnctId}")]
        public async Task<IActionResult> UpdateProdunct([FromRoute] long produnctId, ProductDto request)
        {
            var resp = await productRepository.UpdateProduct(produnctId, request);
            return Ok(resp);
        }

        [HttpDelete("delete-product/{productId}")]
        public async Task<IActionResult> DeleteProdunct([FromRoute] long productId)
        {
            var resp = await productRepository.DeleteProduct(productId);
            return Ok(resp);
        }
    }
}
