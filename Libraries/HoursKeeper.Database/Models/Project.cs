using System.ComponentModel.DataAnnotations;

namespace HoursKeeper.Database.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
