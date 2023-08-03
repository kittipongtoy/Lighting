using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]

    public class Information_ShareHolderController : Controller
    {
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public Information_ShareHolderController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }

        //sub menu ผู้ถือหุ้นรายใหญ่
        public IActionResult Major_ShareHolder()
        {
            var checkrow = db.ShareHolder.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_ShareHolder = count_row, fod_ShareHolder = checkrow };
            return View(model);

        }
        public IActionResult Major_ShareHolder_getTable()
        {
            try
            {
                var Raw_list = db.ShareHolder_DataDetails.ToList();
                var add_count = new List<IR_sharHolderTable_model.ShareHolder_DataDetails_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_sharHolderTable_model.ShareHolder_DataDetails_table
                    {
                        count_row = count,
                        Id = items.Id,
                        nameTH = items.nameTH,
                        nameENG = items.nameENG,
                        amount = items.amount,
                        percentPerAmount = items.percentPerAmount,
                        CreateDate = items.created_at,
                        UpdateDate = items.updated_at,
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
        public IActionResult ShareHolder_DataDetails_create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ShareHolder_addData(ShareHolder fod_ShareHolder)
        {
            try
            {
                var checkrow = db.ShareHolder.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_ShareHolder.created_at = DateTime.Now;
                    fod_ShareHolder.updated_at = DateTime.Now;
                    db.ShareHolder.Add(fod_ShareHolder);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.TitleTH = fod_ShareHolder.TitleTH;
                    checkrow.TitleENG = fod_ShareHolder.TitleENG;
                    checkrow.detailsTitleTH = fod_ShareHolder.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_ShareHolder.detailsTitleENG;
                    checkrow.detailsTH = fod_ShareHolder.detailsTH;
                    checkrow.detailsENG = fod_ShareHolder.detailsENG;
                    checkrow.nameTitleTH = fod_ShareHolder.nameTitleTH;
                    checkrow.nameTitleENG = fod_ShareHolder.nameTitleENG;
                    checkrow.amountTitleTH = fod_ShareHolder.amountTitleTH;
                    checkrow.amountTitleENG = fod_ShareHolder.amountTitleENG;
                    checkrow.percentTitleTH = fod_ShareHolder.percentTitleTH;
                    checkrow.percentTitleENG = fod_ShareHolder.percentTitleENG;
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
        public IActionResult ShareHolder_DataDetails_insert(ShareHolder_DataDetails shareHolder_Details)
        {
            try
            {
                shareHolder_Details.created_at = DateTime.Now;
                shareHolder_Details.updated_at = DateTime.Now;

                db.ShareHolder_DataDetails.Add(shareHolder_Details);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult ShareHolder_DataDetails_edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Major_ShareHolder", "Information_Share");
            }
            var get_detail = db.ShareHolder_DataDetails.Where(x => x.Id == Id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Major_ShareHolder", "Information_Share");
            }
            var model = new model_input { ShareHolder_Details = get_detail };
            return View(model);
        }
        public IActionResult ShareHolder_DataDetails_edit_Submit(ShareHolder_DataDetails shareHolder_Details)
        {
            try
            {
                var get_data = db.ShareHolder_DataDetails.Where(x => x.Id == shareHolder_Details.Id).FirstOrDefault();

                get_data.updated_at = DateTime.Now;
                get_data.nameTH = shareHolder_Details.nameTH;
                get_data.nameENG = shareHolder_Details.nameENG;
                get_data.amount = shareHolder_Details.amount;
                get_data.percentPerAmount = shareHolder_Details.percentPerAmount;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult ShareHolder_DataDetails_delete(int? Id)
        {
            try
            {
                var deleteData = db.ShareHolder_DataDetails.Where(x => x.Id == Id).FirstOrDefault();

                if (deleteData != null)
                {
                    db.ShareHolder_DataDetails.Remove(deleteData);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //import info shareholder
        public IActionResult Import_Info_ShareHolder()
        {
            var checkrow = db.Import_Info_ShareHolder.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_Import_InfoShareHolder = count_row, fod_Import_InfoShareHolder = checkrow };
            return View(model);
        }
        public IActionResult Import_Info_ShareHolder_addData(Import_Info_ShareHolder import_InfoShareHolder)
        {
            try
            {
                var checkrow = db.Import_Info_ShareHolder.FirstOrDefault();
                if (checkrow == null)
                {
                    import_InfoShareHolder.created_at = DateTime.Now;
                    import_InfoShareHolder.updated_at = DateTime.Now;
                    db.Import_Info_ShareHolder.Add(import_InfoShareHolder);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = import_InfoShareHolder.titleTH;
                    checkrow.titleENG = import_InfoShareHolder.titleENG;
                    checkrow.detailsTitleTH = import_InfoShareHolder.detailsTitleTH;
                    checkrow.detailsTitleENG = import_InfoShareHolder.detailsTitleENG;
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

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult ImportInfo_ShareHolder_addData_Submit(ImportInfo_ShareHolderData ImportInfo_ShareHolder, List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป TH" });
                }
                if (uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป ENG" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        extension = extension.Replace(" ", "");
                        ImportInfo_ShareHolder.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/ImportInfo_Shareholder/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile_ENG in uploaded_image_ENG)
                {
                    if (formFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        ImportInfo_ShareHolder.image_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/ImportInfo_Shareholder/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (ImportInfo_ShareHolder.use_status == 1)
                {
                    var updata = from up2 in db.ImportInfo_ShareHolderData
                                 where up2.use_status == 1
                                 select up2;

                    foreach (ImportInfo_ShareHolderData up2 in updata)
                    {
                        up2.use_status = 0;
                    }
                    db.SaveChanges();

                }

                if (ImportInfo_ShareHolder.use_status != 1)
                {
                    ImportInfo_ShareHolder.use_status = 0;
                }
                else
                {
                    ImportInfo_ShareHolder.use_status = 1;
                }
                ImportInfo_ShareHolder.created_at = DateTime.Now;
                ImportInfo_ShareHolder.updated_at = DateTime.Now;
                db.ImportInfo_ShareHolderData.Add(ImportInfo_ShareHolder);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult ImportInfo_ShareHolderData_getTable()
        {
            try
            {
                var Data_list = db.ImportInfo_ShareHolderData.ToList();
                var add_count = new List<IR_sharHolderTable_model.ImportInfo_ShareHolderData_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new IR_sharHolderTable_model.ImportInfo_ShareHolderData_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status
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
        public IActionResult ImportInfo_ShareHolderData_getEditData(int? id)
        {
            var get_data = db.ImportInfo_ShareHolderData.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }
        public IActionResult ImportInfo_ShareHolderData_changeStatus(int? id, string? status)
        {
            var get_data = db.ImportInfo_ShareHolderData.Where(x => x.id == id).FirstOrDefault();

            if (get_data != null)
            {
                if (get_data.use_status != 1)
                {
                    var Change = db.ImportInfo_ShareHolderData.ToList();
                    foreach (var item in Change)
                    {
                        item.use_status = 0;
                        db.Entry(item).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    if (get_data.use_status == 1)
                    {
                        if (status == "true")
                        {
                            get_data.use_status = 1;
                        }
                        else
                        {
                            get_data.use_status = 0;
                        }
                        db.Entry(get_data).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        if (status == "true")
                        {
                            get_data.use_status = 1;
                        }
                        else
                        {
                            get_data.use_status = 0;
                        }
                        db.Entry(get_data).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }


            //if (status == "true")
            //{
            //    get_data.use_status = 1;
            //}
            //else
            //{
            //    get_data.use_status = 0;
            //}
            //db.SaveChanges();

            return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult ImportInfo_ShareHolderData_edit_Submit(ImportInfo_ShareHolderData ImportInfo_ShareHolderData, List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG)
        {
            try
            {
                var get_oldData = db.ImportInfo_ShareHolderData.Where(x => x.id == ImportInfo_ShareHolderData.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/ImportInfo_Shareholder/" + get_oldData.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            get_oldData.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/ImportInfo_Shareholder/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in uploaded_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/ImportInfo_Shareholder/" + get_oldData.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            get_oldData.image_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/ImportInfo_Shareholder/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (ImportInfo_ShareHolderData.use_status == 1)
                {
                    var updata = from up2 in db.ImportInfo_ShareHolderData
                                 where up2.use_status == 1
                                 select up2;

                    foreach (ImportInfo_ShareHolderData up2 in updata)
                    {
                        up2.use_status = 0;
                    }
                    db.SaveChanges();

                }

                if (ImportInfo_ShareHolderData.use_status != 1)
                {
                    get_oldData.use_status = 0;
                }
                else
                {
                    get_oldData.use_status = 1;
                }
                get_oldData.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult ImportInfo_ShareHolderData_delete(int? id)
        {
            try
            {
                var checkrow = db.ImportInfo_ShareHolderData.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/ImportInfo_Shareholder/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    db.ImportInfo_ShareHolderData.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //general Meeting
        public IActionResult SH_GeneralMeeting()
        {
            var checkrow = db.SH_generalMeeting.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_generalMeeting = count_row, fod_generalMeeting = checkrow };
            return View(model);

        }
        public IActionResult SH_GeneralMeeting_addData(SH_generalMeeting fod_generalMeeting,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG)
        {
            try
            {
                var checkrow = db.SH_generalMeeting.FirstOrDefault();
                if (checkrow == null)
                {

                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            extension = extension.Replace(" ", "");
                            fod_generalMeeting.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_GeneralMeeting/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }

                    foreach (var formFile_ENG in uploaded_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            fod_generalMeeting.image_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_GeneralMeeting/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }

                    fod_generalMeeting.created_at = DateTime.Now;
                    fod_generalMeeting.updated_at = DateTime.Now;
                    db.SH_generalMeeting.Add(fod_generalMeeting);
                    db.SaveChanges();
                }
                else
                {
                    var get_oldData = db.SH_generalMeeting.FirstOrDefault();

                    if (uploaded_image.Count > 0)
                    {
                        foreach (var formFile in uploaded_image)
                        {
                            if (formFile.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_GeneralMeeting/" + get_oldData.image_name);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.Ticks.ToString();
                                var extension = Path.GetExtension(formFile.FileName);
                                checkrow.image_name = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_GeneralMeeting/" + datestr + extension);

                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile.CopyTo(stream);
                                }
                            }
                        }
                    }

                    if (uploaded_image_ENG.Count > 0)
                    {
                        foreach (var formFile_ENG in uploaded_image_ENG)
                        {
                            if (formFile_ENG.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_GeneralMeeting/" + get_oldData.image_name_ENG);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                                var extension = Path.GetExtension(formFile_ENG.FileName);
                                extension = extension.Replace(" ", "");

                                checkrow.image_name_ENG = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_GeneralMeeting/" + datestr + extension);

                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile_ENG.CopyTo(stream);
                                }
                            }
                        }
                    }

                    checkrow.titleTH = fod_generalMeeting.titleTH;
                    checkrow.titleENG = fod_generalMeeting.titleENG;
                    checkrow.detailsTitleTH = fod_generalMeeting.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_generalMeeting.detailsTitleENG;
                    checkrow.link = fod_generalMeeting.link;
                    checkrow.meetingTitleTH = fod_generalMeeting.meetingTitleTH;
                    checkrow.meetingTitleENG = fod_generalMeeting.meetingTitleENG;
                    checkrow.downloadTitleTH = fod_generalMeeting.downloadTitleTH;
                    checkrow.downloadTitleENG = fod_generalMeeting.downloadTitleENG;
                    checkrow.updated_at = DateTime.Now;
                    db.Entry(checkrow).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_GeneralMeetingData_getTable()
        {
            try
            {
                var Raw_list = db.SH_generalMeeting_Data.ToList();
                var add_count = new List<IR_sharHolderTable_model.SH_GeneralMeetingData_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_sharHolderTable_model.SH_GeneralMeetingData_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        file_name = items.file_name,
                        file_name_ENG = items.file_name_ENG,
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
        public IActionResult SH_GeneralMeetingData_create()
        {
            return View();
        }
        public IActionResult SH_GeneralMeetingData_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_GeneralMeeting", "Information_Share");
            }
            var get_detail = db.SH_generalMeeting_Data.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_GeneralMeeting", "Information_Share");
            }
            var model = new model_input { SH_generalMeeting_Data = get_detail };
            return View(model);
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_GeneralMeetingData_addData(SH_generalMeeting_Data SH_generalMeetingData, string? Year_Str,
            List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                //if (Year_Str == null)
                //{
                //    return Json(new { status = "warning", message = "กรุณาระบุ ปี!" });
                //}
                //DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                //if (SH_generalMeetingData.titleTH == null || SH_generalMeetingData.titleENG == "")
                //{
                //    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ" });
                //}

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        extension = extension.Replace(" ", "");

                        SH_generalMeetingData.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_GeneralMeeting/" + datestr + extension);

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

                        SH_generalMeetingData.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_GeneralMeeting/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (SH_generalMeetingData.use_status != 1)
                {
                    SH_generalMeetingData.use_status = 0;
                }
                else
                {
                    SH_generalMeetingData.use_status = 1;
                }

                DateTime InsertDate_year = DateTime.Now;
                if (Year_Str != null)
                {
                    InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));
                    SH_generalMeetingData.year = InsertDate_year;
                }

                SH_generalMeetingData.created_at = DateTime.Now;
                db.SH_generalMeeting_Data.Add(SH_generalMeetingData);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_GeneralMeetingData_editData_Submit(SH_generalMeeting_Data SH_generalMeetingData, string? Year_Str,
            List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                //if (SH_generalMeetingData.titleTH == null || SH_generalMeetingData.titleENG == "")
                //{
                //    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                //}

                //if (Year_Str == null)
                //{
                //    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                //}
                //DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var old_data = db.SH_generalMeeting_Data.Where(x => x.id == SH_generalMeetingData.id).FirstOrDefault();

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_GeneralMeeting/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);

                            old_data.file_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_GeneralMeeting/" + datestr + extension);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_GeneralMeeting/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);

                            old_data.file_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_GeneralMeeting/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_generalMeetingData.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }

                DateTime InsertDate_year = DateTime.Now;
                if (Year_Str != null)
                {
                    InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));
                    old_data.year = InsertDate_year;
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
        public IActionResult SH_GeneralMeetingData_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_generalMeeting_Data.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_GeneralMeeting/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_GeneralMeeting/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.SH_generalMeeting_Data.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Get_Edit_SH_generalMeeting_Data(int? id)
        {
            var InfoDataedit = db.SH_generalMeeting_Data.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }
        public IActionResult SH_GeneralMeetingData_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_generalMeeting_Data.Where(x => x.id == id).FirstOrDefault();
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


        // Dividend
        public IActionResult SH_IR_dividend()
        {
            var checkrow = db.SH_dividen.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_dividen = count_row, fod_SH_dividen = checkrow };
            return View(model);

        }
        public IActionResult SH_IR_dividenData_create()
        {
            return View();
        }
        public IActionResult SH_IR_dividenData_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_dividend", "Information_Share");
            }
            var get_detail = db.SH_dividen_Data.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_dividend", "Information_Share");
            }
            var model = new model_input { SH_dividen_Data = get_detail };
            return View(model);
        }
        public IActionResult SH_IR_dividenData_getTable()
        {
            try
            {
                var Raw_list = db.SH_dividen_Data.ToList();
                var add_count = new List<IR_sharHolderTable_model.SH_dividenData_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    DateTime datemaking = (DateTime)items.dateMaking;
                    var date_Making = datemaking.Day + "/" + datemaking.Month + "/" + datemaking.Year;

                    DateTime dateOfBoard = (DateTime)items.dateOfBoard;
                    var date_OfBoard = dateOfBoard.Day + "/" + dateOfBoard.Month + "/" + dateOfBoard.Year;

                    DateTime paymentDate = (DateTime)items.paymentDate;
                    var payment_Date = paymentDate.Day + "/" + paymentDate.Month + "/" + paymentDate.Year;

                    add_count.Add(new IR_sharHolderTable_model.SH_dividenData_table
                    {
                        count_row = count,
                        id = items.id,
                        title = items.title,
                        dateOfBoard = date_Making,
                        dateMaking = date_OfBoard,
                        paymentDate = payment_Date,
                        dividenTypeTitleTH = items.dividenTypeTitleTH,
                        dividenTypeTitleENG = items.dividenTypeTitleENG,
                        earningDayTitleTH = items.earningDayTitleTH,
                        earningDayTitleENG = items.earningDayTitleENG,
                        amount = items.amount,
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
        public IActionResult SH_dividen_addData(SH_dividen fod_SH_dividen)
        {
            try
            {
                var checkrow = db.SH_dividen.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_SH_dividen.created_at = DateTime.Now;
                    db.SH_dividen.Add(fod_SH_dividen);
                    db.SaveChanges();
                }
                else
                {
                    var get_oldData = db.SH_dividen.FirstOrDefault();

                    checkrow.titleTH = fod_SH_dividen.titleTH;
                    checkrow.titleENG = fod_SH_dividen.titleENG;
                    checkrow.detailsTitleTH = fod_SH_dividen.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_SH_dividen.detailsTitleENG;
                    checkrow.detailsTH = fod_SH_dividen.detailsTH;
                    checkrow.detailsENG = fod_SH_dividen.detailsENG;
                    checkrow.securityTitleTH = fod_SH_dividen.securityTitleTH;
                    checkrow.securityTitleENG = fod_SH_dividen.securityTitleENG;
                    checkrow.dateOfBoardTitleTH = fod_SH_dividen.dateOfBoardTitleTH;
                    checkrow.dateOfBoardTitleENG = fod_SH_dividen.dateOfBoardTitleENG;
                    checkrow.dateMakingTitleTH = fod_SH_dividen.dateMakingTitleTH;
                    checkrow.dateMakingTitleENG = fod_SH_dividen.dateMakingTitleENG;
                    checkrow.paymentDateTitleTH = fod_SH_dividen.paymentDateTitleTH;
                    checkrow.paymentDateTitleENG = fod_SH_dividen.paymentDateTitleENG;
                    checkrow.dividenTypetitleTH = fod_SH_dividen.dividenTypetitleTH;
                    checkrow.dividenTypetitleENG = fod_SH_dividen.dividenTypetitleENG;
                    checkrow.amountTitleTH = fod_SH_dividen.amountTitleTH;
                    checkrow.amountTitleENG = fod_SH_dividen.amountTitleENG;
                    checkrow.earningDayTitleTH = fod_SH_dividen.earningDayTitleTH;
                    checkrow.earningDayTitleENG = fod_SH_dividen.earningDayTitleENG;
                    checkrow.updated_at = DateTime.Now;
                    db.Entry(checkrow).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_dividen_addData_submit(SH_dividen_Data SH_dividen_Data, string? dateOfBoard_Str, string? dateMaking_Str, string? paymentDate_Str)
        {
            try
            {
                if (dateOfBoard_Str == null || dateMaking_Str == "" || paymentDate_Str == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ วันที่ทั้งหมด!" });
                }
                DateTime InsertDate_dateOfBoard = DateTime.ParseExact(dateOfBoard_Str, "dd/MM/yyyy", new CultureInfo("en-US"));
                DateTime InsertDate_dateMaking = DateTime.ParseExact(dateMaking_Str, "dd/MM/yyyy", new CultureInfo("en-US"));
                DateTime InsertDate_paymentDate = DateTime.ParseExact(paymentDate_Str, "dd/MM/yyyy", new CultureInfo("en-US"));

                if (SH_dividen_Data.use_status != 1)
                {
                    SH_dividen_Data.use_status = 0;
                }
                else
                {
                    SH_dividen_Data.use_status = 1;
                }

                SH_dividen_Data.dateOfBoard = InsertDate_dateOfBoard;
                SH_dividen_Data.dateMaking = InsertDate_dateMaking;
                SH_dividen_Data.paymentDate = InsertDate_paymentDate;
                SH_dividen_Data.created_at = DateTime.Now;
                db.SH_dividen_Data.Add(SH_dividen_Data);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_dividenData_edit_Submit(SH_dividen_Data SH_dividen_Data, string? dateOfBoard_Str, string? dateMaking_Str, string? paymentDate_Str)
        {
            try
            {

                if (dateOfBoard_Str == null || dateMaking_Str == "" || paymentDate_Str == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ วันที่ทั้งหมด!" });
                }
                DateTime InsertDate_dateOfBoard = DateTime.ParseExact(dateOfBoard_Str, "dd/MM/yyyy", new CultureInfo("en-US"));
                DateTime InsertDate_dateMaking = DateTime.ParseExact(dateMaking_Str, "dd/MM/yyyy", new CultureInfo("en-US"));
                DateTime InsertDate_paymentDate = DateTime.ParseExact(paymentDate_Str, "dd/MM/yyyy", new CultureInfo("en-US"));

                var old_data = db.SH_dividen_Data.Where(x => x.id == SH_dividen_Data.id).FirstOrDefault();

                old_data.dateOfBoard = InsertDate_dateOfBoard;
                old_data.dateMaking = InsertDate_dateMaking;
                old_data.paymentDate = InsertDate_paymentDate;
                old_data.amount = SH_dividen_Data.amount;
                old_data.title = SH_dividen_Data.title;
                old_data.dividenTypeTitleTH = SH_dividen_Data.dividenTypeTitleTH;
                old_data.dividenTypeTitleENG = SH_dividen_Data.dividenTypeTitleENG;
                old_data.earningDayTitleTH = SH_dividen_Data.earningDayTitleTH;
                old_data.earningDayTitleENG = SH_dividen_Data.earningDayTitleENG;

                if (SH_dividen_Data.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
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
        public IActionResult Get_Edit_SH_dividen_addData(int? id)
        {
            var InfoDataedit = db.SH_dividen_Data.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }
        public IActionResult SH_dividen_Data_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_dividen_Data.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {

                    db.SH_dividen_Data.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        /// annual report
        public IActionResult SH_IR_annualReport()
        {
            var checkrow = db.SH_annual_Report.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_annual_Report = count_row, fod_SH_annual_Report = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_annualReportData()
        {
            return View();
        }
        public IActionResult SH_IR_annualReportData_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_annualReport", "Information_Share");
            }
            var get_detail = db.SH_annual_ReportData.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_annualReport", "Information_Share");
            }
            var model = new model_input { SH_annual_ReportData = get_detail };
            return View(model);
        }
        public IActionResult SH_IR_annualReport_addData(SH_annual_Report fod_SH_Annual_Report)
        {
            try
            {
                var checkrow = db.SH_annual_Report.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_SH_Annual_Report.created_at = DateTime.Now;
                    fod_SH_Annual_Report.updated_at = DateTime.Now;
                    db.SH_annual_Report.Add(fod_SH_Annual_Report);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = fod_SH_Annual_Report.titleTH;
                    checkrow.titleENG = fod_SH_Annual_Report.titleENG;
                    checkrow.detailsTitleTH = fod_SH_Annual_Report.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_SH_Annual_Report.detailsTitleENG;
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
        public IActionResult SH_IR_annualReportData_getTable()
        {
            try
            {
                var Raw_list = db.SH_annual_ReportData.ToList();
                var add_count = new List<IR_sharHolderTable_model.SH_annualReportData_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    DateTime dateYear = (DateTime)items.year;
                    string getyear = dateYear.Year.ToString();

                    add_count.Add(new IR_sharHolderTable_model.SH_annualReportData_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        use_status = items.use_status,
                        year = getyear,
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

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_annualReportData_submit(SH_annual_ReportData SH_annual_ReportData, string? Year_Str,
            List<IFormFile> upload_image, List<IFormFile> upload_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "warning", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                if (upload_image.Count == 0 || upload_image_ENG.Count == 0 || uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var imgFile in upload_image)
                {
                    if (imgFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(imgFile.FileName);
                        extension = extension.Replace(" ", "");
                        SH_annual_ReportData.upload_image = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_annualReport/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var imgFile_ENG in upload_image_ENG)
                {
                    if (imgFile_ENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(imgFile_ENG.FileName);
                        extension = extension.Replace(" ", "");

                        SH_annual_ReportData.upload_image_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_annualReport/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        extension = extension.Replace(" ", "");

                        SH_annual_ReportData.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_annualReport/" + datestr + extension);

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

                        SH_annual_ReportData.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_annualReport/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (SH_annual_ReportData.use_status != 1)
                {
                    SH_annual_ReportData.use_status = 0;
                }
                else
                {
                    SH_annual_ReportData.use_status = 1;
                }

                SH_annual_ReportData.year = InsertDate_year;
                SH_annual_ReportData.created_at = DateTime.Now;
                SH_annual_ReportData.updated_at = DateTime.Now;
                db.SH_annual_ReportData.Add(SH_annual_ReportData);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Get_Edit_SH_IR_annualReportData(int? id)
        {
            var InfoDataedit = db.SH_annual_ReportData.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_annualReportData_edit_Submit(SH_annual_ReportData SH_annual_ReportData, string? Year_Str,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (SH_annual_ReportData.titleTH == null || SH_annual_ReportData.titleENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG" });
                }

                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var old_data = db.SH_annual_ReportData.Where(x => x.id == SH_annual_ReportData.id).FirstOrDefault();

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_annualReport/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);

                            old_data.file_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_annualReport/" + datestr + extension);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_annualReport/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);

                            old_data.file_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_annualReport/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_annualReport/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_annualReport/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (upload_image_ENG.Count > 0)
                {
                    foreach (var formFile_ENG in upload_image_ENG)
                    {
                        if (formFile_ENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_annualReport/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_annualReport/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_annual_ReportData.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.titleTH = SH_annual_ReportData.titleTH;
                old_data.titleENG = SH_annual_ReportData.titleENG;

                old_data.year = InsertDate_year;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_annualReportData_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_annual_ReportData.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_annualReportData_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_annual_ReportData.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var img_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_annualReport/" + checkrow.upload_image);
                    if (System.IO.File.Exists(img_filePathTH) == true)
                    {
                        System.IO.File.Delete(img_filePathTH);
                    }

                    var img_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_annualReport/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(img_filePathENG) == true)
                    {
                        System.IO.File.Delete(img_filePathENG);
                    }

                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_annualReport/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_annualReport/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }
                    db.SH_annual_ReportData.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        /// IR Form
        public IActionResult SH_IR_Form()
        {
            var checkrow = db.SH_IR_Form.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_Form = count_row, fod_SH_IR_Form = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_FormData()
        {
            return View();
        }
        public IActionResult SH_IR_FormData_edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("SH_IR_Form", "Information_Share");
            }
            var get_detail = db.SH_IR_FormData.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_Form", "Information_Share");
            }
            var model = new model_input { SH_IR_FormData = get_detail };
            return View(model);
        }
        public IActionResult SH_IR_FormData_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_FormData.ToList();
                var add_count = new List<IR_sharHolderTable_model.SH_IR_FormData_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    DateTime dateYear = (DateTime)items.year;
                    string getyear = dateYear.Year.ToString();

                    add_count.Add(new IR_sharHolderTable_model.SH_IR_FormData_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        active_status = items.active_status,
                        year = getyear,
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
        public IActionResult SH_IR_Form_addData(SH_IR_Form fod_SH_IR_Form)
        {
            try
            {
                var checkrow = db.SH_IR_Form.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_SH_IR_Form.created_at = DateTime.Now;
                    fod_SH_IR_Form.updated_at = DateTime.Now;
                    db.SH_IR_Form.Add(fod_SH_IR_Form);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = fod_SH_IR_Form.titleTH;
                    checkrow.titleENG = fod_SH_IR_Form.titleENG;
                    checkrow.detailsTitleTH = fod_SH_IR_Form.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_SH_IR_Form.detailsTitleENG;
                    checkrow.nameTitleTH = fod_SH_IR_Form.nameTitleTH;
                    checkrow.nameTitleENG = fod_SH_IR_Form.nameTitleENG;
                    checkrow.yearTitleTH = fod_SH_IR_Form.yearTitleTH;
                    checkrow.yearTitleENG = fod_SH_IR_Form.yearTitleENG;
                    checkrow.dateConfrimTitleTH = fod_SH_IR_Form.dateConfrimTitleTH;
                    checkrow.dateConfrimTitleENG = fod_SH_IR_Form.dateConfrimTitleENG;
                    checkrow.detailsTH = fod_SH_IR_Form.detailsTH;
                    checkrow.detailsENG = fod_SH_IR_Form.detailsENG;
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

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_FormData_submit(SH_IR_FormData SH_IR_FormData, string? Year_Str,
            string? conFrimDate_Str, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                if (conFrimDate_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_conFrimDate = DateTime.ParseExact(conFrimDate_Str, "dd/MM/yyyy", new CultureInfo("en-US"));

                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        extension = extension.Replace(" ", "");

                        SH_IR_FormData.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Form/" + datestr + extension);

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

                        SH_IR_FormData.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Form/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (SH_IR_FormData.active_status != 1)
                {
                    SH_IR_FormData.active_status = 0;
                }
                else
                {
                    SH_IR_FormData.active_status = 1;
                }

                SH_IR_FormData.confrimDate = InsertDate_conFrimDate;
                SH_IR_FormData.year = InsertDate_year;
                SH_IR_FormData.created_at = DateTime.Now;
                SH_IR_FormData.updated_at = DateTime.Now;
                db.SH_IR_FormData.Add(SH_IR_FormData);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_FormData_edit_Submit(SH_IR_FormData SH_IR_FormData, string? Year_Str,
            string? conFrimDate_Str, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (SH_IR_FormData.titleTH == null || SH_IR_FormData.titleENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG" });
                }

                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                if (conFrimDate_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_conFrimDate = DateTime.ParseExact(conFrimDate_Str, "dd/MM/yyyy", new CultureInfo("en-US"));

                var old_data = db.SH_IR_FormData.Where(x => x.id == SH_IR_FormData.id).FirstOrDefault();

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Form/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);

                            old_data.file_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Form/" + datestr + extension);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Form/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);

                            old_data.file_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Form/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_IR_FormData.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.titleTH = SH_IR_FormData.titleTH;
                old_data.titleENG = SH_IR_FormData.titleENG;

                old_data.year = InsertDate_year;
                old_data.confrimDate = InsertDate_conFrimDate;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Get_Edit_SH_IR_FormData(int? id)
        {
            var InfoDataedit = db.SH_IR_FormData.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }
        public IActionResult _SH_IR_FormData_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_FormData.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_FormData_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_FormData.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {

                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Form/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_Form/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }
                    db.SH_IR_FormData.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }



        //repoer general meeting
        public IActionResult SH_IR_Report_Meeting()
        {
            var checkrow = db.SH_IR_Report_Meeting.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_Report_Meeting = count_row, fod_SH_IR_Report_Meeting = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_Report_MeetingDataDetails_view(int? id)
        {
            var checkrow = db.SH_IR_Report_MeetingData.FirstOrDefault(x => x.id == id);
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_Report_MeetingData = count_row, SH_IR_Report_MeetingData = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_Report_Meeting_addData(SH_IR_Report_Meeting sH_IR_Report_Meeting)
        {
            try
            {
                var checkrow = db.SH_IR_Report_Meeting.FirstOrDefault();
                if (checkrow == null)
                {
                    sH_IR_Report_Meeting.created_at = DateTime.Now;
                    sH_IR_Report_Meeting.updated_at = DateTime.Now;
                    db.SH_IR_Report_Meeting.Add(sH_IR_Report_Meeting);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = sH_IR_Report_Meeting.titleTH;
                    checkrow.titleENG = sH_IR_Report_Meeting.titleENG;
                    checkrow.detailsTitleTH = sH_IR_Report_Meeting.detailsTitleTH;
                    checkrow.detailsTitleENG = sH_IR_Report_Meeting.detailsTitleENG;
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
        public IActionResult SH_IR_Report_MeetingData_getTable()
        {
            try
            {
                var Data_list = db.SH_IR_Report_MeetingData.OrderByDescending(x => x.year).ToList();
                var add_count = new List<IR_sharHolderTable_model.SH_IR_Report_MeetingData_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    DateTime dateYear = (DateTime)items.year;
                    string getyear = dateYear.Year.ToString();

                    add_count.Add(new IR_sharHolderTable_model.SH_IR_Report_MeetingData_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        year = getyear,
                        updated_at = items.updated_at,
                        created_at = items.created_at,
                        active_status = items.active_status
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
        public IActionResult SH_IR_Report_MeetingData_Submit(SH_IR_Report_MeetingData Report_MeetingData, string? Year_Str)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                if (Report_MeetingData.active_status != 1)
                {
                    Report_MeetingData.active_status = 0;
                }
                else
                {
                    Report_MeetingData.active_status = 1;
                }
                Report_MeetingData.created_at = DateTime.Now;
                Report_MeetingData.updated_at = DateTime.Now;
                Report_MeetingData.year = InsertDate_year;

                db.SH_IR_Report_MeetingData.Add(Report_MeetingData);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_Report_MeetingData_edit_Submit(SH_IR_Report_MeetingData Report_MeetingData, string? Year_Str)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var get_oldData = db.SH_IR_Report_MeetingData.Where(x => x.id == Report_MeetingData.id).FirstOrDefault();

                if (Report_MeetingData.active_status != 1)
                {
                    get_oldData.active_status = 0;
                }
                else
                {
                    get_oldData.active_status = 1;
                }
                get_oldData.titleTH = Report_MeetingData.titleTH;
                get_oldData.titleENG = Report_MeetingData.titleENG;
                get_oldData.year = InsertDate_year;

                get_oldData.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_Report_MeetingData_getEditData(int? id)
        {
            var get_data = db.SH_IR_Report_MeetingData.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }
        public IActionResult SH_IR_Report_MeetingData_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_Report_MeetingData.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_Report_MeetingData_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_Report_MeetingData.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var details = db.SH_IR_Report_Meeting_DataDetails.Where(x => x.id == checkrow.id).ToList();
                    foreach (var items in details)
                    {
                        var deleteData = db.SH_IR_Report_Meeting_DataDetails.FirstOrDefault(x => x.id == items.id);
                        if (deleteData != null)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + deleteData.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + deleteData.file_name_ENG);
                            if (System.IO.File.Exists(old_filePathENG) == true)
                            {
                                System.IO.File.Delete(old_filePathENG);
                            }

                            db.SH_IR_Report_Meeting_DataDetails.Remove(deleteData);
                            db.SaveChanges();
                        }
                    }

                    db.SH_IR_Report_MeetingData.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_Report_MeetingDataDetails_getTable(int? id)
        {
            try
            {
                var Raw_list = db.SH_IR_Report_Meeting_DataDetails.Where(x => x.reportMeeting_id == id).ToList();
                var add_count = new List<IR_sharHolderTable_model.SH_IR_ReportMeetingDataDetails_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    DateTime dateYear = (DateTime)items.year;
                    string getyear = dateYear.Year.ToString();

                    add_count.Add(new IR_sharHolderTable_model.SH_IR_ReportMeetingDataDetails_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        active_status = items.active_status,
                        year = getyear,
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
        public IActionResult SH_IR_Report_MeetingDataDetails_create(int? id)
        {
            var check = db.SH_IR_Report_MeetingData.FirstOrDefault(x => x.id == id);
            if (check == null)
            {
                return RedirectToAction("SH_IR_Report_Meeting", "Information_ShareHolder");
            }
            var model = new model_input { SH_IR_Report_MeetingData = check };
            return View(model);
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_Report_MeetingDataDetails_submit(SH_IR_Report_Meeting_DataDetails SH_IR_Report_Meeting_DataDetails, string? Year_Str,
           List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

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

                        SH_IR_Report_Meeting_DataDetails.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + datestr + extension);

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

                        SH_IR_Report_Meeting_DataDetails.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (SH_IR_Report_Meeting_DataDetails.active_status != 1)
                {
                    SH_IR_Report_Meeting_DataDetails.active_status = 0;
                }
                else
                {
                    SH_IR_Report_Meeting_DataDetails.active_status = 1;
                }

                SH_IR_Report_Meeting_DataDetails.reportMeeting_id = SH_IR_Report_Meeting_DataDetails.reportMeeting_id;
                SH_IR_Report_Meeting_DataDetails.titleTH = SH_IR_Report_Meeting_DataDetails.titleTH;
                SH_IR_Report_Meeting_DataDetails.titleENG = SH_IR_Report_Meeting_DataDetails.titleENG;
                SH_IR_Report_Meeting_DataDetails.year = InsertDate_year;
                SH_IR_Report_Meeting_DataDetails.created_at = DateTime.Now;
                SH_IR_Report_Meeting_DataDetails.updated_at = DateTime.Now;
                db.SH_IR_Report_Meeting_DataDetails.Add(SH_IR_Report_Meeting_DataDetails);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_Report_MeetingDataDetails_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_Report_Meeting_DataDetails.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_Report_MeetingDataDetails_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_Report_Meeting_DataDetails.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }
                    db.SH_IR_Report_Meeting_DataDetails.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_Report_MeetingDataDetails_edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("SH_IR_Report_Meeting", "Information_ShareHolder");
            }
            var get_detail = db.SH_IR_Report_Meeting_DataDetails.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_Report_Meeting", "Information_ShareHolder");
            }
            var model = new model_input { SH_IR_Report_Meeting_DataDetails = get_detail };
            return View(model);
        }
        public IActionResult Get_Edit_SH_IR_Report_MeetingDataDetails(int? id)
        {
            var InfoDataedit = db.SH_IR_Report_Meeting_DataDetails.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_Report_MeetingDataDetails_edit_Submit(SH_IR_Report_Meeting_DataDetails SH_IR_Report_Meeting_DataDetails, string? Year_Str,
             List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (SH_IR_Report_Meeting_DataDetails.titleTH == null || SH_IR_Report_Meeting_DataDetails.titleENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG" });
                }

                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var old_data = db.SH_IR_Report_Meeting_DataDetails.Where(x => x.id == SH_IR_Report_Meeting_DataDetails.id).FirstOrDefault();

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);

                            old_data.file_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + datestr + extension);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);

                            old_data.file_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_ReportMeeting/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_IR_Report_Meeting_DataDetails.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.titleTH = SH_IR_Report_Meeting_DataDetails.titleTH;
                old_data.titleENG = SH_IR_Report_Meeting_DataDetails.titleENG;

                old_data.year = InsertDate_year;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }


        ////ir_propose_agenda

        public IActionResult SH_IR_propose_agenda()
        {
            var checkrow = db.SH_IR_propose_agenda.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }

            var getMailContact = db.receive_agenda_mail_accounts.FirstOrDefault();
            var ggg = 0;
            if (getMailContact != null)
            {
                ggg = 1;
            }
            var model = new model_input { count_row_SH_IR_propose_agenda = count_row, fod_SH_IR_propose_agenda = checkrow, count_receive_agenda_mail_accounts = ggg, receive_agenda_mail_accounts = getMailContact };
            return View(model);
        }
        public IActionResult receive_agenda_mail_accounts_submit(receive_agenda_mail_accounts mailContact)
        {
            try
            {
                var checkrow = db.receive_agenda_mail_accounts.FirstOrDefault();
                if (checkrow == null)
                {
                    mailContact.created_at = DateTime.Now;
                    mailContact.updated_at = DateTime.Now;
                    db.receive_agenda_mail_accounts.Add(mailContact);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.account = mailContact.account; ;
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

        public IActionResult SH_IR_propose_agenda_DataDetails()
        {
            return View();
        }
        public IActionResult SH_IR_propose_agenda_DataDetails_edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("SH_IR_propose_agenda", "Information_Share");
            }
            var get_detail = db.SH_IR_propose_agenda_DataDetails.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_propose_agenda", "Information_Share");
            }
            var model = new model_input { SH_IR_propose_agenda_DataDetails = get_detail };
            return View(model);
        }
        public IActionResult SH_IR_propose_agenda_DataDetails_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_propose_agenda_DataDetails.ToList();
                var add_count = new List<IR_sharHolderTable_model.SH_IR_propose_agendaData_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_sharHolderTable_model.SH_IR_propose_agendaData_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        active_status = items.active_status,
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
        public IActionResult SH_IR_propose_agenda_DataDetails_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_propose_agenda_DataDetails.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_propose_agenda/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_propose_agenda/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }
                    db.SH_IR_propose_agenda_DataDetails.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_propose_agenda_DataDetails_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_propose_agenda_DataDetails.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_propose_agenda_addData(SH_IR_propose_agenda fod_SH_IR_propose_agenda)
        {
            try
            {
                var checkrow = db.SH_IR_propose_agenda.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_SH_IR_propose_agenda.created_at = DateTime.Now;
                    fod_SH_IR_propose_agenda.updated_at = DateTime.Now;
                    db.SH_IR_propose_agenda.Add(fod_SH_IR_propose_agenda);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = fod_SH_IR_propose_agenda.titleTH;
                    checkrow.titleENG = fod_SH_IR_propose_agenda.titleENG;
                    checkrow.detailsTitleTH = fod_SH_IR_propose_agenda.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_SH_IR_propose_agenda.detailsTitleENG;
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

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_propose_agenda_DataDetails_submit(SH_IR_propose_agenda_DataDetails SH_IR_propose_agenda_DataDetails, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        extension = extension.Replace(" ", "");

                        SH_IR_propose_agenda_DataDetails.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_propose_agenda/" + datestr + extension);

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

                        SH_IR_propose_agenda_DataDetails.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_propose_agenda/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (SH_IR_propose_agenda_DataDetails.active_status != 1)
                {
                    SH_IR_propose_agenda_DataDetails.active_status = 0;
                }
                else
                {
                    SH_IR_propose_agenda_DataDetails.active_status = 1;
                }

                SH_IR_propose_agenda_DataDetails.created_at = DateTime.Now;
                SH_IR_propose_agenda_DataDetails.updated_at = DateTime.Now;
                db.SH_IR_propose_agenda_DataDetails.Add(SH_IR_propose_agenda_DataDetails);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_propose_agenda_DataDetails_edit_Submit(SH_IR_propose_agenda_DataDetails SH_IR_propose_agenda_DataDetails, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                var old_data = db.SH_IR_propose_agenda_DataDetails.Where(x => x.id == SH_IR_propose_agenda_DataDetails.id).FirstOrDefault();

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_propose_agenda/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);

                            old_data.file_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_propose_agenda/" + datestr + extension);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_propose_agenda/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);

                            old_data.file_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_propose_agenda/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_IR_propose_agenda_DataDetails.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.titleTH = SH_IR_propose_agenda_DataDetails.titleTH;
                old_data.titleENG = SH_IR_propose_agenda_DataDetails.titleENG;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_propose_agenda_mailTitles_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_propose_agenda_mailTitles.ToList();
                var add_count = new List<IR_sharHolderTable_model.SH_IR_propose_agenda_mailTitles_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_sharHolderTable_model.SH_IR_propose_agenda_mailTitles_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        active_status = items.active_status,
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
        public IActionResult SH_IR_propose_agenda_mailTitles_changeStatus(int? id, string? status)
        {
            var i = 0;
            try
            {
                var DB = db.SH_IR_propose_agenda_mailTitles.FirstOrDefault(x => x.id == id);
                if (DB != null)
                {
                    if (DB.active_status != 1)
                    {
                        var Change = db.SH_IR_propose_agenda_mailTitles.ToList();
                        foreach (var item in Change)
                        {
                            item.active_status = 0;
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        if (DB.active_status == 1)
                        {
                            DB.active_status = 0;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                            i = 1;
                        }
                        else
                        {
                            DB.active_status = 1;
                            db.Entry(DB).State = EntityState.Modified;
                            db.SaveChanges();
                            i = 1;
                        }
                    }
                    else
                    {
                        i = 2;
                    }
                }
                return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
            }
            catch (Exception ex)
            {
                return Json(new { Error = ex.Message, alert = i });
            }

            //var get_data = db.SH_IR_propose_agenda_mailTitles.Where(x => x.id == id).FirstOrDefault();

            //if (status == "true")
            //{
            //    get_data.active_status = 1;
            //}
            //else
            //{
            //    get_data.active_status = 0;
            //}
            //db.SaveChanges();

            //return Json(new { status = "success", message = "เปลี่ยนสถานะเรียบร้อย" });
        }
        public IActionResult SH_IR_propose_agenda_mailTitles_creat()
        {
            return View();
        }
        public IActionResult SH_IR_propose_agenda_mailTitles_create_submit(SH_IR_propose_agenda_mailTitles mailTitles)
        {
            try
            {
                if (mailTitles.active_status == 1)
                {
                    var check_other = from up2 in db.SH_IR_propose_agenda_mailTitles
                                      where up2.active_status == 1
                                      select up2;
                    foreach (SH_IR_propose_agenda_mailTitles up2 in check_other)
                    {
                        up2.active_status = 0;
                    }
                    db.SaveChanges();
                }

                if (mailTitles.active_status != 1)
                {
                    mailTitles.active_status = 0;
                }
                else
                {
                    mailTitles.active_status = 1;
                }

                mailTitles.created_at = DateTime.Now;
                mailTitles.updated_at = DateTime.Now;
                db.SH_IR_propose_agenda_mailTitles.Add(mailTitles);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_propose_agenda_mailTitles_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_propose_agenda", "Information_Share");
            }
            var get_detail = db.SH_IR_propose_agenda_mailTitles.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_propose_agenda", "Information_Share");
            }
            var model = new model_input { SH_IR_propose_agenda_mailTitles = get_detail };
            return View(model);
        }
        public IActionResult SH_IR_propose_agenda_mailTitles_Submit(SH_IR_propose_agenda_mailTitles mailTitles_edit)
        {
            try
            {
                if (mailTitles_edit.active_status == 1)
                {
                    var check_other = from up2 in db.SH_IR_propose_agenda_mailTitles
                                      where up2.id != mailTitles_edit.id && up2.active_status == 1
                                      select up2;
                    foreach (SH_IR_propose_agenda_mailTitles up2 in check_other)
                    {
                        up2.active_status = 0;
                    }
                    db.SaveChanges();
                }

                var old_data = db.SH_IR_propose_agenda_mailTitles.Where(x => x.id == mailTitles_edit.id).FirstOrDefault();

                if (mailTitles_edit.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.titleTH = mailTitles_edit.titleTH;
                old_data.titleENG = mailTitles_edit.titleENG;
                old_data.nameTitleTH = mailTitles_edit.nameTitleTH;
                old_data.nameTitleENG = mailTitles_edit.nameTitleENG;
                old_data.nameTitlePlaceholderTH = mailTitles_edit.nameTitlePlaceholderTH;
                old_data.nameTitlePlaceholderENG = mailTitles_edit.nameTitlePlaceholderENG;
                old_data.emailTitleTH = mailTitles_edit.emailTitleTH;
                old_data.emailTitleENG = mailTitles_edit.emailTitleENG;
                old_data.emailTitlePlaceholderTH = mailTitles_edit.emailTitlePlaceholderTH;
                old_data.emailTitlePlaceholderENG = mailTitles_edit.emailTitlePlaceholderENG;
                old_data.phoneTH = mailTitles_edit.phoneTH;
                old_data.phoneENG = mailTitles_edit.phoneENG;
                old_data.phoneTitlePlaceholder = mailTitles_edit.phoneTitlePlaceholder;
                old_data.proposeTitleTH = mailTitles_edit.proposeTitleTH;
                old_data.proposeTitleENG = mailTitles_edit.proposeTitleENG;
                old_data.wantProposeTitleTH = mailTitles_edit.wantProposeTitleTH;
                old_data.wantProposeTitleENG = mailTitles_edit.wantProposeTitleENG;
                old_data.wantProposePlaceholderTitleTH = mailTitles_edit.wantProposePlaceholderTitleTH;
                old_data.wantProposePlaceholderTitleENG = mailTitles_edit.wantProposePlaceholderTitleENG;
                old_data.detailsTitleTH = mailTitles_edit.detailsTitleTH;
                old_data.detailsTitleENG = mailTitles_edit.detailsTitleENG;
                old_data.detailsPlaceholderTitleTH = mailTitles_edit.detailsPlaceholderTitleTH;
                old_data.detailsPlaceholderTitleENG = mailTitles_edit.detailsPlaceholderTitleENG;
                old_data.detailsTH = mailTitles_edit.detailsTH;
                old_data.detailsENG = mailTitles_edit.detailsENG;
                old_data.remarkTH = mailTitles_edit.remarkTH;
                old_data.remarkENG = mailTitles_edit.remarkENG;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_propose_agenda_mailTitles_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_propose_agenda_mailTitles.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    db.SH_IR_propose_agenda_mailTitles.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        public IActionResult type_of_agenda_Propose_getTable()
        {
            try
            {
                var Raw_list = db.type_of_agenda_Propose.ToList();
                var add_count = new List<IR_sharHolderTable_model.type_of_agenda_Propose_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_sharHolderTable_model.type_of_agenda_Propose_table
                    {
                        count_row = count,
                        id = items.id,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG,
                        active_status = items.active_status,
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
        public IActionResult type_of_agenda_Propose_create()
        {
            return View();
        }
        public IActionResult type_of_agenda_Propose_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_propose_agenda", "Information_Share");
            }
            var get_detail = db.type_of_agenda_Propose.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_propose_agenda", "Information_Share");
            }
            var model = new model_input { type_of_agenda_Propose = get_detail };
            return View(model);
        }
        public IActionResult type_of_agenda_Propose_submit(type_of_agenda_Propose type_of_agenda)
        {
            try
            {

                if (type_of_agenda.active_status != 1)
                {
                    type_of_agenda.active_status = 0;
                }
                else
                {
                    type_of_agenda.active_status = 1;
                }

                type_of_agenda.created_at = DateTime.Now;
                type_of_agenda.updated_at = DateTime.Now;
                db.type_of_agenda_Propose.Add(type_of_agenda);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult type_of_agenda_Propose_edit_Submit(type_of_agenda_Propose type_of_agenda)
        {
            try
            {
                var old_data = db.type_of_agenda_Propose.Where(x => x.id == type_of_agenda.id).FirstOrDefault();

                if (type_of_agenda.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.titleTH = type_of_agenda.titleTH;
                old_data.titleENG = type_of_agenda.titleENG;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult type_of_agenda_Propose_delete(int? id)
        {
            try
            {
                var checkrow = db.type_of_agenda_Propose.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    db.type_of_agenda_Propose.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult type_of_agenda_Propose_changeStatus(int? id, string? status)
        {
            var get_data = db.type_of_agenda_Propose.Where(x => x.id == id).FirstOrDefault();
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

        //mail receive
        public IActionResult receive_mail_agenda_propose_getTable()
        {
            try
            {
                var Raw_list = db.receive_mail_propose_agendas.ToList();
                var add_count = new List<IR_sharHolderTable_model.receive_mail_propose_agendas_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_sharHolderTable_model.receive_mail_propose_agendas_table
                    {
                        count_row = count,
                        id = items.id,
                        name = items.name,
                        phone = items.phone,
                        email = items.email,
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
        public IActionResult receive_mail_propose_agendas_delete(int? id)
        {
            try
            {
                var checkrow = db.receive_mail_propose_agendas.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    db.receive_mail_propose_agendas.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

    }
}
