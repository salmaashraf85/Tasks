using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IAuthService
    {
        Task<Response<object>> Register(RegisterDto model);
        Task<Response<object>> Login(LoginDto model);
    }
}
