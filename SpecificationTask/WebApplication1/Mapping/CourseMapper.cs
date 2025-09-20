using AutoMapper;
using WebApplication1.Features.Course.Query.Models;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {

            CreateMap<CourseEntity, CourseAddDto>();

            CreateMap<CourseAddDto, CourseEntity>();
            CreateMap<UpdateCourse, CourseEntity>();
            CreateMap<CourseWithStudentsDto, CourseEntity>();
            CreateMap<CourseEntity, CourseWithStudentsDto>();
            CreateMap<StudentEntity, StudentDto>();


            // CreateMap<UpdateStudent, StudentEntity>();
        }
    }
}


