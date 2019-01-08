using NUnit.Framework;
using HoursKeeper.Database.Models;
using HoursKeeper.Database.Repositories;

namespace HoursKeeper.Tests
{
    [TestFixture]
    public class ProjectRepositoryTests : BaseTestsClass
    {
        private ProjectRepository _repo;

        [SetUp]
        public override void Configure()
        {
            base.Configure();
            _repo = new ProjectRepository(_context);
        }

        [Test]
        public void AddSingleProject()
        {
            _repo.AddProject(new Project { Name = "test234" });
            _repo.SaveChanges();
            
            Assert.AreEqual(_repo.Count(), 1);
        }

        [Test]
        public void AddMultipleProjects()
        {
            _repo.AddProject(new Project { Name = "test234" });
            _repo.AddProject(new Project { Name = "test2345" });
            _repo.AddProject(new Project { Name = "test2" });
            _repo.SaveChanges();

            Assert.AreEqual(_repo.Count(), 3);
        }

        /*[Test]
        public void AddNotUniqueProjects()
        {
            _repo.AddProject(new Project { Name = "test234" });
            
            _repo.AddProject(new Project { Name = "test234" });
            _repo.SaveChanges();

            Assert.AreEqual(_repo.Count(), 3);
        }*/
    }
}