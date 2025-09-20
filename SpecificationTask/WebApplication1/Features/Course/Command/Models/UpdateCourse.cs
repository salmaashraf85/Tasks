using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models
{
    public record UpdateCourse(int Code, string Cname, float Hours)
        : CourseAddDto(Cname, Hours);
}
