using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HoursKeeper.Mvc.Models;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Application.Projects.Commands.CreateProject;
using HoursKeeper.Persistence;
using HoursKeeper.Application.Projects.Queries.GetProject;
using HoursKeeper.Domain.Entities;

namespace HoursKeeper.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private ICommandsBus _commands;
        private IQueriesBus _queries;

        public HomeController(ICommandsBus commands, IQueriesBus queries)
        {
            _commands = commands;
            _queries = queries;
        }

        public IActionResult Index()
        {
            var context = new DatabaseContext();
            _commands.Send(new CreateProjectCommand { Name = "he123" }, context);
            var result = _queries.Execute<GetProjectQuery, Project>(new GetProjectQuery { Id = 1 }, context, false);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
