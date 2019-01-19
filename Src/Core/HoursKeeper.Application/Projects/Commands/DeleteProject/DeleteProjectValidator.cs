using FluentValidation;

namespace HoursKeeper.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
