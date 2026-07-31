using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models;

namespace VRGamersWhoLift.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        // I don't understand this yet, need to learn more. Autogened when project is first made
        /**
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */

    }
}
