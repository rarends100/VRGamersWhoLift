using Microsoft.AspNetCore.Mvc;

namespace VRGamersWhoLift.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult PhotoChooserPartial() //renders the partial view on the page, in this case _ImageChooser
        {
            return PartialView("_ImageChooser");
        }
    }
}
