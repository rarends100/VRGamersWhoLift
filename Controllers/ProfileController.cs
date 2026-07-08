using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Models.database;

namespace VRGamersWhoLift.Controllers
{
    public class ProfileController : Controller
    {
        private readonly VRGamersWhoLiftContext context;
        public ProfileController(VRGamersWhoLiftContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public IActionResult Profile()
        {
            

            return View();
        }
    }
}
