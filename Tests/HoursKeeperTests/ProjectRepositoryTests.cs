using HoursKeeperDatabase;
using HoursKeeperDatabase.Models;
using HoursKeeperDatabase.Repositories;
using NUnit.Framework;

namespace HoursKeeperTests
{
    [TestFixture]
    public class UnitTest1
    {
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
