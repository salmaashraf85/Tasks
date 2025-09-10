using AutoMapper;
using WebApplication1.Features.Course.Query.Models;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
           
            CreateMap<StudentEntity, AddStudent>();
            CreateMap<StudentEntity, StudentWithCoursesDto>();
            CreateMap<CourseEntity, CourseDto>();

            CreateMap<AddStudent, StudentEntity>();
            CreateMap<UpdateStudent, StudentEntity>();
        }
    }
}
