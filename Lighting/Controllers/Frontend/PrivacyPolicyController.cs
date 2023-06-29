using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Frontend
{
    public class PrivacyPolicyController : Controller
    {
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}
