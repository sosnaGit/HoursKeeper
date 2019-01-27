using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Projects.Commands.CreateProject
{
    public class CreateProjectHandler : IHandleCommand<CreateProjectCommand>
    {
        public void Handle(CreateProjectCommand command, DatabaseContext context, bool shouldSaveChanges = true)
        {
            var validator = new CreateProjectValidator(context);

            var result = validator.Validate(command);

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
