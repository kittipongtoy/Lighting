using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Download;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;

namespace Lighting.Controllers.Backend
{
    public class ManageDownloadController : Controller
    {
        readonly private LightingContext _db;
        readonly private IWebHostEnvironment _env;

        public ManageDownloadController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;

        }

        public async Task<IActionResult> CATALOGUE_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType == "CATALOGUE").ToList().Count;
            var is_only_one_page = false;
            if (page_count <= maximum_page)
            {
                pagination_page.Add(0);
                is_only_one_page = true;
            }
            else
            {
                var max_number_page = (int)(page_count / maximum_page);
                for (int page_num = 0; page_num < max_number_page; page_num += 1)
                {
                    pagination_page.Add(page_num * maximum_page);
                }
            }
            //if last page 
            if ((page_count % maximum_page) != 0 && !is_only_one_page)
            {
                pagination_page.Add(pagination_page[pagination_page.Count - 1] + maximum_page);
            }
            ViewBag.Pagination = pagination_page;
            ViewBag.CurrentPage = start;
            ViewBag.MaximumPage = pagination_page.Max();
            #endregion

            var download_list = await _db.Downloads
                .AsNoTracking()
                .Where(download => download.DownloadType == "CATALOGUE")
                .OrderByDescending(by => by.Id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            var output = download_list.Select(download => new Output_DownloadVM
            {
                Id = download.Id,
                Name_EN = download.Name_EN,
                Name_TH = download.Name_TH,
                File = GetFileName(download.File_Path),
                Image = download.File_Path + "/0.jpg",
            });


            return View(output);
        }
        public IActionResult COMPANY_PROFILE_Page()
        {
            return View();
        }
        public IActionResult IES_FILE_Page()
        {
            return View();
        }
        public IActionResult L_AND_BIM_OBJECT_Page()
        {
            return View();
        }
        public IActionResult LEAFLET_Page()
        {
            return View();
        }
        public async Task<IActionResult> Manage_Download_Page()
        {
            var downloads = await _db.Downloads
                .AsNoTracking()
                .OrderByDescending(download => download.Id)
                .Select(download => new Output_DownloadVM
                {
                    Id = download.Id,
                    DownloadType = download.DownloadType,
                    Image = download.File_Path + "/0.jpg" ,
                    File =download.File_Path,
                    Name_EN = download.Name_EN,
                    Name_TH = download.Name_TH,

                }).ToListAsync();

            downloads.ForEach(file =>
            {
                file.File = GetFileName(file.File);
            });

            return View(downloads);
        }
        [HttpGet]
        public async Task<IActionResult> Edit_Page([FromQuery] int id)
        {
            var download = await _db.Downloads.AsNoTracking().FirstOrDefaultAsync(download => download.Id == id);
            if (download != null)
            {
                var output = new Output_DownloadVM
                {
                    Id = download.Id,
                    DownloadType = download.DownloadType,
                    File = GetFileName(download.File_Path),
                    Image = download.File_Path+"/0.jpg",
                    Name_EN = download.Name_EN,
                    Name_TH = download.Name_TH,
                };
                return View(output);
            }
            return RedirectToAction("Manage_Download_Page");
        }

        public async Task<IActionResult> Edit([FromForm] Input_DownloadVM input, [FromQuery] int id)
        {
            var download = await _db.Downloads.FirstOrDefaultAsync(download => download.Id == id);
            if (download != null)
            {
                try
                {

                    if (input.Image != null)
                    {
                        var path = Path.Combine(_env.WebRootPath, download.File_Path, "0.jpg");
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                        using (var stream = new FileStream(path, FileMode.CreateNew))
                        {
                            await input.Image.CopyToAsync(stream);
                        }
                    }


                    var save_file_path = Path.Combine(_env.WebRootPath, download.File_Path);
                    if (input.File != null)
                    {
                        //get all files
                        var oldFile = Directory.GetFiles(save_file_path).Where(file => !file.EndsWith("0.jpg")).FirstOrDefault();
                        //delete old file
                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }
                        //save new file
                        using (var stream = new FileStream(Path.Combine(save_file_path ,input.File.FileName), FileMode.CreateNew))
                        {
                            await input.File.CopyToAsync(stream);
                        }
                    }


                    download.Name_EN = input.Name_EN;
                    download.Name_TH = input.Name_TH;
                    download.DownloadType = input.DownloadType;

                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = "เกิดข้อผิดพลาด" });
                }

            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }

        public IActionResult Add_Download_Page()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Download([FromForm] Input_DownloadVM input)
        {
            if (ModelState.IsValid)
            {

                var folder = Guid.NewGuid().ToString();
                var image_name = "0.jpg";
                var save_folder = Path.Combine("upload_file", "Download", folder);
                Directory.CreateDirectory(Path.Combine(_env.WebRootPath, save_folder, folder));
                try
                {
                    var save_img_path_db = Path.Combine(save_folder, image_name);
                    using (var stream = new FileStream(Path.Combine(_env.WebRootPath, save_img_path_db), FileMode.Create))
                    {
                        await input.Image.CopyToAsync(stream);
                    }
                    var save_file_db = Path.Combine(save_folder, input.File.FileName);
                    using (var stream = new FileStream(Path.Combine(_env.WebRootPath, save_file_db), FileMode.Create))
                    {
                        await input.File.CopyToAsync(stream);
                    }

                    await _db.Downloads.AddAsync(new Download
                    {
                        DownloadType = input.DownloadType,
                        File_Path = save_folder.Replace("\\","/"),
                        Name_EN = input.Name_EN,
                        Name_TH = input.Name_TH,
                    });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    System.IO.Directory.Delete(Path.Combine(_env.WebRootPath, save_folder, folder), true);
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }
            return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }
        public async Task<IActionResult> Download([FromQuery] string path_and_name)
        {
            try
            {
                var path = path_and_name.Replace("/", "\\");
                var path_file = _env.WebRootPath+ path;
                if (System.IO.File.Exists(path_file))
                {
                    byte[] bytes = await System.IO.File.ReadAllBytesAsync(path_file);
                    return File(bytes, "text/plain", Path.GetFileName(path_and_name));
                }
                return Content("File not found");
            }
            catch (Exception ex)
            {
                return Content("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
            var download = await _db.Downloads.FirstOrDefaultAsync(download => download.Id == id);
            if (download != null)
            {
                try
                {
                    var path = Path.GetDirectoryName(Path.Combine(_env.WebRootPath, download.File_Path));
                    if (System.IO.Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                    }
                    _db.Downloads.Remove(download);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "ลบเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = "ลบข้อมูลผิดพลาด" });
                }
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }
        private  string? GetFileName(string path)
        {
            try
            {
                var path_folder = Path.Combine(_env.WebRootPath, path);
                if (Directory.Exists(path_folder))
                {
                    return Directory.GetFiles(path_folder)
                                         .Where(file => !file.EndsWith("0.jpg"))
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
