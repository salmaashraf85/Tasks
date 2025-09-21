using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Categories.Dtos;
using Project.Domain.Filters;
using Project.Domain.Models.Categories;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Queries.GetAll
{
    public record GetAllCategoryQuery(string? Name) : BaseFilter, IQuery<PaginatedResult<CategoryDto>>;
}
