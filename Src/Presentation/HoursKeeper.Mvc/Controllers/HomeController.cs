using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HoursKeeper.Mvc.Models;
using HoursKeeper.Application.Interfaces;
using HoursKeeper.Application.Projects.Commands.CreateProject;
using HoursKeeper.Persistence;

namespace HoursKeeper.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private ICommandsBus _bus;

        public HomeController(ICommandsBus bus)
        {
            _bus = bus;
        }

        public IActionResult Index()
        {
            var context = new DatabaseContext();
            _bus.Send(new CreateProjectCommand { Name = "he" }, context);
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
