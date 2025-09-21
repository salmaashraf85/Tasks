using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CartItems.Dtos
{
    public record CardItemDto(Guid Id, int Quantity);
}
