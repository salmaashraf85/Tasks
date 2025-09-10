using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Query.Models
{
    public class GetStudentById:IRequest<Response>
    {
        public int Id { get; set; }
    }
}
