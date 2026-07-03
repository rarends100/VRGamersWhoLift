using Microsoft.AspNetCore.Mvc;

namespace VRGamersWhoLift.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Profile()
        {


            return View();
        }
    }
}
