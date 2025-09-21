using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Project.Application.Features.Categories.Queries.GetById
{
    internal class GetCategoryByIdValidator: AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
