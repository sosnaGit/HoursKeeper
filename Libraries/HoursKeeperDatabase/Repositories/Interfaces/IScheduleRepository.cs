using System;
using System.Collections.Generic;
using HoursKeeperDatabase.Models;

namespace HoursKeeperDatabase.Repositories.Interfaces
{
    public interface IScheduleRepository : IDisposable
    {
        Schedule GetSchedule(long id);

        IEnumerable<Schedule> GetSchedulesByDate(DateTime startDate, DateTime endDate);

        IEnumerable<Schedule> GetSchedulesByProject(Project project);

        void AddSchedule(Schedule schedule);

        void DeleteSchedule(long id);
    }
}