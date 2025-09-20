using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models
{
    public record CourseAddDto(string Cname,float Hours) : IRequest<Response>;
}
