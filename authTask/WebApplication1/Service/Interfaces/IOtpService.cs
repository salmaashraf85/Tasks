namespace WebApplication1.Service.Interfaces
{
    public interface IOtpService
    {
        Task<string> GenerateConfirmationOtpAsync( string userEmail);
        Task<string> GenerateResetPasswordOtpAsync( string userEmail);
        Task<bool> VerifyOtpAsync(string userEmail, string otpCode, string purpose);
    }
}
