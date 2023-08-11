using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Lighting.Models.InputFilterModels.Download;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Text;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class ManageDownloadController : Controller
    {
        //readonly private LightingContext db;
        //readonly private IWebHostEnvironment _env;
        //public ManageDownloadController(LightingContext db, IWebHostEnvironment env)
        //{
        //    db = db;
        //    _env = env;

        //}

        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public ManageDownloadController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }
        public IActionResult Download_Type_edit(int? id)
        {
            var download = db.DownloadTypes.FirstOrDefault(download => download.id == id);
            if (download != null)
            {
                var output = new model_input { DownloadTypes = download };

                return View(output);
            }
            return RedirectToAction("Manage_Download_Page");
        } 
        public async Task<IActionResult> DownloadType_Submit(DownloadTypes downloadTypes)
        {
            var download = await db.DownloadTypes.FirstOrDefaultAsync(download => download.id == downloadTypes.id);
            if (download != null)
            {
                try
                { 

                    download.DownloadType_name_TH = downloadTypes.DownloadType_name_TH;
                    download.DownloadType_name_ENG = downloadTypes.DownloadType_name_ENG; 
                    await db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = "เกิดข้อผิดพลาด" });
                }

            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }


        public IActionResult Manage_Download_Page()
        {
            var checkrow = db.DownloadHeads.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_DownloadHeads = count_row, fod_DownloadHeads = checkrow };
            return View(model);
        }
        public IActionResult DownloadHead_Data(DownloadHeads downloadHeads)
        {
            try
            {
                var checkrow = db.DownloadHeads.FirstOrDefault();
                if (checkrow == null)
                {
                    downloadHeads.created_at = DateTime.Now;
                    downloadHeads.updated_at = DateTime.Now;
                    db.DownloadHeads.Add(downloadHeads);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.title_TH = downloadHeads.title_TH;
                    checkrow.Title_ENG = downloadHeads.Title_ENG;
                    checkrow.updated_at = DateTime.Now;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Get_DownloadType()
        {
            var DB = db.DownloadTypes.ToList();
            return Json(new { db = DB });
        }
        public IActionResult Download_Type_getTable()
        {
            try
            {
                var Raw_list = db.DownloadTypes.ToList();
                var add_count = new List<DownloadModel.DownloadType_table>();
                var count = 1;
                foreach (var items in Raw_list)
                { 
                    add_count.Add(new DownloadModel.DownloadType_table
                    {
                        count_row = count,
                        id = items.id, 
                        downloadType_name_TH = items.DownloadType_name_TH,
                        downloadType_name_ENG = items.DownloadType_name_ENG, 
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }

        } 
        public IActionResult Manage_Download_Page_getTable()
        {
            try
            {
                var Raw_list = db.Downloads.ToList();
                var add_count = new List<DownloadModel.DownloadData_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    var getType = db.DownloadTypes.FirstOrDefault(x => x.id == items.DownloadType_id);
                    var DownloadType = getType.DownloadType_name_ENG;

                    add_count.Add(new DownloadModel.DownloadData_table
                    {
                        count_row = count,
                        id = items.id,
                        DownloadType = DownloadType,
                        Name_TH = items.Name_TH,
                        Name_EN = items.Name_EN,
                        use_status = items.use_status,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                    });
                    count++;
                }
                return Json(new { data = add_count });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }

        }
        public IActionResult Download_changesStatus(int? id, string? status)
        {
            var get_data = db.Downloads.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.use_status = 1;
            }
            else
            {
                get_data.use_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit_Page([FromQuery] int id)
        {
            var download = await db.Downloads.AsNoTracking().FirstOrDefaultAsync(download => download.id == id);
            if (download != null)
            {
                var output = new model_input { Output_DownloadVM = download };

                return View(output);
            }
            return RedirectToAction("Manage_Download_Page");
        }
        public async Task<IActionResult> Edit([FromForm] Input_DownloadVM input, [FromQuery] int id, Download updateData)
        {
            var download = await db.Downloads.FirstOrDefaultAsync(download => download.id == id);
            if (download != null)
            {
                try
                {
                    var old_data = db.Downloads.Where(x => x.id == id).FirstOrDefault();

                    if (input.Image != null)
                    {
                        var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + old_data.upload_image);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }

                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(input.Image.FileName);

                        download.upload_image = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            input.Image.CopyTo(stream);
                        }
                    }
                    if (input.Image_EN != null)
                    {
                        var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + old_data.upload_image_ENG);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }

                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(input.Image_EN.FileName);

                        download.upload_image_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            input.Image_EN.CopyTo(stream);
                        }
                    }

                    if (input.File != null)
                    {
                        var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + old_data.file_name);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }

                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(input.File.FileName);

                        download.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            input.File.CopyTo(stream);
                        }
                    }
                    if (input.File_EN != null)
                    {
                        var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + old_data.file_name_ENG);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }

                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(input.File_EN.FileName);

                        download.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            input.File_EN.CopyTo(stream);
                        }
                    }

                    download.Name_EN = input.Name_EN;
                    download.Name_TH = input.Name_TH;
                    download.DownloadType_id = input.DownloadType_id;
                    download.L_AND_BIM_Link = input.L_AND_BIM_Link;
                    download.use_status = input.use_status;

                    await db.SaveChangesAsync();
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
        public IActionResult Add_Download([FromForm] Input_DownloadVM input, Download inputData)
        {
            try
            {
                if (input.Image != null)
                {
                    var datestr = DateTime.Now.Ticks.ToString();
                    var extension = Path.GetExtension(input.Image.FileName);
                    extension = extension.Replace(" ", "");

                    inputData.upload_image = datestr + extension;
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + datestr + extension);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        input.Image.CopyTo(stream);
                    }
                }

                if (input.Image_EN != null)
                {
                    var datestr = DateTime.Now.Ticks.ToString();
                    var extension = Path.GetExtension(input.Image_EN.FileName);
                    extension = extension.Replace(" ", "");

                    inputData.upload_image_ENG = datestr + extension;
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + datestr + extension);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        input.Image_EN.CopyTo(stream);
                    }
                }

                if (input.File != null)
                {
                    var datestr = DateTime.Now.Ticks.ToString();
                    var extension = Path.GetExtension(input.File.FileName);
                    extension = extension.Replace(" ", "");

                    inputData.file_name = datestr + extension;
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + datestr + extension);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        input.File.CopyTo(stream);
                    }
                }

                if (input.File_EN != null)
                {
                    var datestr = DateTime.Now.Ticks.ToString();
                    var extension = Path.GetExtension(input.File_EN.FileName);
                    extension = extension.Replace(" ", "");

                    inputData.file_name_ENG = datestr + extension;
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + datestr + extension);

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        input.File_EN.CopyTo(stream);
                    }
                }

                DateTime Date = DateTime.Now;

                inputData.DownloadType_id = input.DownloadType_id;
                inputData.Name_EN = input.Name_EN;
                inputData.Name_TH = input.Name_TH;
                inputData.L_AND_BIM_Link = input.L_AND_BIM_Link;
                inputData.use_status = input.use_status;
                inputData.updated_at = Date;
                inputData.created_at = Date;

                db.Downloads.Add(inputData);
                db.SaveChanges();

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception ex)
            {
                //System.IO.Directory.Delete(Path.Combine(_env.WebRootPath, save_folder, folder), true);
                return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
            }
            //}
            //return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {
            var download = await db.Downloads.FirstOrDefaultAsync(download => download.id == id);
            if (download != null)
            {
                try
                {
                    var old_imageTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + download.upload_image);
                    if (System.IO.File.Exists(old_imageTH) == true)
                    {
                        System.IO.File.Delete(old_imageTH);
                    }
                    var old_imageENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + download.upload_image_ENG);
                    if (System.IO.File.Exists(old_imageENG) == true)
                    {
                        System.IO.File.Delete(old_imageENG);
                    }

                    var old_fileTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + download.file_name);
                    if (System.IO.File.Exists(old_fileTH) == true)
                    {
                        System.IO.File.Delete(old_fileTH);
                    }

                    var old_fileENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Download/" + download.file_name_ENG);
                    if (System.IO.File.Exists(old_fileENG) == true)
                    {
                        System.IO.File.Delete(old_fileENG);
                    }

                    db.Downloads.Remove(download);
                    await db.SaveChangesAsync();
                    return Json(new { status = "success", message = "ลบเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = "ลบข้อมูลผิดพลาด" });
                }
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }

    }

}
