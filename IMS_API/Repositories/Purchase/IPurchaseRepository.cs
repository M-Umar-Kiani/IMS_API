using IMS_API.Dtos.Purchase;
using IMS_API.Dtos.Sale;
using IMS_API.Helper;

namespace IMS_API.Repositories.Purchase
{
    public interface IPurchaseRepository
    {
        Task<APIResponse> AddPurchaseProductRecord(PurchaseDto request);
    }
}
