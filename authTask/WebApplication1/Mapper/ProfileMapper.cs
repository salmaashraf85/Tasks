using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Mapper
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.FilePath,
                           opt => opt.MapFrom<ProductImageUrlResolver>());



        }
    }
}
