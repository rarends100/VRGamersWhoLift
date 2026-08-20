using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VRGamersWhoLift.Helpers;

namespace VRGamersWhoLift.Controllers
{
    public class ImageController : Controller
    {
        [Authorize(Roles = $"{RolesControlClass.Member}, {RolesControlClass.Coach}, {RolesControlClass.Administrator}")]
        public IActionResult PhotoChooserPartial() //renders the partial view on the page, in this case _ImageChooser
        {
            return PartialView("_ImageChooser");
        }
    }
}
