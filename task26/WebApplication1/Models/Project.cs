using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pno { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //department
        public int Dno;
        public Depratment Depratment { get; set; }

        public ICollection<WorksOnHours> WorksOnHours { get; set; } = new List<WorksOnHours>();
    }
}
