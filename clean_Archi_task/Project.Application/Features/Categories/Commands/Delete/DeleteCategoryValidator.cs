using FluentValidation;
using Project.Application.Features.Products.Commands.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Commands.Delete
{
    internal class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Category ID is required.");
        }
    }
}
