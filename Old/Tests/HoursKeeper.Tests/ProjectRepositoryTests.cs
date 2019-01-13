using NUnit.Framework;
using HoursKeeper.Database.Models;
using HoursKeeper.Database.Repositories;
using HoursKeeper.Old.Common;
using System.Linq;

namespace HoursKeeper.Old.Tests
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

        [Test]
        public void AddNotUniqueProject()
        {
            _repo.AddProject(new Project { Name = "test234" });
            
            Assert.Throws<NotUniqueException>(() => _repo.AddProject(new Project { Name = "test234" }));
            _repo.SaveChanges();

            Assert.AreEqual(_repo.Count(), 1);
        }

        [Test]
        public void GetProjectById()
        {
            _repo.AddProject(new Project { Id = 1, Name = "name" });
            _repo.SaveChanges();

            var project = _repo.GetProject(1);

            Assert.AreEqual(project.Name, "name");
        }

        [Test]
        public void GetProjectByName()
        {
            _repo.AddProject(new Project { Id = 1, Name = "name" });
            _repo.SaveChanges();

            var project = _repo.GetProjectByName("name");

            Assert.AreEqual(project.Name, "name");
        }

        [Test]
        public void GetAllProjects()
        {
            _repo.AddProject(new Project { Id = 1, Name = "name" });
            _repo.AddProject(new Project { Id = 2, Name = "name1" });
            _repo.AddProject(new Project { Id = 3, Name = "name2" });
            _repo.SaveChanges();

            var projects = _repo.GetAllProjects();

            Assert.AreEqual(projects.Count(), 3);
        }

        [Test]
        public void CountAllProjects()
        {
            _repo.AddProject(new Project { Id = 1, Name = "name1" });
            _repo.AddProject(new Project { Id = 2, Name = "name2" });
            _repo.AddProject(new Project { Id = 3, Name = "name3" });
            _repo.SaveChanges();

            var count = _repo.Count();

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void CountProjectsWithExpression()
        {
            _repo.AddProject(new Project { Id = 1, Name = "abc" });
            _repo.AddProject(new Project { Id = 2, Name = "name1" });
            _repo.AddProject(new Project { Id = 3, Name = "name2" });
            _repo.SaveChanges();

            var count = _repo.Count(x => x.Name.Contains("name"));

            Assert.AreEqual(count, 2);
        }

        [Test]
        public void UpdateProject()
        {
            _repo.AddProject(new Project { Id = 1, Name = "test234" });
            _repo.SaveChanges();

            var project = _repo.GetProject(1);
            project.Name = "new name";

            _repo.SaveChanges();

            project = _repo.GetProject(1);

            Assert.AreEqual(_repo.Count(), 1);
            Assert.AreEqual(project.Name, "new name");
        }

        [Test]
        public void DeleteProject()
        {
            _repo.AddProject(new Project { Id = 1, Name = "test234" });
            _repo.AddProject(new Project { Id = 2, Name = "test2345" });
            _repo.AddProject(new Project { Id = 3, Name = "test2" });
            _repo.SaveChanges();

            _repo.DeleteProject(1);
            _repo.SaveChanges();

            var project = _repo.GetProject(1);

            Assert.AreEqual(_repo.Count(), 2);
            Assert.AreEqual(project, null);
        }

        [Test]
        public void DeleteNotExistingProject()
        {
            _repo.AddProject(new Project { Id = 1, Name = "test234" });
            _repo.AddProject(new Project { Id = 2, Name = "test2345" });
            _repo.AddProject(new Project { Id = 3, Name = "test2" });
            _repo.SaveChanges();

            Assert.Throws<EntityNotExistException>(() => _repo.DeleteProject(4));
        }
    }
}