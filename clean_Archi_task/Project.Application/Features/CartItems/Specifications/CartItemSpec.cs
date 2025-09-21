using Ardalis.Specification;
using Project.Domain.Models.CartItems;
using Project.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project.Application.Features.CartItems.Specifications
{
    public class CartItemSpec : Specification<CartItem>
    {
        public CartItemSpec(string? name, int pageSize, int pageNumber)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Query.Where(x => x.Product.Name.Contains(name));
            }

            Query.Skip(pageSize * (pageNumber - 1))
                 .Take(pageSize);

            //// لو عايز تجيب الـ Product مع كل CartItem
            //Query.Include(x => x.Product);
        }
    }
}