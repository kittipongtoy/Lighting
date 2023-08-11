using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Download;
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
            Projects.ForEach(x =>
            {
                x.Profile_Image = Path.Combine(x.Folder_Path, x.Profile_Image);
            });

            mymodal.DATA = DATA;
            var latestDownloads = _db.Downloads
            .Where(x => x.use_status == 1)
            .GroupBy(x => x.DownloadType_id)
            .Select(group => group.OrderByDescending(x => x.id).FirstOrDefault())
            .ToList();
            mymodal.Product = Products;
            mymodal.Project = Projects;
            mymodal.Download = latestDownloads;
            return View(mymodal);
        }
    }
}
