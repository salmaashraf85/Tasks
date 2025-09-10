using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models
{
    public record UpdateCourse(int Code, string CName,float Hours) : IRequest<Response>;
}
