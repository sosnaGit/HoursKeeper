using HoursKeeper.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Reflection;

namespace HoursKeeper.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) :
            base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "database.db")}");
            }
        }
    }
}
