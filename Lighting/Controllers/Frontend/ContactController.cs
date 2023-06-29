using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Frontend
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
