using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


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

        public async Task<IActionResult> Index()
        {
            var Setting_Index = await _db.Setting_Index.ToListAsync();
            //var Products = await _db.Product_Categorys.Where(x=>x.ShowItem == 1).OrderByDescending(x => x.Id).Take(6).ToListAsync();
            var Products = await _db.Products.Where(x => x.ShowItem == 1).OrderByDescending(x => x.Id).Take(6).ToListAsync();
            var Projects = await _db.ProjectRefs.Where(x=>x.ShowItem == 1).OrderByDescending(x => x.Id).Take(4).ToListAsync();

            Products.ForEach(x =>
            {
                x.Preview_Image_Index = Path.Combine(x.Folder_Path, x.Preview_Image_Index);
            });
            Projects.ForEach(x =>
            {
                x.Profile_Image = Path.Combine(x.Folder_Path, x.Profile_Image);
            });
            //var latestDownloads = await _db.Downloads.Where(x => x.use_status == 1 && x.ShowItem == 1).GroupBy(x => x.DownloadType_id).Select(group => group.OrderByDescending(x => x.id).FirstOrDefault()).ToListAsync();
            var latestDownloads = await _db.Downloads.Where(x => x.use_status == 1 && x.ShowItem == 1).ToListAsync();
            var Finance_Statement = await _db.SH_IR_Finance_Statement.Where(x => x.active_status == 1).ToListAsync();

            var Slide_Image_Index = await _db.Slide_Image_Index.Where(x => x.isActive == true).ToListAsync();
            ViewBag.Slide_Image_Index = Slide_Image_Index;
            ViewBag.Setting_Index = Setting_Index;
            ViewBag.Products = Products;
            ViewBag.Project = Projects;
            ViewBag.latestDownloads = latestDownloads;
            ViewBag.Finance_Statement = Finance_Statement;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBanner()
        {
            var DB = await _db.Slide_Image_Index.ToListAsync();
            return Ok(DB);
        }
    }
}
