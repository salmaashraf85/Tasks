using Project.Application.Features.Categories.Commands.Add;
using Project.Application.Features.Categories.Commands.Update;
using Project.Application.Features.Categories.Dtos;
using Project.Domain.Models.Categories;

namespace Project.Application.Mapping.Category;

public class CategoryProfile : AutoMapper.Profile
{
    public CategoryProfile()
    {
        CreateMap<Domain.Models.Categories.Category, AddCategoryCommand>().ReverseMap();
        CreateMap<Domain.Models.Categories.Category, CategoryDto>();
        CreateMap<UpdateCategoryCommand,Domain.Models.Categories.Category>();

    }
}