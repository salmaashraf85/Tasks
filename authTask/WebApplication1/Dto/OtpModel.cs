namespace WebApplication1.Dto
{
    public record OtpModel(string ToName, string ToMail, string otp)
        : EmailModel(ToName, ToMail, HtmlTemplate.OtpVerification)
    {
        public int? ExpiredInMinutes { get; set; }
    }
}
