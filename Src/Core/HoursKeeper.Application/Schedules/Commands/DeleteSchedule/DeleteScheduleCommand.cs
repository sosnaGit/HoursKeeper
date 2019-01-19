using HoursKeeper.Application.Interfaces;

namespace HoursKeeper.Application.Schedules.Commands.DeleteSchedule
{
    public class DeleteScheduleCommand : ICommand
    {
        public long Id { get; set; }
    }
}
