using FluentValidation;
using Project.Application.Features.Categories.Commands.Update;
using Project.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Products.Commands.Update
{
    internal class UpdateProductValidator: AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("product name is required.")
                .MaximumLength(CategoryConstants.CategoryNameMaxLengthValue).WithMessage(CategoryConstants.CategoryNameMaxLengthMessage);
        }
    }
}