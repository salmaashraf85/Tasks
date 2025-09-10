using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CourseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Code { get; set; }

        public string Cname {  get; set; }
        public float Hours { get; set; }

        public ICollection<StudentEntity> Students { get; set; } = new List<StudentEntity>();

    }
}
