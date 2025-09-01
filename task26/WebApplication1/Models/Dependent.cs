using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Dependent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public string Dname { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }

        //navigation
        public Employee Employee { get; set; }
    }
}
