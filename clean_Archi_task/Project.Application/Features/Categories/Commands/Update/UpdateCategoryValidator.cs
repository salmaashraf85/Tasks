using FluentValidation;
using Project.Application.Features.Categories.Commands.Add;
using Project.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Categories.Commands.Update
{
    internal class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(CategoryConstants.CategoryNameMaxLengthValue).WithMessage(CategoryConstants.CategoryNameMaxLengthMessage);
        }
    }
}