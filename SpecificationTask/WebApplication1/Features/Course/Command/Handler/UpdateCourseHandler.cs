using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Course.Command.Handler
{
    public class UpdateCourseHandler : IRequestHandler<UpdateCourse, Response>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        public UpdateCourseHandler(ICourseRepository courseRepository , IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(UpdateCourse request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetById(request.Code);

            if (course == null)
            {
                return new Response
                {
                    Message = $"course with id {request.Code} not found",
                    Status = false,
                };
            }
            _mapper.Map(request, course);

            await _courseRepository.Update(course);

            return new Response
            {
                Data = course,
                Message = "course updated successfully",
                Status = true
            };
        }

    }
}
