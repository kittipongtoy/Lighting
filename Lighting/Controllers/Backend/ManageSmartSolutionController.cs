using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Backend
{
    public class ManageSmartSolutionController : Controller
    {
        public IActionResult Manage_Page()
        {
            return View();
        }

        public IActionResult Add_Page()
        {
            return View();
        }

        public IActionResult Edit_Page()
        {
            return View();
        }
    }
}
