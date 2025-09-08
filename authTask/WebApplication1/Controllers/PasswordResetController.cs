using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service.Interfaces;
using WebApplication1.Attributes;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordResetController(IPasswordResetService _passwordResetService) : ControllerBase
    {
        [HttpPost("verify-reset-otp")]
        public async Task<IActionResult> VerifyResetOtp([FromQuery] string email, [FromQuery] string otp)
        {
            var sessionId = await _passwordResetService.CreateResetPasswordSessionAsync(email, otp);

            if (sessionId == null)
            {
                return BadRequest(new Response<string>
                {
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Invalid or expired OTP"
                });
            }

            return Ok(new Response<string>
            {
                Data = sessionId,
                StatusCode = HttpStatusCode.OK,
                Message = "Session created successfully"
            });
        }

        [HttpPost("change-password")]
        [ServiceFilter(typeof(ValidateSessionAttribute))]
        public async Task<IActionResult> ChangePassword([FromQuery] string encodedSessionId, [FromQuery] string newPassword)
        {
            var result = await _passwordResetService.ChangePasswordAsync(encodedSessionId, newPassword);

            if (!result)
            {
                return BadRequest(new Response<bool>
                {
                    Data = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Failed to change password"
                });
            }

            return Ok(new Response<bool>
            {
                Data = true,
                StatusCode = HttpStatusCode.OK,
                Message = "Password changed successfully"
            });
        }
    }
}
