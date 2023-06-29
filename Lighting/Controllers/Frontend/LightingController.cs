using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Frontend
{
    public class LightingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
