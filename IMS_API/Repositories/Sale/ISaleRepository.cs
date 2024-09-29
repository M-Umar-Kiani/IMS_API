using IMS_API.Dtos.Product;
using IMS_API.Dtos.Sale;
using IMS_API.Helper;

namespace IMS_API.Repositories.Sale
{
    public interface ISaleRepository
    {
        Task<IEnumerable<ProductDto>> GetAllProductsForSale();
        Task<APIResponse> AddSaleProductRecord(SaleDto request);
    }
}
