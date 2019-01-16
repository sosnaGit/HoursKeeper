using HoursKeeper.Application.Modules;
using HoursKeeper.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "database")
                .Options;

            var context = new DatabaseContext();
            context.Database.EnsureCreated();   
        }
    }
}