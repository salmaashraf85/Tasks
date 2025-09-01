using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Manages
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Depratment Department { get; set; }
        
        public DateTime Since { get; set; }
    }
}
