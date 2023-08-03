using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class PresentationInforController : Controller
    {
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public PresentationInforController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }

        public IActionResult SH_IR_Presentation_Doc()
        {
            var checkrow = db.SH_IR_presentation_doc.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_presentation_doc = count_row, fod_SH_IR_presentation_doc = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_Presentation_Doc_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_presentation_doc_Data.OrderByDescending(x=>x.id).ToList();
                var add_count = new List<IR_Presentation_Infor_model.SH_IR_Presentation_DocDataDetails_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    var dateDatas = Convert.ToDateTime(items.document_date);
                    var InsertDates = dateDatas.ToString("MM/yyyy", new CultureInfo("en-US"));
                    if (items.document_date != null)
                    {
                        InsertDates = InsertDates;
                    }
                    else
                    {
                        InsertDates = "";
                    }

                    add_count.Add(new IR_Presentation_Infor_model.SH_IR_Presentation_DocDataDetails_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        active_status=items.active_status,
                        document_date = InsertDates, 
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
        public IActionResult SH_IR_Presentation_DocData_create()
        {
            return View();
        }
        public IActionResult SH_IR_Presentation_DocData_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_Presentation_Doc", "PresentationInfor");
            }
            var get_detail = db.SH_IR_presentation_doc_Data.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_Presentation_Doc", "PresentationInfor");
            }
            var model = new model_input { SH_IR_presentation_doc_Data = get_detail };
            return View(model); 
        }
        public IActionResult SH_IR_Presentation_Doc_addData(SH_IR_presentation_doc fod_SH_IR_presentation_doc)
        {
            try
            {
                var checkrow = db.SH_IR_presentation_doc.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_SH_IR_presentation_doc.created_at = DateTime.Now;
                    fod_SH_IR_presentation_doc.updated_at = DateTime.Now;
                    db.SH_IR_presentation_doc.Add(fod_SH_IR_presentation_doc);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = fod_SH_IR_presentation_doc.titleTH;
                    checkrow.titleENG = fod_SH_IR_presentation_doc.titleENG;
                    checkrow.detailsTitleTH = fod_SH_IR_presentation_doc.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_SH_IR_presentation_doc.detailsTitleENG;
                    checkrow.present_documentTitleTH = fod_SH_IR_presentation_doc.present_documentTitleTH;
                    checkrow.present_documentTitleENG = fod_SH_IR_presentation_doc.present_documentTitleENG;
                    checkrow.downloadTitleTH = fod_SH_IR_presentation_doc.downloadTitleTH;
                    checkrow.downloadTitleENG = fod_SH_IR_presentation_doc.downloadTitleENG; 
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
        public IActionResult SH_IR_Presentation_DocData_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_presentation_doc_Data.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_Presentation_DocData_submit(SH_IR_presentation_doc_Data SH_IR_presentation_doc_Data,
          string? Date_Str, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            { 
                //if (Date_Str == null)
                //{
                //    return Json(new { status = "error", message = "กรุณาระบุ  วันที่!" });
                //}
                //DateTime InsertDate = DateTime.ParseExact(Date_Str, "MM/yyyy", new CultureInfo("en-US"));

                //if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                //{
                //    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                //}

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        extension = extension.Replace(" ", "");

                        SH_IR_presentation_doc_Data.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Presentation/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFileENG in uploaded_file_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        extension = extension.Replace(" ", "");

                        SH_IR_presentation_doc_Data.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Presentation/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (SH_IR_presentation_doc_Data.active_status != 1)
                {
                    SH_IR_presentation_doc_Data.active_status = 0;
                }
                else
                {
                    SH_IR_presentation_doc_Data.active_status = 1;
                }

                DateTime InsertDate = DateTime.Now;
                if (Date_Str != null)
                {
                    InsertDate = DateTime.ParseExact(Date_Str, "MM/yyyy", new CultureInfo("en-US"));
                    SH_IR_presentation_doc_Data.document_date = InsertDate;
                } 

                SH_IR_presentation_doc_Data.created_at = DateTime.Now;
                SH_IR_presentation_doc_Data.updated_at = DateTime.Now;
                db.SH_IR_presentation_doc_Data.Add(SH_IR_presentation_doc_Data);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_Presentation_DocData_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_presentation_doc_Data.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {

                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Presentation/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Presentation/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }
                    db.SH_IR_presentation_doc_Data.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Get_Edit_SH_IR_Presentation_DocData(int? id)
        {
            var InfoDataedit = db.SH_IR_presentation_doc_Data.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_Presentation_DocData_edit_Submit(SH_IR_presentation_doc_Data SH_IR_presentation_doc_Data,  
           string? Date_Str, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                //if (SH_IR_presentation_doc_Data.titleTH == null || SH_IR_presentation_doc_Data.titleENG == "")
                //{
                //    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG" });
                //} 

                //if (Date_Str == null)
                //{
                //    return Json(new { status = "error", message = "กรุณาระบุ  วันที่!" });
                //}
                //DateTime InsertDate = DateTime.ParseExact(Date_Str, "MM/yyyy", new CultureInfo("en-US"));

                var old_data = db.SH_IR_presentation_doc_Data.Where(x => x.id == SH_IR_presentation_doc_Data.id).FirstOrDefault();

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Presentation/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);

                            old_data.file_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Presentation/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_file_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Presentation/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);

                            old_data.file_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Presentation/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_IR_presentation_doc_Data.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.titleTH = SH_IR_presentation_doc_Data.titleTH;
                old_data.titleENG = SH_IR_presentation_doc_Data.titleENG;

                DateTime InsertDate = DateTime.Now;
                if (Date_Str != null)
                {
                    InsertDate = DateTime.ParseExact(Date_Str, "MM/yyyy", new CultureInfo("en-US"));
                    old_data.document_date = InsertDate;
                }

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        ///

        public IActionResult SH_IR_Presentation_webcast()
        {
            var checkrow = db.SH_IR_presentation_webcast.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_presentation_webcast = count_row, fod_SH_IR_presentation_webcast= checkrow };
            return View(model);
        } 
        public IActionResult SH_IR_Presentation_webcast_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_presentation_webcast_Data.OrderByDescending(x=>x.id).ToList();
                var add_count = new List<IR_Presentation_Infor_model.SH_IR_presentation_webcastDetails_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    var dateDatas = Convert.ToDateTime(items.activity_date);
                    var InsertDates = dateDatas.ToString("MM/yyyy", new CultureInfo("en-US"));
                    if (items.activity_date != null)
                    {
                        InsertDates = InsertDates;
                    }
                    else
                    {
                        InsertDates = "";
                    }

                    add_count.Add(new IR_Presentation_Infor_model.SH_IR_presentation_webcastDetails_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        active_status = items.active_status, 
                        activity_date = InsertDates,
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
        public IActionResult SH_IR_Presentation_webcastData_create()
        {
            return View();
        }
        public IActionResult SH_IR_Presentation_webcastData_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_Presentation_webcast", "PresentationInfor");
            }
            var get_detail = db.SH_IR_presentation_webcast_Data.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_Presentation_webcast", "PresentationInfor");
            }
            var model = new model_input { SH_IR_presentation_webcast_Data = get_detail };
            return View(model);
        }
        public IActionResult SH_IR_Presentation_webcast_addData(SH_IR_presentation_webcast fod_SH_IR_presentation_webcast)
        {
            try
            {
                var checkrow = db.SH_IR_presentation_webcast.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_SH_IR_presentation_webcast.created_at = DateTime.Now;
                    fod_SH_IR_presentation_webcast.updated_at = DateTime.Now;
                    db.SH_IR_presentation_webcast.Add(fod_SH_IR_presentation_webcast);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = fod_SH_IR_presentation_webcast.titleTH;
                    checkrow.titleENG = fod_SH_IR_presentation_webcast.titleENG;
                    checkrow.detailsTitleTH = fod_SH_IR_presentation_webcast.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_SH_IR_presentation_webcast.detailsTitleENG;
                    checkrow.activitytitleTH = fod_SH_IR_presentation_webcast.activitytitleTH;
                    checkrow.activitytitleENG = fod_SH_IR_presentation_webcast.activitytitleENG;
                    checkrow.webcastTitleTH = fod_SH_IR_presentation_webcast.webcastTitleTH;
                    checkrow.webcastTitleENG = fod_SH_IR_presentation_webcast.webcastTitleENG;
                    checkrow.downloadtitleTH = fod_SH_IR_presentation_webcast.downloadtitleTH;
                    checkrow.downloadtitleENG = fod_SH_IR_presentation_webcast.downloadtitleENG;
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
        public IActionResult SH_IR_Presentation_webcastData_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_presentation_webcast_Data.Where(x => x.id == id).FirstOrDefault();
            if (status == "true")
            {
                get_data.active_status = 1;
            }
            else
            {
                get_data.active_status = 0;
            }
            db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult SH_IR_Presentation_webcastData_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_presentation_webcast_Data.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {

                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_PresentationWebcast/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_PresentationWebcast/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }
                    db.SH_IR_presentation_webcast_Data.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        } 
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_Presentation_webcastData_submit(SH_IR_presentation_webcast_Data SH_IR_presentation_webcast_Data,
          string? Date_Str, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                //if (Date_Str == null)
                //{
                //    return Json(new { status = "error", message = "กรุณาระบุ  วันที่!" });
                //}
                //DateTime InsertDate = DateTime.ParseExact(Date_Str, "MM/yyyy", new CultureInfo("en-US"));

                //if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                //{
                //    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                //}
                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        extension = extension.Replace(" ", "");

                        SH_IR_presentation_webcast_Data.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_PresentationWebcast/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFileENG in uploaded_file_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        extension = extension.Replace(" ", "");

                        SH_IR_presentation_webcast_Data.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_PresentationWebcast/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (SH_IR_presentation_webcast_Data.active_status != 1)
                {
                    SH_IR_presentation_webcast_Data.active_status = 0;
                }
                else
                {
                    SH_IR_presentation_webcast_Data.active_status = 1;
                }
                DateTime InsertDate=DateTime.Now;
                if (Date_Str != null)
                {
                     InsertDate = DateTime.ParseExact(Date_Str, "MM/yyyy", new CultureInfo("en-US")); 
                    SH_IR_presentation_webcast_Data.activity_date = InsertDate;
                }

                SH_IR_presentation_webcast_Data.created_at = DateTime.Now;
                SH_IR_presentation_webcast_Data.updated_at = DateTime.Now;
                db.SH_IR_presentation_webcast_Data.Add(SH_IR_presentation_webcast_Data);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Get_Edit_SH_IR_Presentation_webcastData(int? id)
        {
            var InfoDataedit = db.SH_IR_presentation_webcast_Data.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_Presentation_webcastData_edit_Submit(SH_IR_presentation_webcast_Data SH_IR_presentation_webcast_Data,
          string? Date_Str, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (SH_IR_presentation_webcast_Data.titleTH == null || SH_IR_presentation_webcast_Data.titleENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG" });
                }


                //if (Date_Str == null)
                //{
                //    return Json(new { status = "error", message = "กรุณาระบุ  วันที่!" });
                //}
                //DateTime InsertDate = DateTime.ParseExact(Date_Str, "MM/yyyy", new CultureInfo("en-US"));

                var old_data = db.SH_IR_presentation_webcast_Data.Where(x => x.id == SH_IR_presentation_webcast_Data.id).FirstOrDefault();

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_PresentationWebcast/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);

                            old_data.file_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_PresentationWebcast/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_file_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_PresentationWebcast/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);

                            old_data.file_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_PresentationWebcast/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_IR_presentation_webcast_Data.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.titleTH = SH_IR_presentation_webcast_Data.titleTH;
                old_data.titleENG = SH_IR_presentation_webcast_Data.titleENG;
                old_data.linkVideo = SH_IR_presentation_webcast_Data.linkVideo;

                DateTime InsertDate=DateTime.Now;
                if (Date_Str != null)
                {
                    InsertDate = DateTime.ParseExact(Date_Str, "MM/yyyy", new CultureInfo("en-US"));

                    old_data.activity_date = InsertDate;
                }

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }




    }
}
