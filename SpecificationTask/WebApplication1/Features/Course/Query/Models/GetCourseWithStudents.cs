using MediatR;
using WebApplication1.Global;

namespace WebApplication1.Features.Course.Query.Models
{
    public class GetCourseWithStudents: IRequest<Response>
    {
        public int Code { get; set; }

        public GetCourseWithStudents(int code)
        {
            Code = code;
        }
    }
}
