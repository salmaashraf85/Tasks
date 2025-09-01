using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Dto;

public class EmployeeImageUrlResolver : IValueResolver<Employee, EmployeeDto, string>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public EmployeeImageUrlResolver(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string Resolve(Employee source, EmployeeDto destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.ImagePath))
            return null;

        var request = _httpContextAccessor.HttpContext.Request;
        var baseUrl = $"{request.Scheme}://{request.Host}";
        return $"{baseUrl}/{source.ImagePath.Replace("\\", "/")}";
    }
}
