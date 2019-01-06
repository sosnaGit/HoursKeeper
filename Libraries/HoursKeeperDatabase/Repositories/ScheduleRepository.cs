using System;
using System.Linq;
using System.Collections.Generic;
using HoursKeeperDatabase.Models;
using HoursKeeperDatabase.Repositories.Interfaces;

namespace HoursKeeperDatabase.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DatabaseContext _context;

        public ScheduleRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void AddSchedule(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
        }

        public void DeleteSchedule(long id)
        {
            var schedule = GetSchedule(id);

            if (schedule == null)
                throw new Exception($"Schedule with id {id} does not exist");

            _context.Schedules.Remove(schedule);
        }

        public Schedule GetSchedule(long id)
        {
            return _context.Schedules.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Schedule> GetSchedulesByDate(DateTime startDate, DateTime endDate)
        {
            return _context.Schedules.Where(x => x.Date >= startDate && x.Date <= endDate);
        }

        public IEnumerable<Schedule> GetSchedulesByProject(Project project)
        {
            return _context.Schedules.Where(x => x.Project == project);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
