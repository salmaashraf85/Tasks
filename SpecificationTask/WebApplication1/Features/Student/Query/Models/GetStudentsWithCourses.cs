using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Student.Query.Models
{
    public class GetStudentsWithCourses : IRequest<Response>
    {
        public int Id {  get; set; }

        public GetStudentsWithCourses(int id)
        {
            Id = id;
        }
    }
}
