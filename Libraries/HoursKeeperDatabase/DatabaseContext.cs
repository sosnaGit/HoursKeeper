using HoursKeeperDatabase.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HoursKeeperDatabase
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DatabaseContext()
        {
            // Turn off the Migrations, (NOT a code first Db)
            Database.SetInitializer<DatabaseContext>(null);
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
