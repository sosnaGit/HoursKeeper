using HoursKeeper.Application.Interfaces;

namespace HoursKeeper.Application.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : ICommand
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
