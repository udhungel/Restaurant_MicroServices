using AutoMapper;
using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {           
            
               CreateMap<ProductDto, MangoProduct>().ReverseMap();
               //CreateMap<MangoProduct, ProductDto>();
           
          
        }
    }
}
