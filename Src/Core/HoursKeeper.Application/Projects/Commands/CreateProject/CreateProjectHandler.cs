using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Projects.Commands.CreateProject
{
    public class CreateProjectHandler : IHandleCommand<CreateProjectCommand>
    {
        private readonly CreateProjectValidator _validator;

        public CreateProjectHandler()
        {
            _validator = new CreateProjectValidator();
        }

        public void Handle(CreateProjectCommand command, DatabaseContext context, bool shouldSaveChanges = false)
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

            if (shouldSaveChanges)
                context.SaveChanges();
        }
    }
}
