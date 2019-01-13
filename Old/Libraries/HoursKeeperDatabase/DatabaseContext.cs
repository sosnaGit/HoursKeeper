using HoursKeeperDatabase.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace HoursKeeperDatabase
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DatabaseContext() :
            base(new SQLiteConnection()
            {
                ConnectionString = 
                    new SQLiteConnectionStringBuilder()
                    {
                        DataSource = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "database.db"),
                        ForeignKeys = true
                    }.ConnectionString
            }, true)
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
