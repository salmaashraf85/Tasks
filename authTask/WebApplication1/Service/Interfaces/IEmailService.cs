using WebApplication1.Dto;

namespace WebApplication1.Service.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailModel emailModel, EmailSubject subject, HtmlTemplate htmlTemplate);
    }
}
