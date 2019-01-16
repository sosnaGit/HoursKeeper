using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IHandleCommand<CreateProjectCommand>
    {
        private CreateProjectValidator _validator;

        public CreateProjectCommandHandler()
        {
            _validator = new CreateProjectValidator();
        }

        public void Handle(CreateProjectCommand command, DatabaseContext context)
        {
            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                throw new CustomValidationException(result.Errors);
            }

            context.Projects.Add(new Project
            {
                Name = command.Name
            });

            context.SaveChanges();
        }
    }
}
