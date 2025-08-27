using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }                
        public string UserName { get; set; }
        public string Password { get; set; }
        public int EmpId { get; set; }
        public virtual Employee Emp { get; set; }
    }
}
