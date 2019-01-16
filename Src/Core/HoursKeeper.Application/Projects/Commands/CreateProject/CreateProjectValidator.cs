using FluentValidation;

namespace HoursKeeper.Application.Projects.Commands.CreateProject
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3);
        }
    }
}
