using HoursKeeperDatabase;
using HoursKeeperDatabase.Models;
using HoursKeeperDatabase.Repositories;
using NUnit.Framework;

namespace HoursKeeperTests
{
    [TestFixture]
    public class ProjectRepositoryTests
    {
        private DatabaseContext _context;

        [SetUp]
        public void Configure()
        {
            _context = new DatabaseContext();
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public void TestMethod1()
        {
            using (var context = new DatabaseContext())
            {
                var projectRepository = new ProjectRepository(context);

                projectRepository.AddProject(new Project
                {
                    Name = "test234"
                });

                projectRepository.SaveChanges();
                projectRepository.Dispose();
            }

            Assert.AreEqual(1, 1);
        }
    }
}
