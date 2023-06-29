using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class HomeController : Controller
	{       
        public IActionResult Index()
		{
			return View();
		}
	}
}
