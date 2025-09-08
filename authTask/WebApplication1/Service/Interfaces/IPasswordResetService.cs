namespace WebApplication1.Service.Interfaces
{
    
        public interface IPasswordResetService
        {
            Task<string?> CreateResetPasswordSessionAsync(string email, string otp);
            Task<bool> ChangePasswordAsync(string sessionId, string newPassword);
        }
 }

