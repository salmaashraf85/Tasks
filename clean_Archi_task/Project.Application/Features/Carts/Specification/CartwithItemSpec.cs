using Ardalis.Specification;
using Project.Domain.Models.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project.Application.Features.Carts.Specification
{
    internal class CartwithItemSpec : Specification<Cart>
    {
        public CartwithItemSpec(Guid cartId)
        {
            Query.Where(c => c.Id == cartId)
                 .Include(c => c.Items)
                    .ThenInclude(i => i.Product);
        }
    }
}