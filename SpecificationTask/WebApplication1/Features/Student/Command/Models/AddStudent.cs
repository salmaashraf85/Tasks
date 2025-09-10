using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models
{
    public record AddStudent(string Name, int age) : IRequest<Response>;
}
