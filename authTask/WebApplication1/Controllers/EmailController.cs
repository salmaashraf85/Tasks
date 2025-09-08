using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Service.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController(IEmailService emailService) : ControllerBase
    {

        [HttpGet("send")]
        public async Task<IActionResult> SendEmail()
        {
            EmailModel emailModel = new ResetPasswordModel("SalmaAshraf", "loma852004@gmail.com", "example-token");
            EmailSubject subject = EmailSubject.PasswordReset;

            await emailService.SendEmailAsync(emailModel, subject, HtmlTemplate.ResetPassword);
            return Ok(new { message = "Email sent successfully" });
        }
    }
}
