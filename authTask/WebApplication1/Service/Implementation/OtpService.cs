using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Service.Interfaces;

namespace WebApplication1.Service.Implementation
{
    public class OtpService(ApplicationDbContext _dbContext, IEmailService _emailService) : IOtpService
    {
        private static string GenerateOtp(int length = 6)
        {
            var random = new Random();
            return string.Concat(Enumerable.Range(0, length).Select(_ => random.Next(0, 10).ToString()));
        }

        public async Task<string> GenerateConfirmationOtpAsync(string userEmail)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null)
                throw new Exception("user not found");

            var otp = GenerateOtp();
            var otpEntry = new UserOtp
            {
                UserId = user.Id,
                OtpCode = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                Purpose = "ConfirmEmail"
            };

            _dbContext.UserOtps.Add(otpEntry);
            await _dbContext.SaveChangesAsync();

            var emailModel = new OtpModel("User", userEmail, otp)
            {
                ExpiredInMinutes = 5
            };

            await _emailService.SendEmailAsync(
                emailModel,
                EmailSubject.EmailVerification,
                HtmlTemplate.OtpVerification
            );

            return otp;
        }


        public async Task<string> GenerateResetPasswordOtpAsync(string userEmail)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null)
                throw new Exception("user not found");
            var otp = GenerateOtp();
            var otpEntry = new UserOtp
            {
                UserId = user.Id,
                OtpCode = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                Purpose = "ResetPassword"
            };

            _dbContext.UserOtps.Add(otpEntry);
            await _dbContext.SaveChangesAsync();

            var emailModel = new OtpModel("User", userEmail, otp)
            {
                ExpiredInMinutes = 5
            };

            await _emailService.SendEmailAsync(
                emailModel,
                EmailSubject.OtpVerification,
                HtmlTemplate.OtpVerification
            );

            return otp;
        }


        public async Task<bool> VerifyOtpAsync(string userEmail, string otpCode, string purpose)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null)
                throw new Exception("user not found");

            var otpEntry = await _dbContext.UserOtps
                .Where(o => o.UserId == user.Id &&
                            o.OtpCode == otpCode &&
                            o.Purpose == purpose &&
                            !o.IsUsed)
                .OrderByDescending(o => o.ExpiryTime)
                .FirstOrDefaultAsync();

            if (otpEntry == null) return false;
            if (otpEntry.ExpiryTime < DateTime.UtcNow) return false;

            otpEntry.IsUsed = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        
    }

}

