using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }

        public string ImagePath { get; set; } = string.Empty;
        public DateTime Dob {  get; set; }
        public DateTime Doj { get; set; }

        //navigation
        public ICollection<Dependent> Dependents { get; set; }

        //department
        public int DeptNo { get; set; }
        public virtual Depratment department { get; set; }

        public virtual ICollection<Manages> ManagedDepartments { get; set; }

        public ICollection<WorksOnHours> WorksOnHours { get; set; } = new List<WorksOnHours>();


    }
}
