using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class AnalystController : Controller
	{
		public IActionResult Analyst()
		{
			return View();
		}

		public IActionResult Analyst_Chapter()
		{
			return View();
		}
	}
}
