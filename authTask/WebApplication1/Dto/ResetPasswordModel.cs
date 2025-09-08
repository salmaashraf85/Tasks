namespace WebApplication1.Dto
{
    public record ResetPasswordModel(
    string ToName,
    string ToMail,
    string Token)
    : EmailModel(ToName, ToMail, HtmlTemplate.ConfirmEmail)
    {
        public int? ExpiredInMinutes { get; set; }
        public string? ResetUrl { get; set; }
    }
}
