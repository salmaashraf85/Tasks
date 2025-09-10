using FluentValidation;
using WebApplication1.Features.Student.Command.Models;

namespace WebApplication1.Features.Course.Command.Validators
{
    public class CourseUpdateValidator : AbstractValidator<UpdateCourse>
    {
        public CourseUpdateValidator()
        {
            RuleFor(x => x.Code)
                 .NotEmpty()
                 .WithMessage("Course code is required");

            RuleFor(x => x.CName)
                .NotEmpty()
                .WithMessage("course name is required");
        }
        }
}
