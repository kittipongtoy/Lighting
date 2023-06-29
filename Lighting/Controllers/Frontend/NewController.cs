using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Frontend
{
    public class NewController : Controller
    {
        public IActionResult New()
        {
            return View();
        }

        public IActionResult NewDetail()
        {
            return View();
        }
    }
}
