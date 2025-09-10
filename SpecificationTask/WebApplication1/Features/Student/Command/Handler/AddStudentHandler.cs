using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Student.Command.Handler
{
    public class AddStudentHandler:IRequestHandler<AddStudent, Response>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public AddStudentHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(AddStudent request, CancellationToken cancellationToken)
        {

            
            var student = _mapper.Map<StudentEntity>(request);
            await _studentRepository.Create(student);

            return new Response
            {
                Data = student,
                Message = "student Added successfully",
                Status = true
            };
        }

    }
}
