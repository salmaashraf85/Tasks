using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Dto;


namespace WebApplication1.Mapper
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductImageUrlResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.FilePath))
                return null;

            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";

            return $"{baseUrl}/{source.FilePath.Replace("\\", "/")}";
        }
    }
}
