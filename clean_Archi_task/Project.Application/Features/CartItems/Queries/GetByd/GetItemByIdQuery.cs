using Project.Application.Abstractions.Messaging;
using Project.Application.Features.CartItems.Dtos;
using Project.Application.Features.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Queries.GetByd
{
    public record GetItemByIdQuery(Guid Id) : IQuery<CardItemDto>;
}
