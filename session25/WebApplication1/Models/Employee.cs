using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Login> Logins { get; set;}
        public int DeptId { get; set; }
        public virtual Department department { get; set; }

        public int RoleId { get; set; }
        public virtual Role role { get; set; }



    }
}
