using System;
using HoursKeeper.Domain.Entities;
using HoursKeeper.Application.Interfaces;

namespace HoursKeeper.Application.Schedules.Commands.CreateSchedule
{
    public class CreateScheduleCommand : ICommand
    {
        public virtual DateTime Date { get; set; }

        public virtual Project Project { get; set; }

        public double SpentTime { get; set; }

        public string Note { get; set; }
    }
}
