using System;
using System.ComponentModel.DataAnnotations;

namespace HoursKeeper.Database.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public virtual DateTime Date { get; set; }

        [Required]
        public virtual Project Project { get; set; }

        [Required]
        public double SpentTime { get; set; }
        
        public string Note { get; set; }
    }
}