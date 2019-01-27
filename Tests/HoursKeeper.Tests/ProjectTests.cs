using HoursKeeper.Application.Exceptions;
using HoursKeeper.Application.Projects.Commands.CreateProject;
using HoursKeeper.Application.Projects.Queries.GetProject;
using HoursKeeper.Tests;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class ProjectTests : BaseTestsClass
    {
        [SetUp]
        public override void Configure()
        {
            base.Configure();
        }


        [Test]
        public void AddValidProject()
        {
            var handler = new CreateProjectHandler();

            handler.Handle(new CreateProjectCommand
            {
                Name = "new project"
            }, _context);

            var getHandler = new GetProjectHandler();

            var result = getHandler.Handle(new GetProjectQuery
            {
                Id = 1
            }, _context);

            Assert.AreEqual("new project", result.Name);
            Assert.AreEqual(1, _context.Projects.Count());
        }

        [Test]
        public void AddNotUniqueProject()
        {
            var handler = new CreateProjectHandler();

            var project = new CreateProjectCommand
            {
                Name = "new project"
            };

            handler.Handle(project, _context);
            
            Assert.Throws<CustomValidationException>(() => handler.Handle(project, _context), 
                "Project name is not unique");
            
            Assert.AreEqual(1, _context.Projects.Count());
        }
    }
}