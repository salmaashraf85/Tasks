namespace WebApplication1.Dto
{
    public class UserOtp
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string OtpCode { get; set; }
        public DateTime ExpiryTime { get; set; }
        public bool IsUsed { get; set; } = false;

        public string Purpose { get; set; }
    }
}
