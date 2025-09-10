using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Global;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Student.Command.Handler
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudent, Response>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetById(request.id);

            if (student == null)
            {
                return new Response
                {
                    Message = $"student with id {request.id} not found",
                    Status = false,
                };
            }

             _studentRepository.Delete(student);

            return new Response
            {
                Data = student,
                Message = $"student with id {request.id} deleted successfully",
                Status = true,
            };

        }
    }
}
