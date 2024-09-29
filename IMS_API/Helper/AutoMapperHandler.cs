using AutoMapper;
using IMS_API.Dtos.Product;
using IMS_API.Dtos.Purchase;
using IMS_API.Dtos.Sale;
using IMS_API.Models;

namespace IMS_API.Helper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<Purchase, PurchaseDto>().ReverseMap();

        }
    }
}
