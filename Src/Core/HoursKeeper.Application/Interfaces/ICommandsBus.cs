using HoursKeeper.Persistence;

namespace HoursKeeper.Application.Interfaces
{
    public interface ICommandsBus
    {
        void Send<TCommand>(TCommand command, DatabaseContext context) where TCommand : ICommand;
    }
}
