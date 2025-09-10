using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Course.Command.Handler
{
    public class DeleteCourseHandler: IRequestHandler<DeleteCourse, Response>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        public DeleteCourseHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(DeleteCourse request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetById(request.id);

            if (course == null)
            {
                return new Response
                {
                    Message = $"course with id {request.id} not found",
                    Status = false,
                };
            }

            _courseRepository.Delete(course);

            return new Response
            {
                Data = course,
                Message = $"course with id {request.id} deleted successfully",
                Status = true,
            };

        }
    }
}

