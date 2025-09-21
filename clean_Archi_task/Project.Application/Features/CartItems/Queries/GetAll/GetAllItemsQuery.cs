using Project.Application.Abstractions.Messaging;
using Project.Application.Features.CartItems.Dtos;
using Project.Application.Features.Categories.Dtos;
using Project.Domain.Filters;
using Project.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Queries.GetAll
{
    public record GetAllItemsQuery(string? Name) : BaseFilter, IQuery<PaginatedResult<CardItemDto>>;
}
