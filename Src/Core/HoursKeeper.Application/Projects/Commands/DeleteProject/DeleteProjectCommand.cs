using HoursKeeper.Application.Interfaces;

namespace HoursKeeper.Application.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : ICommand
    {
        public long Id { get; set; }
    }
}
