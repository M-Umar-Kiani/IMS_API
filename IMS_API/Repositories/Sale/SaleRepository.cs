using AutoMapper;
using IMS_API.Dtos.Product;
using IMS_API.Dtos.Sale;
using IMS_API.Helper;
using IMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS_API.Repositories.Sale
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ImsDbContext dbContext;
        private readonly IMapper mapper;

        public SaleRepository(ImsDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<APIResponse> AddSaleProductRecord(SaleDto request)
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
                } else
                {
                    record.Quantity = record.Quantity - request.QuantitySold;
                    dbContext.Products.Update(record);
                    dbContext.SaveChanges();
                }


                var mappedData = mapper.Map<Models.Sale>(request);
                await dbContext.Sales.AddAsync(mappedData);
                await dbContext.SaveChangesAsync();

                response.ResponseCode = 201;
                response.Result = "Product Sale Successfully.";
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

        public async Task<IEnumerable<ProductDto>> GetAllProductsForSale()
        {
            var record = await dbContext.Products
                .Where(x => x.Quantity > 0 && x.IsDeleted == false)
                .OrderBy(o => o.ProductId)
                .ToListAsync();
            var mappedData = this.mapper.Map<List<ProductDto>>(record);
            return mappedData;
        }
    }
}
