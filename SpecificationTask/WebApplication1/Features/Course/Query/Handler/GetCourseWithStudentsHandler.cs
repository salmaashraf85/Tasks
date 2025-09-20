using AutoMapper;
using MediatR;
using WebApplication1.Features.Course.Query.Models;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Global;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Specification;

namespace WebApplication1.Features.Course.Query.Handler
{
    public class GetCourseWithStudentsHandler : IRequestHandler<GetCourseWithStudents, Response>
    {
        private readonly IGenericRepository<CourseEntity> _genericRepository;
        private readonly IMapper _mapper;

        public GetCourseWithStudentsHandler(IGenericRepository<CourseEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetCourseWithStudents request, CancellationToken cancellationToken)
        {
            var spec = new CourseSpecification(request.Code, includeStudent: true);
            var course = (await _genericRepository.ListAsync(spec)).FirstOrDefault();

            if (course == null)
                return new Response { Message = $"course with id {request.Code} not found", Status = false };

            var dto = _mapper.Map<CourseWithStudentsDto>(course);

            return new Response
            {
                Data = dto,
                Message = "course retrieved successfully with students",
                Status = true
            };
        }
    }

}
