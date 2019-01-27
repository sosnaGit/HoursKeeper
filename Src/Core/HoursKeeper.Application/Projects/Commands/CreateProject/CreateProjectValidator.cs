using FluentValidation;
using HoursKeeper.Persistence;
using System.Linq;

namespace HoursKeeper.Application.Projects.Commands.CreateProject
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator(DatabaseContext context)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Name).Must(n => !context.Projects.Any(m => m.Name == n))
                .WithMessage("Project name is not unique");
        }
    }
}
