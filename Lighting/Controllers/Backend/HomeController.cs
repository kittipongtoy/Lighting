using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class HomeController : Controller
	{
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly string _rootPath;
        public HomeController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
            _rootPath = _env.WebRootPath;
        }
        public IActionResult Index()
        {

            var DATA = _db.Setting_Index.FirstOrDefault();
            return View(DATA);
        }

        public IActionResult settingslide()
        {
            return View();
        }

        public IActionResult update(IndexSetting.Index data)
        {
            var data1 = _db.Setting_Index.FirstOrDefault();
            if (data1 == null)
            {
                var path = "";
                if (data.PathImg != null)
                {
                    if (data.PathImg.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(data.PathImg.FileName);
                        extension = extension.Replace(" ", "");
                        path = datestr + extension;
                        var filePath = Path.Combine(_env.WebRootPath, "upload_image/Index/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            data.PathImg.CopyTo(stream);
                        }
                    }
                }
                _db.Setting_Index.Add(new SettingIndex
                {
                    titleTH1 = data.titleTH1,
                    titleENG1 = data.titleENG1,
                    titleENG2 = data.titleENG2,
                    titleENG3 = data.titleENG3,
                    titlesubTH2 = data.titlesubTH2,
                    titlesubENG2 = data.titlesubENG2,
                    titleTH2 = data.titleTH2,
                    titleTH3 = data.titleTH3,
                    DescriptTH2 = data.DescriptTH2,
                    DescriptTH3 = data.DescriptTH3,
                    DescriptENG2 = data.DescriptENG2,
                    DescriptENG3 = data.DescriptENG3,
                    titleTH4 = data.titleTH4,
                    titlesubTH4 = data.titlesubTH4,
                    titlesubENG4 = data.titlesubENG4,
                    titleENG4 = data.titleENG4,
                    PathImg = path,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now

                });
            }
            else
            {
                data1.titleTH1 = data.titleTH1;
                data1.titleENG1 = data.titleENG1;
                data1.titleENG2 = data.titleENG2;
                data1.titlesubTH2 = data.titlesubTH2;
                data1.titlesubENG2 = data.titlesubENG2;
                data1.titleTH2 = data.titleTH2;
                data1.titleTH3 = data.titleTH3;
                data1.titleENG3 = data.titleENG3;
                data1.DescriptTH2 = data.DescriptTH2;
                data1.DescriptENG2 = data.DescriptENG2;
                data1.DescriptENG3 = data.DescriptENG3;
                data1.DescriptENG2 = data.DescriptENG2;
                data1.titleTH4 = data.titleTH4;
                data1.titleENG4 = data.titleENG4;
                data1.titlesubTH4 = data.titlesubTH4;
                data1.titlesubENG4 = data.titlesubENG4;
                if (data.PathImg != null)
                {
                    if (data.PathImg.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(data.PathImg.FileName);
                        extension = extension.Replace(" ", "");
                        data1.PathImg = datestr + extension;
                        var filePath = Path.Combine(_env.WebRootPath, "upload_image/Index/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            data.PathImg.CopyTo(stream);
                        }
                    }
                }
                data1.updated_at = DateTime.Now;
            }
            _db.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult update1(IFormFile image1)
        {

            if (image1.Length > 0)
            {
                var image = "";
                var datestr = DateTime.Now.Ticks.ToString();
                var extension = Path.GetExtension(image1.FileName);
                extension = extension.Replace(" ", "");
                image = datestr + extension;
                var filePath = Path.Combine(_env.WebRootPath, "upload_image/Index/" + datestr + extension);

                using (var stream = System.IO.File.Create(filePath))
                {
                    image1.CopyTo(stream);
                }
                _db.Slide_Image_Index.Add(new SlideImageIndex
                {
                    PathImg = image,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isActive = true,
                    sort = _db.Slide_Image_Index.OrderByDescending(x => x.sort).FirstOrDefault() == null ? 1 : _db.Slide_Image_Index.OrderByDescending(x => x.sort).FirstOrDefault().sort
                });
            }
            _db.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult up(int ids, int sortc)
        {
            var data = _db.Slide_Image_Index.Find(ids);
            var sorts = _db.Slide_Image_Index.Where(x => x.sort == (sortc - 1)).FirstOrDefault();
            data.sort = (sortc - 1);
            if (sorts != null)
            {
                sorts.sort = (sortc + 1);
            }
            _db.SaveChanges();
            return Ok("success");
        }

        public IActionResult down(int ids, int sortc)
        {
            var data = _db.Slide_Image_Index.Find(ids);
            var sorts = _db.Slide_Image_Index.Where(x => x.sort == (sortc + 1)).FirstOrDefault();

            data.sort = (sortc + 1);
            if (sorts != null)
            {
                sorts.sort = (sortc - 1);
            }
            _db.SaveChanges();
            return Ok("success");
        }

        public IActionResult datatable()
        {
            string? draw = Request.Form["draw"];
            string? start = Request.Form["start"];
            string? length = Request.Form["length"];
            string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
            string? sortColumnDirection = Request.Form["order[0][dir]"];
            string? searchValue = Request.Form["search[value]"];
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int? recordsTotal = 0;
            var IR_Contact = _db.Slide_Image_Index.ToList();

            recordsTotal = IR_Contact.Count;
            IR_Contact = IR_Contact.Skip(skip).Take(pageSize).ToList();

            var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = IR_Contact };
            return Ok(jsonData);
        }
    }
}
