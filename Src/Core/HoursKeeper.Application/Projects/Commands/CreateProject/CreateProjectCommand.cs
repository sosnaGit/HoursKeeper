using HoursKeeper.Application.Interfaces;

namespace HoursKeeper.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommand : ICommand
    {
        public string Name { get; set; }
    }
}
