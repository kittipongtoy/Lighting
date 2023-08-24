﻿using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class importantFinancialInformationController : Controller
    {
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public importantFinancialInformationController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }

        public IActionResult SH_IR_MDA()
        {
            var checkrow = db.SH_IR_MDA.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_MDA = count_row, fod_SH_IR_MDA = checkrow };
            return View(model);
            //return View();
        }
        public IActionResult SH_IR_MDA_addData(SH_IR_MDA fod_SH_IR_MDA)
        {
            try
            {
                var checkrow = db.SH_IR_MDA.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_SH_IR_MDA.created_at = DateTime.Now;
                    fod_SH_IR_MDA.updated_at = DateTime.Now;
                    db.SH_IR_MDA.Add(fod_SH_IR_MDA);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = fod_SH_IR_MDA.titleTH;
                    checkrow.titleENG = fod_SH_IR_MDA.titleENG;
                    checkrow.detailsTitleTH = fod_SH_IR_MDA.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_SH_IR_MDA.detailsTitleENG;
                    checkrow.dataTitleTH = fod_SH_IR_MDA.dataTitleTH;
                    checkrow.dataTitleENG = fod_SH_IR_MDA.dataTitleENG;
                    checkrow.nameTitleTH = fod_SH_IR_MDA.nameTitleTH;
                    checkrow.nameTitleENG = fod_SH_IR_MDA.nameTitleENG;
                    checkrow.downloadTitleTH = fod_SH_IR_MDA.downloadTitleTH;
                    checkrow.downloadTitleENG = fod_SH_IR_MDA.downloadTitleENG;
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
        public IActionResult SH_IR_MDA_Data_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_MDA_Data.ToList();
                var add_count = new List<IR_Important_Financial_model.SH_IR_MDA_Data_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_Important_Financial_model.SH_IR_MDA_Data_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG
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
        public IActionResult SH_IR_MDA_DataDetails_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_MDA_DataDetails.OrderByDescending(x => x.year).ToList();
                var add_count = new List<IR_Important_Financial_model.SH_IR_MDA_DataDetails_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    var dateDatas = Convert.ToDateTime(items.year);
                    var InsertDates = dateDatas.ToString("yyyy", new CultureInfo("en-US"));

                    add_count.Add(new IR_Important_Financial_model.SH_IR_MDA_DataDetails_table
                    {
                        count_row = count,
                        id = items.id,
                        title = items.title,
                        year = InsertDates,
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
        public IActionResult SH_IR_MDA_Data_create()
        {
            return View();
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_MDA_Data_submit(SH_IR_MDA_Data sH_IR_MDA_Data,
            List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {

                if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
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
                        sH_IR_MDA_Data.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_importantFinancial/" + datestr + extension);

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

                        sH_IR_MDA_Data.image_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_importantFinancial/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (sH_IR_MDA_Data.active_status != 1)
                {
                    sH_IR_MDA_Data.active_status = 0;
                }
                else
                {
                    sH_IR_MDA_Data.active_status = 1;
                }

                sH_IR_MDA_Data.created_at = DateTime.Now;
                sH_IR_MDA_Data.updated_at = DateTime.Now;
                db.SH_IR_MDA_Data.Add(sH_IR_MDA_Data);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_MDA_Data_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_MDA", "importantFinancialInformation");
            }
            var get_detail = db.SH_IR_MDA_Data.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_MDA", "importantFinancialInformation");
            }
            var model = new model_input { SH_IR_MDA_Data = get_detail };
            return View(model);
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_MDA_Data_edit_Submit(SH_IR_MDA_Data SH_IR_MDA_Data,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {

                if (SH_IR_MDA_Data.titleTH == null || SH_IR_MDA_Data.titleENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG" });
                }

                if (SH_IR_MDA_Data.detailsTitleTH == null || SH_IR_MDA_Data.detailsTitleENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ รายละเอียด TH / ENG" });
                }

                var old_data = db.SH_IR_MDA_Data.Where(x => x.id == SH_IR_MDA_Data.id).FirstOrDefault();

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_importantFinancial/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_importantFinancial/" + datestr + extension);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_importantFinancial/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.image_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_importantFinancial/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_IR_MDA_Data.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.titleTH = SH_IR_MDA_Data.titleTH;
                old_data.titleENG = SH_IR_MDA_Data.titleENG;
                old_data.detailsTitleTH = SH_IR_MDA_Data.detailsTitleTH;
                old_data.detailsTitleENG = SH_IR_MDA_Data.detailsTitleENG;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_MDA_DataDetails_create()
        {
            return View();
        }
        public IActionResult SH_IR_MDA_DataDetails_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_MDA", "importantFinancialInformation");
            }
            var get_detail = db.SH_IR_MDA_DataDetails.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_MDA", "importantFinancialInformation");
            }
            var model = new model_input { SH_IR_MDA_DataDetails = get_detail };
            return View(model);
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_MDA_DataDetails_submit(SH_IR_MDA_DataDetails SH_IR_MDA_DataDetails, string? Year_Str,
            List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

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

                        SH_IR_MDA_DataDetails.file_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_importantFinancial/" + datestr + extension);

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

                        SH_IR_MDA_DataDetails.file_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_importantFinancial/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (SH_IR_MDA_DataDetails.active_status != 1)
                {
                    SH_IR_MDA_DataDetails.active_status = 0;
                }
                else
                {
                    SH_IR_MDA_DataDetails.active_status = 1;
                }

                SH_IR_MDA_DataDetails.year = InsertDate_year;
                SH_IR_MDA_DataDetails.created_at = DateTime.Now;
                SH_IR_MDA_DataDetails.updated_at = DateTime.Now;
                db.SH_IR_MDA_DataDetails.Add(SH_IR_MDA_DataDetails);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Get_Edit_SH_IR_MDA_DataDetails(int? id)
        {
            var InfoDataedit = db.SH_IR_MDA_DataDetails.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_MDA_DataDetails_edit_Submit(SH_IR_MDA_DataDetails SH_IR_MDA_DataDetails, string? Year_Str,
            List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (SH_IR_MDA_DataDetails.title == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ" });
                }

                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var old_data = db.SH_IR_MDA_DataDetails.Where(x => x.id == SH_IR_MDA_DataDetails.id).FirstOrDefault();

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_importantFinancial/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);

                            old_data.file_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_importantFinancial/" + datestr + extension);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_importantFinancial/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);

                            old_data.file_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_importantFinancial/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (SH_IR_MDA_DataDetails.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }
                old_data.title = SH_IR_MDA_DataDetails.title;

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
        public IActionResult SH_IR_MDA_Data_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_MDA_Data.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_MDA_DataDetails_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_MDA_DataDetails.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_MDA_Data_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_MDA_Data.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {

                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_importantFinancial/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_importantFinancial/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }
                    db.SH_IR_MDA_Data.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_MDA_DataDetails_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_MDA_DataDetails.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {

                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_importantFinancial/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_importantFinancial/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.SH_IR_MDA_DataDetails.Remove(checkrow);
                    db.SaveChanges();

                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }


        ////

        public IActionResult SH_IR_finance_statement()
        {
            return View();
        }
        public IActionResult SH_IR_finance_statement_create()
        {
            return View();
        }
        public IActionResult SH_IR_finance_statement_edit(int? id)
        {
            return View();
        }
        public IActionResult SH_IR_finance_statement_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_Finance_Statement.ToList();

                var add_count = new List<IR_Important_Financial_model.SH_IR_Finance_Statement_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_Important_Financial_model.SH_IR_Finance_Statement_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                        linkTH = items.linkTH,
                        linkENG = items.linkENG,
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
        [HttpPost]
        public IActionResult SH_IR_finance_statement_create_submit(SH_IR_Finance_Statement SH_IR_Finance_Statement)
        {
            try
            { 
                if (SH_IR_Finance_Statement.active_status == 1)
                {
                    var check_other = from up2 in db.SH_IR_Finance_Statement
                                      where up2.active_status == 1
                                      select up2;
                    foreach (SH_IR_Finance_Statement up2 in check_other)
                    {
                        up2.active_status = 0;
                    }
                    db.SaveChanges();
                }

                if (SH_IR_Finance_Statement.active_status != 1)
                {
                    SH_IR_Finance_Statement.active_status = 0;
                }
                else
                {
                    SH_IR_Finance_Statement.active_status = 1;
                }

                SH_IR_Finance_Statement.created_at = DateTime.Now;
                SH_IR_Finance_Statement.updated_at = DateTime.Now;
                db.SH_IR_Finance_Statement.Add(SH_IR_Finance_Statement);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        [HttpPut]
        public async Task<IActionResult> SH_IR_finance_statement_Edit_Submit(SH_IR_Finance_Statement SH_IR_Finance_Statement)
        {
            try
            {
                var Finance_Statement = db.SH_IR_Finance_Statement.FirstOrDefault(x => x.id == SH_IR_Finance_Statement.id);
                if (Finance_Statement is not null)
                { 
                    if (SH_IR_Finance_Statement.active_status == 1)
                    {
                        var check_other = from up2 in db.SH_IR_Finance_Statement
                                          where up2.id != SH_IR_Finance_Statement.id && up2.active_status == 1
                                          select up2;
                        foreach (SH_IR_Finance_Statement up2 in check_other)
                        {
                            up2.active_status = 0;
                        }
                        db.SaveChanges();
                    } 

                    Finance_Statement.linkTH = SH_IR_Finance_Statement.linkTH;
                    Finance_Statement.linkENG = SH_IR_Finance_Statement.linkENG;
                    if (SH_IR_Finance_Statement.active_status != 1)
                    {
                        Finance_Statement.active_status = 0;
                    }
                    else
                    {
                        Finance_Statement.active_status = 1;
                    }

                    Finance_Statement.updated_at = DateTime.Now;
                    db.Entry(Finance_Statement).State = EntityState.Modified;
                    await db.SaveChangesAsync();
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

        [HttpGet]
        public async Task<IActionResult> Get_SH_IR_finance_statement_Edit(int? id)
        {
            try
            {
                var DB = await db.SH_IR_Finance_Statement.FirstOrDefaultAsync(x => x.id == id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> SH_IR_finance_statement_Delete(int? id)
        {
            try
            {
                var DB = db.SH_IR_Finance_Statement.FirstOrDefault(x => x.id == id);
                if (DB is not null)
                {
                    db.SH_IR_Finance_Statement.Remove(DB);
                    await db.SaveChangesAsync();
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
        [HttpPost]

        public async Task<IActionResult> SH_IR_finance_statement_ChangeStatus(int? id)
        {
            try
            {
                var DB = db.SH_IR_Finance_Statement.FirstOrDefault(x => x.id == id);
                if (DB is not null)
                {
                    if (DB.active_status != 1)
                    {
                        var Change = db.SH_IR_Finance_Statement.ToList();
                        foreach (var item in Change)
                        {
                            item.active_status = 0;
                            db.Entry(item).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }
                        if (DB.active_status == 1)
                        {
                            DB.active_status = 0;
                            db.Entry(DB).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }
                        else
                        {
                            DB.active_status = 1;
                            db.Entry(DB).State = EntityState.Modified;
                            await db.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    return new JsonResult(new { status = "error", messageArray = "error" });
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }



        //
        public IActionResult SH_IR_finance_position_DataDetails_getTable(int? id)
        {
            try
            {
                var Raw_list = db.SH_IR_financial_position_DataDetails.Where(x => x.financialPosition_id == id).ToList();

                var add_count = new List<IR_Important_Financial_model.SH_IR_financial_postition_DataDetail_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_Important_Financial_model.SH_IR_financial_postition_DataDetail_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                        amount = items.amount,
                        percent = items.percent,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG
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
        public IActionResult SH_IR_finance_position(int? id)
        {
            var checkrow = db.SH_IR_financial_position.FirstOrDefault(x => x.id == id);
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_important_financial = count_row, SH_IR_financial_position = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_finance_position_create(int? id)
        {
            var check = db.SH_IR_financial_position.FirstOrDefault(x => x.id == id);
            if (check == null)
            {
                return RedirectToAction("SH_IR_finance_statement", "importantFinancialInformation");
            }
            var model = new model_input { SH_IR_financial_position = check };
            return View(model);
        }
        public IActionResult SH_IR_finance_positionDataDetails_submit(SH_IR_financial_position_DataDetails SH_IR_financial_position_DataDetails)
        {
            try
            {

                SH_IR_financial_position_DataDetails.financialPosition_id = SH_IR_financial_position_DataDetails.financialPosition_id;
                SH_IR_financial_position_DataDetails.titleTH = SH_IR_financial_position_DataDetails.titleTH;
                SH_IR_financial_position_DataDetails.titleENG = SH_IR_financial_position_DataDetails.titleENG;
                SH_IR_financial_position_DataDetails.amount = SH_IR_financial_position_DataDetails.amount;
                SH_IR_financial_position_DataDetails.percent = SH_IR_financial_position_DataDetails.percent;
                SH_IR_financial_position_DataDetails.created_at = DateTime.Now;
                SH_IR_financial_position_DataDetails.updated_at = DateTime.Now;
                db.SH_IR_financial_position_DataDetails.Add(SH_IR_financial_position_DataDetails);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_finance_position_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_finance_statement", "importantFinancialInformation");
            }
            var get_detail = db.SH_IR_financial_position_DataDetails.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_finance_statement", "importantFinancialInformation");
            }
            var ddd = db.SH_IR_financial_position.Where(x => x.id == get_detail.financialPosition_id).FirstOrDefault();
            var model = new model_input { SH_IR_financial_position_DataDetails = get_detail, SH_IR_financial_position = ddd };
            return View(model);
        }
        public IActionResult SH_IR_finance_positionDataDetails_edit_Submit(SH_IR_financial_position_DataDetails SH_IR_financial_position_DataDetails)
        {
            try
            {
                if (SH_IR_financial_position_DataDetails.titleTH == null || SH_IR_financial_position_DataDetails.titleENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG" });
                }

                var old_data = db.SH_IR_financial_position_DataDetails.Where(x => x.id == SH_IR_financial_position_DataDetails.id).FirstOrDefault();

                old_data.titleTH = SH_IR_financial_position_DataDetails.titleTH;
                old_data.titleENG = SH_IR_financial_position_DataDetails.titleENG;
                old_data.amount = SH_IR_financial_position_DataDetails.amount;
                old_data.percent = SH_IR_financial_position_DataDetails.percent;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_finance_positionDataDetails_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_financial_position_DataDetails.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    db.SH_IR_financial_position_DataDetails.Remove(checkrow);
                    db.SaveChanges();

                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }


        ///
        public IActionResult SH_IR_prospectus()
        {
            var checkrow = db.SH_IR_prospectus.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_prospectus = count_row, fod_SH_IR_prospectus = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_prospectus_addData(SH_IR_prospectus fod_SH_IR_MDA)
        {
            try
            {
                var checkrow = db.SH_IR_prospectus.FirstOrDefault();
                if (checkrow == null)
                {
                    fod_SH_IR_MDA.created_at = DateTime.Now;
                    fod_SH_IR_MDA.updated_at = DateTime.Now;
                    db.SH_IR_prospectus.Add(fod_SH_IR_MDA);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.Link = fod_SH_IR_MDA.Link;
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


        ///

        public IActionResult SH_IR_financial_highlight()
        {
            var checkrow = db.SH_IR_financial_highlight.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_financial_highlight = count_row, fod_SH_IR_financial_highlight = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_financial_highlight_Data_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_financial_highlight_Data.ToList();

                var add_count = new List<IR_Important_Financial_model.SH_IR_financial_highlight_Data_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_Important_Financial_model.SH_IR_financial_highlight_Data_table
                    {
                        count_row = count,
                        id = items.id,
                        active_status = items.active_status,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                        profitTitleTH = items.profitTitleTH,
                        profitTitleENG = items.profitTitleENG
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
        public IActionResult SH_IR_financial_highlight_Data(int? id)
        {
            var checkrow = db.SH_IR_financial_highlight_Data.FirstOrDefault(x => x.id == id);
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_financial_highlight_Data = count_row, fod_SH_IR_financial_highlight_Data = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_financial_highlight_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_financial_highlight", "importantFinancialInformation");
            }
            var details = db.SH_IR_financial_highlight_Data.FirstOrDefault(x => x.id == id);
            if (details == null)
            {
                return RedirectToAction("SH_IR_financial_highlight", "importantFinancialInformation");
            }

            var checkrow = db.SH_IR_financial_highlight.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { SH_IR_financial_highlight_Data = details, count_row_SH_IR_financial_highlight = count_row, fod_SH_IR_financial_highlight = checkrow };
            return View(model);
        }

        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SH_IR_financial_highlight_addData(SH_IR_financial_highlight fod_SH_IR_financial_highlight, List<IFormFile> upload_image, List<IFormFile> upload_image_ENG
            , string? date1Title_Str, string? date2Title_Str, string date3Title_Str)
        {
            try
            {
                var checkrow = db.SH_IR_financial_highlight.FirstOrDefault();

                if (date1Title_Str == null || date2Title_Str == "" || date3Title_Str == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ วันที่ทั้งหมด!" });
                }
                if (checkrow == null)
                {
                    if (upload_image.Count == 0 || upload_image_ENG.Count == 0)
                    {
                        return Json(new { status = "warning", message = "กรุณากรอกข้อมูลให้ครบ!" });
                    }
                }
                DateTime InsertDate_1 = DateTime.ParseExact(date1Title_Str, "dd/MM/yyyy", new CultureInfo("en-US"));
                DateTime InsertDate_2 = DateTime.ParseExact(date2Title_Str, "dd/MM/yyyy", new CultureInfo("en-US"));
                DateTime InsertDate_3 = DateTime.ParseExact(date3Title_Str, "dd/MM/yyyy", new CultureInfo("en-US"));

                if (checkrow == null)
                {
                    fod_SH_IR_financial_highlight.created_at = DateTime.Now;
                    fod_SH_IR_financial_highlight.updated_at = DateTime.Now;

                    fod_SH_IR_financial_highlight.date1Title = InsertDate_1;
                    fod_SH_IR_financial_highlight.date2Title = InsertDate_2;
                    fod_SH_IR_financial_highlight.date3Title = InsertDate_3;

                    foreach (var imgFile in upload_image)
                    {
                        if (imgFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(imgFile.FileName);
                            extension = extension.Replace(" ", "");
                            fod_SH_IR_financial_highlight.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_IR_financial_hilight/" + datestr + extension);

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

                            fod_SH_IR_financial_highlight.image_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/SH_IR_financial_hilight/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                imgFile_ENG.CopyTo(stream);
                            }
                        }
                    }

                    db.SH_IR_financial_highlight.Add(fod_SH_IR_financial_highlight);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = fod_SH_IR_financial_highlight.titleTH;
                    checkrow.titleENG = fod_SH_IR_financial_highlight.titleENG;
                    checkrow.detailsTitleTH = fod_SH_IR_financial_highlight.detailsTitleTH;
                    checkrow.detailsTitleENG = fod_SH_IR_financial_highlight.detailsTitleENG;
                    checkrow.profitTitleTH = fod_SH_IR_financial_highlight.profitTitleTH;
                    checkrow.profitTitleENG = fod_SH_IR_financial_highlight.profitTitleENG;
                    checkrow.detailsTH = fod_SH_IR_financial_highlight.detailsTH;
                    checkrow.detailsENG = fod_SH_IR_financial_highlight.detailsENG;

                    checkrow.date1Title = InsertDate_1;
                    checkrow.date2Title = InsertDate_2;
                    checkrow.date3Title = InsertDate_3;

                    //image

                    if (upload_image.Count > 0)
                    {
                        foreach (var formFile in upload_image)
                        {
                            if (formFile.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_financial_hilight/" + checkrow.image_name);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.Ticks.ToString();
                                var extension = Path.GetExtension(formFile.FileName);

                                checkrow.image_name = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_financial_hilight/" + datestr + extension);

                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFile.CopyTo(stream);
                                }
                            }
                        }
                    }

                    if (upload_image_ENG.Count > 0)
                    {
                        foreach (var formFileENG in upload_image_ENG)
                        {
                            if (formFileENG.Length > 0)
                            {
                                var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_financial_hilight/" + checkrow.image_name_ENG);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }

                                var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                                var extension = Path.GetExtension(formFileENG.FileName);

                                checkrow.image_name_ENG = datestr + extension;
                                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SH_IR_financial_hilight/" + datestr + extension);

                                using (var stream = System.IO.File.Create(filePath))
                                {
                                    formFileENG.CopyTo(stream);
                                }
                            }
                        }
                    }

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
        public IActionResult Get_Edit_SH_IR_financial_highlight_addData()
        {
            var InfoDataedit = db.SH_IR_financial_highlight.FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }
        public IActionResult SH_IR_financial_highlight_Submit(SH_IR_financial_highlight_Data SH_IR_financial_highlight_Data)
        {
            try
            {
                SH_IR_financial_highlight_Data.created_at = DateTime.Now;
                SH_IR_financial_highlight_Data.updated_at = DateTime.Now;
                db.SH_IR_financial_highlight_Data.Add(SH_IR_financial_highlight_Data);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_Data_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_financial_highlight_Data.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var dataDeatils = db.SH_IR_financial_highlight_DataDetails.Where(x => x.fH_Data_id == checkrow.id).ToList();
                    foreach (var item in dataDeatils)
                    {
                        var getData = db.SH_IR_financial_highlight_DataDetails.Where(x => x.id == item.id).FirstOrDefault();
                        if (getData != null)
                        {
                            db.SH_IR_financial_highlight_DataDetails.Remove(getData);
                            db.SaveChanges();
                        }
                    }

                    db.SH_IR_financial_highlight_Data.Remove(checkrow);
                    db.SaveChanges();

                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_Data_edit_Submit(SH_IR_financial_highlight_Data SH_IR_financial_highlight_Data)
        {
            try
            {

                if (SH_IR_financial_highlight_Data.profitTitleTH == null || SH_IR_financial_highlight_Data.profitTitleENG == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG " });
                }

                var old_data = db.SH_IR_financial_highlight_Data.Where(x => x.id == SH_IR_financial_highlight_Data.id).FirstOrDefault();

                old_data.profitTitleTH = SH_IR_financial_highlight_Data.profitTitleTH;
                old_data.profitTitleENG = SH_IR_financial_highlight_Data.profitTitleENG;
                old_data.active_status = SH_IR_financial_highlight_Data.active_status;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_Data_getEditData(int? id)
        {
            var get_data = db.SH_IR_financial_highlight_Data.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }
        public IActionResult SH_IR_financial_highlight_DataDetails_getTable(int? id)
        {
            try
            {
                var Raw_list = db.SH_IR_financial_highlight_DataDetails.Where(x => x.fH_Data_id == id).OrderByDescending(x => x.year).ToList();
                var add_count = new List<IR_Important_Financial_model.SH_IR_financial_highlight_DataDetailstable>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    var dateDatas = Convert.ToDateTime(items.year);
                    var InsertDates = dateDatas.ToString("yyyy", new CultureInfo("en-US"));

                    add_count.Add(new IR_Important_Financial_model.SH_IR_financial_highlight_DataDetailstable
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                        fH_Data_id = items.fH_Data_id,
                        year = InsertDates,
                        amount = items.amount
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
        public IActionResult SH_IR_financial_highlight_DataDetails_Submit(SH_IR_financial_highlight_DataDetails fH_DataDetails, string Year_Str)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "warning", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var checkData = db.SH_IR_financial_highlight_DataDetails.Where(x => x.fH_Data_id == fH_DataDetails.fH_Data_id).ToList();
                foreach (var item in checkData)
                {
                    var getData = db.SH_IR_financial_highlight_DataDetails.FirstOrDefault(x => x.id == item.id);
                    if (InsertDate_year.Year == getData.year.Value.Year)
                    {
                        return Json(new { status = "warning", message = "ปีที่เลือกมีอยู่แล้ว!" });
                    }
                }
                fH_DataDetails.created_at = DateTime.Now;
                fH_DataDetails.updated_at = DateTime.Now;
                fH_DataDetails.year = InsertDate_year;

                db.SH_IR_financial_highlight_DataDetails.Add(fH_DataDetails);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_DataDetails_getEditData(int? id)
        {
            var get_data = db.SH_IR_financial_highlight_DataDetails.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }
        public IActionResult SH_IR_financial_highlight_DataDetails_edit_Submit(SH_IR_financial_highlight_DataDetails fH_dataDetails, string? Year_Str)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "warning", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var get_oldData = db.SH_IR_financial_highlight_DataDetails.Where(x => x.id == fH_dataDetails.id).FirstOrDefault();

                var checkData = db.SH_IR_financial_highlight_DataDetails.Where(x => x.fH_Data_id == get_oldData.fH_Data_id && x.id != get_oldData.id).ToList();
                foreach (var item in checkData)
                {
                    var getData = db.SH_IR_financial_highlight_DataDetails.FirstOrDefault(x => x.id == item.id);
                    if (InsertDate_year.Year == getData.year.Value.Year)
                    {
                        return Json(new { status = "warning", message = "ปีที่เลือกมีอยู่แล้ว!" });
                    }
                }

                get_oldData.amount = fH_dataDetails.amount;
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
        public IActionResult SH_IR_financial_highlight_DataDetails_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_financial_highlight_DataDetails.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    db.SH_IR_financial_highlight_DataDetails.Remove(checkrow);
                    db.SaveChanges();

                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        public IActionResult SH_IR_financial_highlight_Details_getTable()
        {
            try
            {
                var Raw_list = db.SH_IR_financial_highlight_Details.ToList();
                var add_count = new List<IR_Important_Financial_model.SH_IR_financial_highlight_Details_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_Important_Financial_model.SH_IR_financial_highlight_Details_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                        titleTH = items.titleTH,
                        titleENG = items.titleENG
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
        public IActionResult SH_IR_financial_highlight_Details(int? id)
        {
            var checkrow = db.SH_IR_financial_highlight_Details.FirstOrDefault(x => x.id == id);
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_financial_highlight_Details = count_row, SH_IR_financial_highlight_Details = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_financial_highlight_DetailsData_getTable(int? id)
        {
            try
            {
                var Raw_list = db.SH_IR_financial_highlight_DetailsData.Where(x => x.financial_hilight_id == id).ToList();
                var add_count = new List<IR_Important_Financial_model.SH_IR_financial_highlight_DataDetails_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new IR_Important_Financial_model.SH_IR_financial_highlight_DataDetails_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
                        profitTitleTH = items.profitTitleTH,
                        profitTitleENG = items.profitTitleENG
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
        public IActionResult SH_IR_financial_highlight_Details_Submit(SH_IR_financial_highlight_Details SH_IR_financial_highlight_Details)
        {
            try
            {
                if (SH_IR_financial_highlight_Details.active_status != 1)
                {
                    SH_IR_financial_highlight_Details.active_status = 0;
                }
                else
                {
                    SH_IR_financial_highlight_Details.active_status = 1;
                }
                SH_IR_financial_highlight_Details.created_at = DateTime.Now;
                SH_IR_financial_highlight_Details.updated_at = DateTime.Now;

                db.SH_IR_financial_highlight_Details.Add(SH_IR_financial_highlight_Details);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_Details_edit_Submit(SH_IR_financial_highlight_Details SH_IR_financial_highlight_Details)
        {
            try
            {
                var get_oldData = db.SH_IR_financial_highlight_Details.Where(x => x.id == SH_IR_financial_highlight_Details.id).FirstOrDefault();

                if (SH_IR_financial_highlight_Details.active_status != 1)
                {
                    get_oldData.active_status = 0;
                }
                else
                {
                    get_oldData.active_status = 1;
                }
                get_oldData.titleTH = SH_IR_financial_highlight_Details.titleTH;
                get_oldData.titleENG = SH_IR_financial_highlight_Details.titleENG;

                get_oldData.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_Details_getEditData(int? id)
        {
            var get_data = db.SH_IR_financial_highlight_Details.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }
        public IActionResult SH_IR_financial_highlight_DetailsData(int? id)
        {
            var check = db.SH_IR_financial_highlight_Details.FirstOrDefault(x => x.id == id);
            if (check == null)
            {
                return RedirectToAction("SH_IR_financial_highlight", "importantFinancialInformation");
            }
            var checkrow = db.SH_IR_financial_highlight.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { SH_IR_financial_highlight_Details = check, count_row_SH_IR_financial_highlight = count_row, fod_SH_IR_financial_highlight = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_financial_highlight_DetailsData_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("SH_IR_financial_highlight", "importantFinancialInformation");
            }
            var get_detail = db.SH_IR_financial_highlight_DetailsData.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("SH_IR_financial_highlight", "importantFinancialInformation");
            }
            var checkrow = db.SH_IR_financial_highlight.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var ddd = db.SH_IR_financial_highlight_Details.Where(x => x.id == get_detail.financial_hilight_id).FirstOrDefault();
            var model = new model_input { SH_IR_financial_highlight_DetailsData = get_detail, SH_IR_financial_highlight_Details = ddd, count_row_SH_IR_financial_highlight = count_row, fod_SH_IR_financial_highlight = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_financial_highlight_DetailsData_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_financial_highlight_DetailsData.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var checkData = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.fH_DetailsData_id == checkrow.id).ToList();
                    foreach (var item in checkData)
                    {
                        var getData = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.id == item.id).FirstOrDefault();
                        if (getData != null)
                        {
                            db.SH_IR_financial_highlight_DetailsData_Items.Remove(getData);
                            db.SaveChanges();
                        }
                    }

                    db.SH_IR_financial_highlight_DetailsData.Remove(checkrow);
                    db.SaveChanges();

                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_DetailsData_submit(SH_IR_financial_highlight_DetailsData SH_IR_financial_highlight_DetailsData)
        {
            try
            {
                SH_IR_financial_highlight_DetailsData.financial_hilight_id = SH_IR_financial_highlight_DetailsData.financial_hilight_id;
                SH_IR_financial_highlight_DetailsData.profitTitleTH = SH_IR_financial_highlight_DetailsData.profitTitleTH;
                SH_IR_financial_highlight_DetailsData.profitTitleENG = SH_IR_financial_highlight_DetailsData.profitTitleENG;
                SH_IR_financial_highlight_DetailsData.active_status = SH_IR_financial_highlight_DetailsData.active_status;
                SH_IR_financial_highlight_DetailsData.created_at = DateTime.Now;
                SH_IR_financial_highlight_DetailsData.updated_at = DateTime.Now;
                db.SH_IR_financial_highlight_DetailsData.Add(SH_IR_financial_highlight_DetailsData);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_DetailsData_edit_Submit(SH_IR_financial_highlight_DetailsData SH_IR_financial_highlight_DetailsData)
        {
            try
            {
                if (SH_IR_financial_highlight_DetailsData.profitTitleTH == null || SH_IR_financial_highlight_DetailsData.profitTitleENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH / ENG" });
                }

                var old_data = db.SH_IR_financial_highlight_DetailsData.Where(x => x.id == SH_IR_financial_highlight_DetailsData.id).FirstOrDefault();

                old_data.profitTitleTH = SH_IR_financial_highlight_DetailsData.profitTitleTH;
                old_data.profitTitleENG = SH_IR_financial_highlight_DetailsData.profitTitleENG;
                old_data.active_status = SH_IR_financial_highlight_DetailsData.active_status;

                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_Details_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_financial_highlight_Details.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var details = db.SH_IR_financial_highlight_DetailsData.Where(x => x.financial_hilight_id == checkrow.id).ToList();
                    if (details != null)
                    {
                        foreach (var item in details)
                        {
                            var deleteitem = db.SH_IR_financial_highlight_DetailsData.FirstOrDefault(x => x.id == item.id);
                            {
                                if (deleteitem != null)
                                {
                                    var checkDetails = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.fH_DetailsData_id == deleteitem.id).ToList();
                                    foreach (var data in checkDetails)
                                    {
                                        var deleteData = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.id == data.id).FirstOrDefault();
                                        if (deleteData != null)
                                        {
                                            db.SH_IR_financial_highlight_DetailsData_Items.Remove(deleteData);
                                            db.SaveChanges();
                                        }
                                    }
                                    db.SH_IR_financial_highlight_DetailsData.Remove(deleteitem);
                                    db.SaveChanges();
                                }
                            }

                        }
                    }

                    db.SH_IR_financial_highlight_Details.Remove(checkrow);
                    db.SaveChanges();

                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_Details_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_financial_highlight_Details.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_financial_highlight_Data_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_financial_highlight_Data.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_financial_highlight_DetailsData_changeStatus(int? id, string? status)
        {
            var get_data = db.SH_IR_financial_highlight_DetailsData.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult SH_IR_financial_highlight_DetailsDataItem(int? id)
        {
            var checkrow = db.SH_IR_financial_highlight_DetailsData.FirstOrDefault(x => x.id == id);
            if (checkrow == null)
            {
                return RedirectToAction("SH_IR_financial_highlight", "importantFinancialInformation");
            }
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_SH_IR_financial_highlight_DetailsData = count_row, fod_SH_IR_financial_highlight_DetailsData = checkrow };
            return View(model);
        }
        public IActionResult SH_IR_financial_highlight_DetailsDataItem_getTable(int? id)
        {
            try
            {
                var Raw_list = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.fH_DetailsData_id == id).OrderByDescending(x => x.year).ToList();
                var add_count = new List<IR_Important_Financial_model.SH_IR_financial_highlight_DetailsData_Items_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    var dateDatas = Convert.ToDateTime(items.year);
                    var InsertDates = dateDatas.ToString("yyyy", new CultureInfo("en-US"));

                    add_count.Add(new IR_Important_Financial_model.SH_IR_financial_highlight_DetailsData_Items_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                        year = InsertDates,
                        amount = items.amount,
                        fH_DetailsData_id = items.fH_DetailsData_id
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
        public IActionResult SH_IR_financial_highlight_DetailsDataItem_Submit(SH_IR_financial_highlight_DetailsData_Items fH_DetailsData_Item, string Year_Str)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "warning", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var checkData = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.fH_DetailsData_id == fH_DetailsData_Item.fH_DetailsData_id).ToList();
                foreach (var item in checkData)
                {
                    var getData = db.SH_IR_financial_highlight_DetailsData_Items.FirstOrDefault(x => x.id == item.id);
                    if (InsertDate_year.Year == getData.year.Value.Year)
                    {
                        return Json(new { status = "warning", message = "ปีที่เลือกมีอยู่แล้ว!" });
                    }
                }
                fH_DetailsData_Item.created_at = DateTime.Now;
                fH_DetailsData_Item.updated_at = DateTime.Now;
                fH_DetailsData_Item.year = InsertDate_year;
                var getData_Id = db.SH_IR_financial_highlight_DetailsData.Where(x => x.id == fH_DetailsData_Item.fH_DetailsData_id).FirstOrDefault();

                fH_DetailsData_Item.fH_Details_id = getData_Id.financial_hilight_id;

                db.SH_IR_financial_highlight_DetailsData_Items.Add(fH_DetailsData_Item);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_DetailsDataItem_edit_Submit(SH_IR_financial_highlight_DetailsData_Items fH_DetailsData_Item, string? Year_Str)
        {
            try
            {
                if (Year_Str == null)
                {
                    return Json(new { status = "warning", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var get_oldData = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.id == fH_DetailsData_Item.id).FirstOrDefault();

                var checkData = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.fH_DetailsData_id == get_oldData.fH_DetailsData_id && x.id != get_oldData.id && x.fH_Details_id != get_oldData.fH_Details_id).ToList();
                foreach (var item in checkData)
                {
                    var getData = db.SH_IR_financial_highlight_DetailsData_Items.FirstOrDefault(x => x.id == item.id);
                    if (InsertDate_year.Year == getData.year.Value.Year)
                    {
                        return Json(new { status = "warning", message = "ปีที่เลือกมีอยู่แล้ว!" });
                    }
                }

                get_oldData.amount = fH_DetailsData_Item.amount;
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
        public IActionResult SH_IR_financial_highlight_DetailsDataItem_delete(int? id)
        {
            try
            {
                var checkrow = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    db.SH_IR_financial_highlight_DetailsData_Items.Remove(checkrow);
                    db.SaveChanges();

                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult SH_IR_financial_highlight_DetailsDataItem_getEditData(int? id)
        {
            var get_data = db.SH_IR_financial_highlight_DetailsData_Items.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }


    }
}



