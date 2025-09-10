using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Models;

namespace WebApplication1.Features.Course.Query.Models
{
    public class CourseWithStudentsDto 
    {
        public int Code { get; set; }

        public string Cname { get; set; }
        public float Hours { get; set; }

        public ICollection<StudentDto> Students { get; set; } = new List<StudentDto>();
    }
}
