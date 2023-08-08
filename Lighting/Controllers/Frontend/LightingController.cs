using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Lighting.Controllers.Frontend
{
    public class LightingController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly string _rootPath;
        public LightingController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
            _rootPath = _env.WebRootPath;
        }
        public IActionResult Index()
        {
            dynamic mymodal = new ExpandoObject();
            var DATA = _db.Setting_Index.FirstOrDefault();
            var Products = _db.Product_Categorys.OrderByDescending(x => x.Id).Take(6).ToList();
            var Projects = _db.ProjectRefs.OrderByDescending(x => x.Id).Take(4).ToList();
            var Downloads = _db.Downloads.OrderByDescending(x => x.Id).Take(4).ToList();
            mymodal.DATA = DATA;

            mymodal.Product = Products;
            mymodal.Project = Projects;
            mymodal.Download = Downloads;
            return View(mymodal);
        }
    }
}
