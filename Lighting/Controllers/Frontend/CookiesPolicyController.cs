using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Lighting.Controllers.Frontend
{
    public class CookiesPolicyController : Controller
    {
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public CookiesPolicyController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }
        public async Task<IActionResult> CookiesPolicy()
        {
            ViewBag.cookies_Contact = await db.cookies_policy.ToListAsync();
            return View();
        }
    }
}
