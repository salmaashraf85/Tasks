using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System.Net;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Service.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController(IOtpService _otpService) : ControllerBase
    {
        [HttpPost("generate-confirmation")]
        public async Task<IActionResult> GenerateConfirmation([FromQuery] string email)
        {
            var otp = await _otpService.GenerateConfirmationOtpAsync(email);
            return Ok(new Response<string>
            {
                Data = otp,
                StatusCode = HttpStatusCode.OK,
                Message = "Confirmation OTP sent to email"
            });
        }

        [HttpPost("generate-reset")]
        public async Task<IActionResult> GenerateReset([FromQuery] string email)
        {
            var otp = await _otpService.GenerateResetPasswordOtpAsync(email);
             return Ok(new Response<string>
            {
                Data = otp,
                StatusCode = HttpStatusCode.OK,
                Message = "Reset Password OTP sent to email"
             });
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Verify([FromQuery] string email, [FromQuery] string otp, [FromQuery] string purpose)
        {
            var isValid = await _otpService.VerifyOtpAsync(email, otp, purpose);
            return isValid ?
                Ok(new Response<string>
                {
                    Data = null,
                    StatusCode = HttpStatusCode.OK,
                    Message = "OTP Verified"
                }) : 
                BadRequest(new Response<string>
                {
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Invalid or expired OTP"
                });
        }


    }
}
