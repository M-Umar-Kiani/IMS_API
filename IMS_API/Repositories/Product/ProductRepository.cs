using AutoMapper;
using IMS_API.Dtos.Product;
using IMS_API.Helper;
using IMS_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IMS_API.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ImsDbContext dbContext;
        private readonly IMapper mapper;

        public ProductRepository(ImsDbContext _dbContext, IMapper mapper)
        {
            dbContext = _dbContext;
            this.mapper = mapper;
        }
        public async Task<APIResponse> AddProduct(ProductDto request)
        {
            var response = new APIResponse();
            try
            {
                var mappedData = mapper.Map<Models.Product>(request);
                await dbContext.Products.AddAsync(mappedData);
                dbContext.SaveChangesAsync();

                response.ResponseCode = 201;
                response.Result = "Product Added Successfully.";
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

        public async Task<APIResponse> DeleteProduct(long productId)
        {
            var response = new APIResponse();
            try
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null)
                {
                    response.ResponseCode = 404;
                    response.Result = "Not Found";
                    response.Status = false;
                    response.ErrorMessage = string.Empty;
                    return response;
                }

                product.IsDeleted = true;
                dbContext.Products.Update(product);
                dbContext.SaveChanges();

                response.ResponseCode = 201;
                response.Result = "Product Deleted Successfully.";
                response.Status = true;
                response.ErrorMessage = string.Empty;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 500;
                response.Result = "Internal Server Error.";
                response.Status = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var product = await dbContext.Products.Where(x => x.IsDeleted == false).OrderBy(p => p.ProductId).ToListAsync();
            var mappedData = this.mapper.Map<List<ProductDto>>(product);
            return mappedData;
        }

        public async Task<ProductDto> GetProductById(long productId)
        {
            var product = await this.dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            var mappedData = this.mapper.Map<ProductDto>(product);
            return mappedData;
        }

        public async Task<APIResponse> UpdateProduct(long productId, ProductDto request)
        {
            var response = new APIResponse();
            try
            {
                var product = await this.dbContext.Products.FirstOrDefaultAsync(dbContext => dbContext.ProductId == productId);
                if (product == null)
                {
                    response.ResponseCode = 404;
                    response.Result = "Not Found";
                    response.Status = false;
                    response.ErrorMessage = string.Empty;
                    return response;
                }

                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Quantity = request.Quantity;
                product.Image = request.Image;

                dbContext.Products.Update(product);
                dbContext.SaveChanges();

                response.ResponseCode = 200;
                response.Result = "Product Update Successfully.";
                response.Status = true;
                response.ErrorMessage = string.Empty;
                return response;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 500;
                response.Result = "Internal Server Error.";
                response.Status = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }
    }
}
