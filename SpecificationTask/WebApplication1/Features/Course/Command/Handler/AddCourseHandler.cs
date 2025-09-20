using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Course.Command.Handler
{
    public class AddCourseHandler : IRequestHandler<CourseAddDto, Response>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        public AddCourseHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(CourseAddDto request, CancellationToken cancellationToken)
        {


            var course = _mapper.Map<CourseEntity>(request);
            await _courseRepository.Create(course);

            return new Response
            {
                Data = course,
                Message = "course Added successfully",
                Status = true
            };
        }
    }
}
