using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Global;
using WebApplication1.Repositories.Interfaces;
using WebApplication1.Specification;

namespace WebApplication1.Features.Student.Query.Handler
{
    public class GetStudentWithCoursesHandler : IRequestHandler<GetStudentsWithCourses, Response>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentWithCoursesHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetStudentsWithCourses request, CancellationToken cancellationToken)
        {
            var spec = new StudentSpecification(request.Id, includeCourses: true);
            var student = (await _studentRepository.ListAsync(spec)).FirstOrDefault();

            if (student == null)
                return new Response { Message = $"Student with id {request.Id} not found", Status = false };

            var dto = _mapper.Map<StudentWithCoursesDto>(student);

            return new Response
            {
                Data = dto,
                Message = "Student retrieved successfully with courses",
                Status = true
            };
        }
    }

}
