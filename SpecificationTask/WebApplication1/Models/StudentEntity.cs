using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class StudentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public ICollection<CourseEntity> Courses { get; set; } = new List<CourseEntity>();
    }
}
