using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;
using System.Linq;

namespace HoursKeeper.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectHandler : IHandleCommand<DeleteProjectCommand>
    {
        private readonly DeleteProjectValidator _validator;

        public DeleteProjectHandler()
        {
            _validator = new DeleteProjectValidator();
        }

        public void Handle(DeleteProjectCommand command, DatabaseContext context, bool shouldSaveChanges)
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

            context.Projects.Remove(project);

            if (shouldSaveChanges)
                context.SaveChanges();
        }
    }
}
