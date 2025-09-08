using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using System.Text;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Service.Interfaces;

namespace WebApplication1.Service.Implementation
{
    public class PasswordResetService(ApplicationDbContext _dbContext) : IPasswordResetService
    {
        public async Task<string?> CreateResetPasswordSessionAsync(string email, string otp)
        {
            var otpService = new OtpService(_dbContext, null!);
            var isValid = await otpService.VerifyOtpAsync(email, otp, "ResetPassword");
            if (!isValid) return null;

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return null;

            
            var sessionId = Guid.NewGuid().ToString();
            var session = new PasswordResetSession
            {
                SessionId = sessionId,
                UserId = user.Id,
                Expiration = DateTime.UtcNow.AddMinutes(10)
            };

            _dbContext.PasswordResetSessions.Add(session);
            await _dbContext.SaveChangesAsync();

            
            var sessionBytes = Encoding.UTF8.GetBytes(sessionId);
            var encodedSessionId = Convert.ToBase64String(sessionBytes);

            return encodedSessionId; 
        }

        public async Task<bool> ChangePasswordAsync(string encodedSessionId, string newPassword)
        {

                var sessionBytes = Convert.FromBase64String(encodedSessionId);
                var sessionId = Encoding.UTF8.GetString(sessionBytes);
                var session = await _dbContext.PasswordResetSessions
                    .FirstOrDefaultAsync(s => s.SessionId == sessionId && s.Expiration > DateTime.UtcNow);

                if (session == null) return false;

                var user = await _dbContext.Users.FindAsync(session.UserId);
                if (user == null) return false;

                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                _dbContext.PasswordResetSessions.Remove(session);
                await _dbContext.SaveChangesAsync();
                return true;
         
        }
    }
}
