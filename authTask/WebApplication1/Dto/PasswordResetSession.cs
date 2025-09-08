using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class PasswordResetSession
    {
        [Key]
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public DateTime Expiration { get; set; }
    }
}
