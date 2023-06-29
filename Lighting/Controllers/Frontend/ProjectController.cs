using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Frontend
{
    public class ProjectController : Controller
    {
        public IActionResult Project()
        {
            return View();
        }

        public IActionResult Project_Category()
        {
            return View();
        }

        public IActionResult Project_Detail()
        {
            return View();
        }
    }
}
