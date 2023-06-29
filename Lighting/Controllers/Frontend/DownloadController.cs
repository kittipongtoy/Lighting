using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Frontend
{
    public class DownloadController : Controller
    {
        public IActionResult Download()
        {
            return View();
        }
    }
}
