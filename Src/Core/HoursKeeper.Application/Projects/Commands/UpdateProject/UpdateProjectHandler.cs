using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;
using System.Linq;

namespace HoursKeeper.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectHandler : IHandleCommand<UpdateProjectCommand>
    {
        private readonly UpdateProjectValidator _validator;

        public UpdateProjectHandler()
        {
            _validator = new UpdateProjectValidator();
        }

        public void Handle(UpdateProjectCommand command, DatabaseContext context, bool shouldSaveChanges = true)
        {
            var result = _validator.Validate(command);

            if (!result.IsValid)
            {
                throw new CustomValidationException(result.Errors);
            }

            var project = context.Projects.FirstOrDefault(x => x.Id == command.Id);

            if (project == null)
            {
                throw new ObjectNotFoundException(nameof(Project), command.Id);
            }

            project.Name = command.Name;

            if (shouldSaveChanges)
                context.SaveChanges();
        }
    }
}
