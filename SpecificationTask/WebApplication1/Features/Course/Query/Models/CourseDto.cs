using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Course.Query.Models
{
    public class CourseDto : IRequest<Response>
    {
        public int Code { get; set; }
        public string Cname { get; set; }
        public float Hours { get; set; }

    }
}
