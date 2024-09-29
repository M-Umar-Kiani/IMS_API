using IMS_API.Dtos.Product;
using IMS_API.Helper;

namespace IMS_API.Repositories.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(long productId);
        Task<APIResponse> AddProduct(ProductDto productDto);
        Task<APIResponse> UpdateProduct(long productId, ProductDto productDto);
        Task<APIResponse> DeleteProduct(long productId);
    }
}
