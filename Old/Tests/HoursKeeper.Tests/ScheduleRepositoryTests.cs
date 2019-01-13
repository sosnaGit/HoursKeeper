using System.Linq;
using NUnit.Framework;
using HoursKeeper.Old.Common;
using HoursKeeper.Database.Models;
using HoursKeeper.Database.Repositories;
using System;

namespace HoursKeeper.Old.Tests
{
    [TestFixture]
    public class ScheduleRepositoryTests : BaseTestsClass
    {
        private ScheduleRepository _repo;
        private ProjectRepository _projectRepo;

        [SetUp]
        public override void Configure()
        {
            base.Configure();
            _repo = new ScheduleRepository(_context);
            _projectRepo = new ProjectRepository(_context);
        }

        [Test]
        public void AddSingleSchedule()
        {
            var project = AddProject("proj");

            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project, SpentTime = 1.5, Note = "test" });
            _repo.SaveChanges();

            Assert.AreEqual(_repo.Count(), 1);
        }

        [Test]
        public void AddMultipleSchedules()
        {
            var project = AddProject("proj");

            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.SaveChanges();

            Assert.AreEqual(_repo.Count(), 3);
        }

        [Test]
        public void GetScheduleById()
        {
            var project = AddProject("proj");

            _repo.AddSchedule(new Schedule { Id = 1, CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.SaveChanges();

            var schedule = _repo.GetSchedule(1);

            Assert.AreEqual(schedule.Id, 1);
        }

        [Test]
        public void GetSchedulesByProject()
        {
            var project = AddProject("proj");
            var project2 = AddProject("proj2");

            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project2 });
            _repo.SaveChanges();

            var schedules = _repo.GetSchedulesByProject(project);

            Assert.AreEqual(schedules.Count(), 2);
            Assert.IsTrue(schedules.All(x => x.Project == project)); 
        }

        [Test]
        public void GetSchedulesByDate()
        {
            var project = AddProject("proj");
            var project2 = AddProject("proj2");
            var start = DateTime.Now;
            var end = DateTime.Now.AddDays(1);

            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = start, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = end, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = start.AddHours(-1), Project = project2 });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = start.AddHours(1), Project = project2 });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = end.AddHours(1), Project = project2 });
            _repo.SaveChanges();

            var schedules = _repo.GetSchedulesByDate(start, end);

            Assert.AreEqual(schedules.Count(), 3);
        }

        [Test]
        public void GetAllSchedules()
        {
            var project = AddProject("proj");

            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.SaveChanges();

            var schedules = _repo.GetAllSchedules();

            Assert.AreEqual(schedules.Count(), 3);
        }

        [Test]
        public void CountAllElements()
        {
            var project = AddProject("proj");

            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.SaveChanges();

            var count = _repo.Count();

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void CountWithExpression()
        {
            var project = AddProject("proj");
            var project2 = AddProject("proj2");
            var date = DateTime.Now;
            var date2 = DateTime.Now.AddDays(1);
             
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = date, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = date2, Project = project });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = date, Project = project2 });
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = date, Project = project2 });
            _repo.SaveChanges();

            var count = _repo.Count(x => x.Date == date);

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void UpdateSchedule()
        {
            var project = AddProject("proj");
            _repo.AddSchedule(new Schedule { CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.SaveChanges();

            var schedule = _repo.GetSchedule(1);

            var date = DateTime.Now.AddDays(1);
            schedule.Date = date;

            _repo.SaveChanges();

            schedule = _repo.GetSchedule(1);

            Assert.AreEqual(_repo.Count(), 1);
            Assert.AreEqual(schedule.Date, date);
        }

        [Test]
        public void DeleteSchedule()
        {
            var project = AddProject("proj");
            _repo.AddSchedule(new Schedule { Id = 1, CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { Id = 2, CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { Id = 3, CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.SaveChanges();

            _repo.DeleteSchedule(1);
            _repo.SaveChanges();

            var Schedule = _repo.GetSchedule(1);

            Assert.AreEqual(_repo.Count(), 2);
            Assert.AreEqual(Schedule, null);
        }

        [Test]
        public void DeleteNotExistingSchedule()
        {
            var project = AddProject("proj");
            _repo.AddSchedule(new Schedule { Id = 1, CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { Id = 2, CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.AddSchedule(new Schedule { Id = 3, CreateDate = DateTime.Now, Date = DateTime.Now, Project = project });
            _repo.SaveChanges();
            
            Assert.Throws<EntityNotExistException>(() => _repo.DeleteSchedule(4));
        }

        private Project AddProject(string name)
        {
            var project = new Project { Name = name };
            
            _projectRepo.AddProject(project);
            _projectRepo.SaveChanges();

            return project;
        }
    }
}