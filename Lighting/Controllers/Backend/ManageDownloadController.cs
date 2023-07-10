using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Download;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Lighting.Controllers.Backend
{
    public class ManageDownloadController : Controller
    {
        readonly private LightingContext _db;
        readonly private IWebHostEnvironment _env;
        readonly string _root_path;
        public ManageDownloadController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
            _root_path = _env.WebRootPath;

        }
        public IActionResult Index()
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
                    File = download.File,
                    Image = download.Image,
                    Name_EN = download.Name_EN,
                    Name_TH = download.Name_TH,

                }).ToListAsync();

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
                    File = download.File,
                    Image = download.Image,
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
                try {
                    //delete old folder
                    var path = Path.GetDirectoryName(Path.Combine(_root_path, download.File));
                    if (System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.Delete(path, true);
                    }


                    var folder = Guid.NewGuid().ToString();
                    var image_name = "0.jpg";
                    var save_folder = Path.Combine("upload_file", "Download", folder);
                    Directory.CreateDirectory(Path.Combine(_root_path, save_folder, folder));
                    var save_img_path_db = Path.Combine(save_folder, image_name);

                    using (var stream = new FileStream(Path.Combine(_root_path, save_img_path_db), FileMode.Create))
                    {
                        await input.Image.CopyToAsync(stream);
                    }

                    var save_file_db = Path.Combine(save_folder, input.File.FileName);
                    using (var stream = new FileStream(Path.Combine(_root_path, save_file_db), FileMode.Create))
                    {
                        await input.File.CopyToAsync(stream);
                    }

                    download.Name_EN = input.Name_EN;
                    download.Name_TH = input.Name_TH;
                    download.Image = save_img_path_db;
                    download.File = save_file_db;
                    download.DownloadType = input.DownloadType;

                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }catch (Exception ex)
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
                Directory.CreateDirectory(Path.Combine(_root_path, save_folder, folder));
                try
                {
                    var save_img_path_db = Path.Combine(save_folder, image_name);
                    using (var stream = new FileStream(Path.Combine(_root_path, save_img_path_db), FileMode.Create))
                    {
                        await input.Image.CopyToAsync(stream);
                    }
                    var save_file_db = Path.Combine(save_folder, input.File.FileName);
                    using (var stream = new FileStream(Path.Combine(_root_path, save_file_db), FileMode.Create))
                    {
                        await input.File.CopyToAsync(stream);
                    }

                    await _db.Downloads.AddAsync(new Download
                    {
                        DownloadType = input.DownloadType,
                        Image = save_img_path_db,
                        File = save_file_db,
                        Name_EN = input.Name_EN,
                        Name_TH = input.Name_TH,
                    });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    System.IO.Directory.Delete(Path.Combine(_root_path, save_folder, folder), true);
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }
            return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }
        public async Task<IActionResult> Download([FromQuery] string path_and_name)
        {
            var path = Path.Combine(_root_path, path_and_name);
            if (System.IO.File.Exists(path))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(await System.IO.File.ReadAllTextAsync(path));
                return File(bytes, "text/plain", Path.GetFileName(path_and_name));
            }
            return Content("File not found");
        }

        [HttpPost]
        public async Task< IActionResult> DeleteById(int id)
        {
            var download = await _db.Downloads.FirstOrDefaultAsync(download => download.Id == id);
            if (download != null)
            {
                try
                {
                    var path = Path.GetDirectoryName( Path.Combine(_root_path,download.File));
                    if (System.IO.Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                    }
                    _db.Downloads.Remove(download);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "ลบเรียบร้อย" });
                }catch (Exception ex)
                {
                    return Json(new { status = "error", message = "ลบข้อมูลผิดพลาด" });
                }
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }
    }
}
