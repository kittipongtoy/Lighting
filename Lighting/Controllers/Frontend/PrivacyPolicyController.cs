using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Lighting.Controllers.Frontend
{
    public class PrivacyPolicyController : Controller
    {
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public PrivacyPolicyController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }
        public async Task<IActionResult> PrivacyPolicy()
        {
            ViewBag.privacy_Header = await db.privacy_PolicyTitles.ToListAsync();

            ViewBag.privacy_Contact_1 = await db.privacy_Policys.Where(x=>x.active_status==1&&x.typeOfPolicy_id==1).ToListAsync();
            ViewBag.privacy_Contact_2 = await db.privacy_Policys.Where(x => x.active_status == 1 && x.typeOfPolicy_id == 2).ToListAsync();
            ViewBag.privacy_Contact_3 = await db.privacy_Policys.Where(x => x.active_status == 1 && x.typeOfPolicy_id == 3).ToListAsync();

            return View();
        }
    }
}
