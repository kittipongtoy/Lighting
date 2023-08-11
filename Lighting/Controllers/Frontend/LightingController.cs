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
            var downloads = _db.Downloads.OrderByDescending(x => x.Id).Where(download => download.DownloadType == "CATALOGUE").Take(4).ToList();
            var Downloads = downloads.Select(download => new Output_DownloadVM
            {
                Id = download.Id,
                Name_EN = download.Name_EN,
                Name_TH = download.Name_TH,
                File = GetFileName(download.File_Path),
                Image = download.File_Path + "/0.jpg",
                File_EN = GetFileName_EN(download.File_Path_EN),
                Image_EN = download.File_Path_EN + "/1.jpg",

            });
            mymodal.DATA = DATA;

            mymodal.Product = Products;
            mymodal.Project = Projects;
            mymodal.Download = Downloads;
            return View(mymodal);
        }
        private string? GetFileName(string path)
        {
            try
            {
                var path_folder = Path.Combine(_env.WebRootPath, path);
                if (Directory.Exists(path_folder))
                {
                    return Directory.GetFiles(path_folder)
                                         .Where(file => Path.GetFileName(file).StartsWith("00"))
                                         .FirstOrDefault()
                                         .Split("\\")
                                         .Reverse()
                                         .Take(4)
                                         .Reverse()
                                         .Aggregate("", (prev, curr) => prev + "/" + curr);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
        private string? GetFileName_EN(string path)
        {
            try
            {
                var path_folder = Path.Combine(_env.WebRootPath, path);
                if (Directory.Exists(path_folder))
                {
                    return Directory.GetFiles(path_folder)
                                         .Where(file => Path.GetFileName(file).StartsWith("11"))
                                         .FirstOrDefault()
                                         .Split("\\")
                                         .Reverse()
                                         .Take(4)
                                         .Reverse()
                                         .Aggregate("", (prev, curr) => prev + "/" + curr);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
