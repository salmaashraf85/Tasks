using AutoMapper;
using MediatR;
using WebApplication1.Features.Student.Command.Models;
using WebApplication1.Features.Student.Query.Models;
using WebApplication1.Global;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Features.Student.Query.Handler
{
    public class GetStudentHandler : IRequestHandler<GetStudentById, Response>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        public GetStudentHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetStudentById request, CancellationToken cancellationToken)
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
            
                return new Response
                {
                    Data = student,
                    Message = "student retrieved successfully",
                    Status = true
                };
            
        }
    }
}
