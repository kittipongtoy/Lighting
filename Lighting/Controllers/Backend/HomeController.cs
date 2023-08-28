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
        //
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

        public IActionResult update1(IFormFile image1,string? Link)
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
                    Link = Link,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    isActive = true,
                    sort = _db.Slide_Image_Index.OrderByDescending(x => x.sort).FirstOrDefault() == null ? 1 : _db.Slide_Image_Index.OrderByDescending(x => x.sort).FirstOrDefault().sort
                });
            }
            _db.SaveChanges();
            return Redirect("/Home/settingslide");
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

        [HttpPost]
        public async Task<IActionResult> BannerChange(int? Id)
        {
            try
            {
                var DB = _db.Slide_Image_Index.FirstOrDefault(x => x.id_slideimg_index == Id);
                if (DB is not null)
                {
                    if (DB.isActive)
                    {
                        DB.isActive = false;
                    }
                    else
                    {
                        DB.isActive = true;
                    }
                    _db.Entry(DB).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> BannerDelete(int? Id)
        {
            try
            {
                var DB = _db.Slide_Image_Index.FirstOrDefault(x => x.id_slideimg_index == Id);
                if (DB is not null)
                {
                    var old_filePath = Path.Combine(_env.WebRootPath, "upload_image/Index/" + DB.PathImg);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    _db.Slide_Image_Index.Remove(DB);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult ShowProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DataTableShowProduct()
        {
            try
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
                var list = new List<ResponseDTO.Product_CategoryResponse>();
                var Products = await _db.Products.ToListAsync();
                int? runitem = 1;
                foreach (var item in Products)
                {
                    list.Add(new ResponseDTO.Product_CategoryResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Type_TH = item.Type_TH,
                        Type_EN = item.Type_EN,
                        ShowItem = item.ShowItem
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Type_TH.Contains(searchValue)
                    || x.Type_EN.Contains(searchValue)).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeShowProduct(int? Id)
        {
            try
            {
                var DB = _db.Products.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.ShowItem == 1)
                    {
                        DB.ShowItem = 0;
                    }
                    else
                    {
                        DB.ShowItem = 1;
                    }
                    _db.Entry(DB).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult ShowProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DataTableShowProject()
        {
            try
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
                var list = new List<ResponseDTO.ProjectRefResponse>();
                var History = await _db.ProjectRefs.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.ProjectRefResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        ShowItem = item.ShowItem,
                        Title_TH = item.Title_TH,
                        Title_EN = item.Title_EN,
                        Profile_Image = item.Profile_Image,
                        Folder_Path = item.Folder_Path,
                        Location_TH = item.Location_TH,
                        Location_EN = item.Location_EN,
                        Client = item.Client,
                        Design_Solution = item.Design_Solution,
                        Photo_Credit = item.Photo_Credit,
                        Content_TH = item.Content_TH,
                        Content_EN = item.Content_EN,
                        Pdf_TH = item.Pdf_TH,
                        Pdf_ENG = item.Pdf_ENG,
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Title_TH.Contains(searchValue)
                    || x.Title_EN.Contains(searchValue)
                    || x.Location_TH.Contains(searchValue)
                    || x.Location_EN.Contains(searchValue)).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeShowProject(int? Id)
        {
            try
            {
                var DB = _db.ProjectRefs.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.ShowItem == 1)
                    {
                        DB.ShowItem = 0;
                    }
                    else
                    {
                        DB.ShowItem = 1;
                    }
                    _db.Entry(DB).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult ShowDownload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DatatableShowDownload()
        {
            try
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
                var list = new List<ResponseDTO.DownloadResponse>();
                var History = await _db.Downloads.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.DownloadResponse
                    {
                        Index = runitem,
                        id = item.id,
                        Name_TH = item.Name_TH,
                        Name_EN = item.Name_EN,
                        ShowItem = item.ShowItem,
                        use_status = item.use_status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Name_TH.Contains(searchValue)
                    || x.Name_EN.Contains(searchValue)).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeShowDownload(int? Id)
        {
            try
            {
                var DB = _db.Downloads.FirstOrDefault(x => x.id == Id);
                if (DB is not null)
                {
                    if (DB.ShowItem == 1)
                    {
                        DB.ShowItem = 0;
                    }
                    else
                    {
                        DB.ShowItem = 1;
                    }
                    _db.Entry(DB).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }
    }
}
