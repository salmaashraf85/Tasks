using AutoMapper;
using MediatR;
using WebApplication1.Features.Course.Query.Models;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Global;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Course.Query.Handler
{
    public class GetCourseHandler : IRequestHandler<CourseDto, Response>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        public GetCourseHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CourseDto request, CancellationToken cancellationToken)
        {
            var Course = await _courseRepository.GetById(request.Code);
            if (Course == null)
            {
                return new Response
                {
                    Message = $"Course with id {request.Code} not found",
                    Status = false,
                };
            }

            return new Response
            {
                Data = Course,
                Message = "Course retrieved successfully",
                Status = true
            };

        }
    }
}
