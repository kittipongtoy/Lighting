using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Frontend
{
    public class CookiesPolicyController : Controller
    {
        public IActionResult CookiesPolicy()
        {
            return View();
        }
    }
}
