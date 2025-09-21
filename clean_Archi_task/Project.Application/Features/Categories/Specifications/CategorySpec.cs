using Ardalis.Specification;
using Project.Domain.Models.Categories;
using Project.Domain.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Project.Application.Features.Categories.Specifications
{
    public class CategorySpec : Specification<Category>
    {
        public CategorySpec(string? name, int pageSize, int pageNumber)
        {
            if (name != null)
                Query.Where(x => x.Name.Contains(name));
            Query.Skip(pageSize * (pageNumber - 1));
            Query.Take(pageSize);
        }
    }
}
