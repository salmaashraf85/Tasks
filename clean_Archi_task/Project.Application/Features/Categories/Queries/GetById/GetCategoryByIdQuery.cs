using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Categories.Dtos;
using Project.Application.Features.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Queries.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IQuery<CategoryDto>;
}
