using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Command.Models
{
    public record UpdateStudent(int Id, string Name, int Age) : IRequest<Response>;
}
