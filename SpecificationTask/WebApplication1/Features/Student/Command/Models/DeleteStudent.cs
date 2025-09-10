using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models
{
    public record DeleteStudent(int id) : IRequest<Response>;
}
