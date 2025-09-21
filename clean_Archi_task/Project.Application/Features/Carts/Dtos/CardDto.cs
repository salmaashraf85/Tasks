using Project.Application.Features.CartItems.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Carts.Dtos
{
    public record CardDto(Guid Id, List<CardItemDto> items);
}
