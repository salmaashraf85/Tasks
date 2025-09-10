using WebApplication1.Features.Course.Query.Models;

namespace WebApplication1.Features.Student.Query.Models
{
    public class StudentWithCoursesDto
    {
        public int SID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
