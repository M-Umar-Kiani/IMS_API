using AutoMapper;
using IMS_API.Dtos.Purchase;
using IMS_API.Helper;
using IMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS_API.Repositories.Purchase
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ImsDbContext dbContext;
        private readonly IMapper mapper;

        public PurchaseRepository(ImsDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<APIResponse> AddPurchaseProductRecord(PurchaseDto request)
        {
            var response = new APIResponse();
            try
            {
                var record = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == request.ProductId);
                if (record == null)
                {
                    response.ResponseCode = 500;
                    response.Result = "Internal Server Error.";
                    response.Status = false;
                    response.ErrorMessage = "Internal Server Error.";
                    return response;
                }
                else
                {
                    record.Quantity = request.QuantityPurchase;
                    dbContext.Products.Update(record);
                    dbContext.SaveChanges();
                }


                var mappedData = mapper.Map<Models.Purchase>(request);
                await dbContext.Purchases.AddAsync(mappedData);
                await dbContext.SaveChangesAsync();

                response.ResponseCode = 201;
                response.Result = "Product Purchase Successfully.";
                response.Status = true;
                response.ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 500;
                response.Result = "Internal Server Error.";
                response.Status = false;
                response.ErrorMessage = ex.Message;
                return response;
            }

            return response;
        }
    }
}
