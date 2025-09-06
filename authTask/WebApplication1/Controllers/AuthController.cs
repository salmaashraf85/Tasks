using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication1.Service;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Controllers.Base;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return Result(new Response<object>
                {
                    Data = ModelState,
                    StatusCode = HttpStatusCode.BadRequest
                });
            }

            var result = await _authService.Register(model);
            return Result(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return Result(new Response<object>
                {
                    Data = ModelState,
                    StatusCode = HttpStatusCode.BadRequest
                });
            }

            var result = await _authService.Login(model);
            return Result(result);
        }
    }
}
