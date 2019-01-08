using System;
using System.Collections.Generic;
using HoursKeeper.Database.Models;

namespace HoursKeeper.Database.Repositories.Interfaces
{
    public interface IScheduleRepository : IDisposable
    {
        Schedule GetSchedule(long id);

        IEnumerable<Schedule> GetSchedulesByDate(DateTime startDate, DateTime endDate);

        IEnumerable<Schedule> GetSchedulesByProject(Project project);

        IEnumerable<Schedule> GetAllSchedules();

        long Count(Func<Schedule, bool> function = null);

        void AddSchedule(Schedule schedule);

        void DeleteSchedule(long id);

        void SaveChanges();
    }
}