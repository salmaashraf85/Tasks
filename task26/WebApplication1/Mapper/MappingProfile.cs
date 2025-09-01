using AutoMapper;
using System.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>()
           .ForMember(dest => dest.ImageUrl,
                      opt => opt.MapFrom<EmployeeImageUrlResolver>());

            CreateMap<EmployeeDto, Employee>()
         .ForMember(dest => dest.ImagePath, opt => opt.Ignore());

            CreateMap<Depratment, DepartmentDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Dependent, dependentDto>().ReverseMap();
            CreateMap<WorksOnHours, WorksOnDto>().ReverseMap();
            CreateMap<Manages, ManageDto>().ReverseMap();

        }
    }
}