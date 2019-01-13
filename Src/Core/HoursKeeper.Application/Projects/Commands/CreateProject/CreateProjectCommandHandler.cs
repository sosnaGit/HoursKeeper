using HoursKeeper.Application.Interfaces;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IHandleCommand<CreateProjectCommand>
    {
        private DatabaseContext _context;

        public CreateProjectCommandHandler(DatabaseContext context)
        {
            _context = context;
        }

        public void Handle(CreateProjectCommand command)
        {
            _context.Projects.Add(new Project
            {
                Name = command.Name
            });
            _context.SaveChanges();
        }
    }
}
