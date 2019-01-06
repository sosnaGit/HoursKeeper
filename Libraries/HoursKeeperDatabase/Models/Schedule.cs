using System;

namespace HoursKeeperDatabase.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual Project Project { get; set; }

        public double SpentTime { get; set; }

        public string Note { get; set; }
    }
}
