using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models
{
    public record AddCourse(string Cname,float Hours) : IRequest<Response>;
}
