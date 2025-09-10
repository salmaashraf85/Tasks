using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Student.Command.Handler
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudent, Response>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(UpdateStudent request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetById(request.Id);

            if (student == null)
            {
                return new Response
                {
                    Message = $"student with id {request.Id} not found",
                    Status = false,
                };
            }
            _mapper.Map(request, student);

            await _studentRepository.Update(student);

            return new Response
            {
                Data = student,
                Message = "student updated successfully",
                Status = true
            };
        }

    }
}
