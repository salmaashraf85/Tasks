using Project.Application.Abstractions.Messaging;
using Project.Application.Features.Carts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Carts.Queries.GetCartById
{
    public record GetCartQuery(Guid Id) : IQuery<CardDto>;
}
