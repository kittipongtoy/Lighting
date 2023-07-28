﻿using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class ResourceFacilityController : Controller
    {

        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;

        public ResourceFacilityController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }

        public IActionResult RF_Manufacturing()
        {
            var checkrow = db.RF_Manufacturing.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Manufacturing = count_row, fod_RF_Manufacturing = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_Manufacturing_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Manufacturing_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Manufacturing_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Manufacturing_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
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
        public IActionResult RF_Manufacturing_submit(RF_Manufacturing rf_manufacturing)
        {
            try
            {
                var checkrow = db.RF_Manufacturing.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_manufacturing.created_at = DateTime.Now;
                    rf_manufacturing.updated_at = DateTime.Now;
                    db.RF_Manufacturing.Add(rf_manufacturing);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_manufacturing.titleTH;
                    checkrow.titleENG = rf_manufacturing.titleENG;
                    checkrow.detailsTitleTH = rf_manufacturing.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_manufacturing.detailsTitleENG;
                    checkrow.link = rf_manufacturing.link;
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
        public IActionResult RF_ManufacturingImages_create()
        {
            return View();
        }
        public IActionResult RF_ManufacturingImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_Manufacturing", "ResourceFacility");
            }
            var get_detail = db.RF_Manufacturing_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_Manufacturing", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Manufacturing_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_ManufactufingImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Manufacturing_Images.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult RF_ManufactufingImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Manufacturing_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Manufacturing_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_ManufactufingImages_submit(RF_Manufacturing_Images r_ManufacturingImages, 
           List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            { 
                if (upload_image.Count == 0 || upload_image_ENG.Count == 0 )
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
                        r_ManufacturingImages.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + datestr + imgFile.FileName);

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

                        r_ManufacturingImages.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }
                 
                if (r_ManufacturingImages.active_status != 1)
                {
                    r_ManufacturingImages.active_status = 0;
                }
                else
                {
                    r_ManufacturingImages.active_status = 1;
                }

                r_ManufacturingImages.created_at = DateTime.Now;
                r_ManufacturingImages.updated_at = DateTime.Now;
                db.RF_Manufacturing_Images.Add(r_ManufacturingImages);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_ManufactufingImages_edit_Submit(RF_Manufacturing_Images rf_ManufacturingImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Manufacturing_Images.Where(x => x.id == rf_ManufacturingImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + datestr + formFile.FileName);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Manufacturing/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_ManufacturingImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }


        //
        public IActionResult RF_WarehouseLogistics()
        {
            var checkrow = db.RF_Warehouse_Logistics.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Warehouse_Logistics = count_row, fod_RF_Warehouse_Logistics = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_WarehouseLogistics_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Warehouse_Logistics_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Warehouse_Logistics_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Warehouse_Logistics_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
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
        public IActionResult RF_WarehouseLogistics_submit(RF_Warehouse_Logistics rf_WarehouseLogistics)
        {
            try
            {
                var checkrow = db.RF_Warehouse_Logistics.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_WarehouseLogistics.created_at = DateTime.Now;
                    rf_WarehouseLogistics.updated_at = DateTime.Now;
                    db.RF_Warehouse_Logistics.Add(rf_WarehouseLogistics);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_WarehouseLogistics.titleTH;
                    checkrow.titleENG = rf_WarehouseLogistics.titleENG;
                    checkrow.detailsTitleTH = rf_WarehouseLogistics.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_WarehouseLogistics.detailsTitleENG;
                    checkrow.link = rf_WarehouseLogistics.link;
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
        public IActionResult RF_WarehouseLogisticsImages_create()
        {
            return View();
        }
        public IActionResult RF_WarehouseLogisticsImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_WarehouseLogistics", "ResourceFacility");
            }
            var get_detail = db.RF_Warehouse_Logistics_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_WarehouseLogistics", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Warehouse_Logistics_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_WarehouseLogisticsImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Warehouse_Logistics_Images.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult RF_WarehouseLogisticsImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Warehouse_Logistics_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Warehouse_Logistics_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_WarehouseLogisticsImages_submit(RF_Warehouse_Logistics_Images rf_Warehouse_LogisticsImages,
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
                        rf_Warehouse_LogisticsImages.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + datestr + imgFile.FileName);

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

                        rf_Warehouse_LogisticsImages.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Warehouse_LogisticsImages.active_status != 1)
                {
                    rf_Warehouse_LogisticsImages.active_status = 0;
                }
                else
                {
                    rf_Warehouse_LogisticsImages.active_status = 1;
                }

                rf_Warehouse_LogisticsImages.created_at = DateTime.Now;
                rf_Warehouse_LogisticsImages.updated_at = DateTime.Now;
                db.RF_Warehouse_Logistics_Images.Add(rf_Warehouse_LogisticsImages);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_WarehouseLogisticsImages_edit_Submit(RF_Warehouse_Logistics_Images rf_Warehouse_LogisticsImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Warehouse_Logistics_Images.Where(x => x.id == rf_Warehouse_LogisticsImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + datestr + formFile.FileName);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Warehouse_Logistics/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_Warehouse_LogisticsImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_OverseaOffices()
        {
            var checkrow = db.RF_Oversea_Offices.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Oversea_Offices = count_row, fod_RF_Oversea_Offices = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_OverseaOffices_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Oversea_Offices_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Oversea_Offices_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Oversea_Offices_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
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
        public IActionResult RF_OverseaOffices_submit(RF_Oversea_Offices rf_Oversea_Offices)
        {
            try
            {
                var checkrow = db.RF_Oversea_Offices.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_Oversea_Offices.created_at = DateTime.Now;
                    rf_Oversea_Offices.updated_at = DateTime.Now;
                    db.RF_Oversea_Offices.Add(rf_Oversea_Offices);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_Oversea_Offices.titleTH;
                    checkrow.titleENG = rf_Oversea_Offices.titleENG;
                    checkrow.detailsTitleTH = rf_Oversea_Offices.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_Oversea_Offices.detailsTitleENG;
                    checkrow.link = rf_Oversea_Offices.link;
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
        public IActionResult RF_OverseaOfficesImages_create()
        {
            return View();
        }
        public IActionResult RF_OverseaOfficesImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_OverseaOffices", "ResourceFacility");
            }
            var get_detail = db.RF_Oversea_Offices_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_OverseaOffices", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Oversea_Offices_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_OverseaOfficesImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Oversea_Offices_Images.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult RF_OverseaOfficesImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Oversea_Offices_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Oversea_Offices_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_OverseaOfficesImages_submit(RF_Oversea_Offices_Images rf_Oversea_Offices_Images,
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
                        rf_Oversea_Offices_Images.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + datestr + imgFile.FileName);

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

                        rf_Oversea_Offices_Images.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Oversea_Offices_Images.active_status != 1)
                {
                    rf_Oversea_Offices_Images.active_status = 0;
                }
                else
                {
                    rf_Oversea_Offices_Images.active_status = 1;
                }

                rf_Oversea_Offices_Images.created_at = DateTime.Now;
                rf_Oversea_Offices_Images.updated_at = DateTime.Now;
                db.RF_Oversea_Offices_Images.Add(rf_Oversea_Offices_Images);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_OverseaOfficesImages_edit_Submit(RF_Oversea_Offices_Images rf_Oversea_Offices_Images,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Oversea_Offices_Images.Where(x => x.id == rf_Oversea_Offices_Images.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + datestr + formFile.FileName);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Oversea_Offices/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_Oversea_Offices_Images.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_SolidState()
        {
            var checkrow = db.RF_Solid_States.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Solid_States = count_row, fod_RF_Solid_States = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_SolidState_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Solid_States_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Solid_States_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Solid_States_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
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
        public IActionResult RF_SolidState_submit(RF_Solid_States rf_Solid_States)
        {
            try
            {
                var checkrow = db.RF_Solid_States.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_Solid_States.created_at = DateTime.Now;
                    rf_Solid_States.updated_at = DateTime.Now;
                    db.RF_Solid_States.Add(rf_Solid_States);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_Solid_States.titleTH;
                    checkrow.titleENG = rf_Solid_States.titleENG;
                    checkrow.detailsTitleTH = rf_Solid_States.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_Solid_States.detailsTitleENG;
                    checkrow.link = rf_Solid_States.link;
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
        public IActionResult RF_SolidStateImages_create()
        {
            return View();
        }
        public IActionResult RF_SolidStateImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_SolidState", "ResourceFacility");
            }
            var get_detail = db.RF_Solid_States_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_SolidState", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Solid_States_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_SolidStateImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Solid_States_Images.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult RF_SolidStateImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Solid_States_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Solid_States_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolidStateImages_submit(RF_Solid_States_Images rf_Solid_States_Images,
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
                        rf_Solid_States_Images.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + datestr + imgFile.FileName);

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

                        rf_Solid_States_Images.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Solid_States_Images.active_status != 1)
                {
                    rf_Solid_States_Images.active_status = 0;
                }
                else
                {
                    rf_Solid_States_Images.active_status = 1;
                }

                rf_Solid_States_Images.created_at = DateTime.Now;
                rf_Solid_States_Images.updated_at = DateTime.Now;
                db.RF_Solid_States_Images.Add(rf_Solid_States_Images);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolidStateImages_edit_Submit(RF_Solid_States_Images rf_Solid_States_Images,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Solid_States_Images.Where(x => x.id == rf_Solid_States_Images.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + datestr + formFile.FileName);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solid_States/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (rf_Solid_States_Images.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_AssemblyService()
        {
            var checkrow = db.RF_Assembly_Services.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Assembly_Services = count_row, fod_RF_Assembly_Services = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_AssemblyService_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Assembly_Services_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Assembly_Services_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Assembly_Services_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
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
        public IActionResult RF_AssemblyService_submit(RF_Assembly_Services rf_Assembly_Services)
        {
            try
            {
                var checkrow = db.RF_Assembly_Services.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_Assembly_Services.created_at = DateTime.Now;
                    rf_Assembly_Services.updated_at = DateTime.Now;
                    db.RF_Assembly_Services.Add(rf_Assembly_Services);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_Assembly_Services.titleTH;
                    checkrow.titleENG = rf_Assembly_Services.titleENG;
                    checkrow.detailsTitleTH = rf_Assembly_Services.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_Assembly_Services.detailsTitleENG;
                    checkrow.link = rf_Assembly_Services.link;
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
        public IActionResult RF_AssemblyServiceImages_create()
        {
            return View();
        }
        public IActionResult RF_AssemblyServiceImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_AssemblyService", "ResourceFacility");
            }
            var get_detail = db.RF_Assembly_Services_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_AssemblyService", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Assembly_Services_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_AssemblyServiceImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Assembly_Services_Images.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult RF_AssemblyServiceImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Assembly_Services_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Assembly_Services_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_AssemblyServiceImages_submit(RF_Assembly_Services_Images rf_Assembly_ServicesImages,
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
                        rf_Assembly_ServicesImages.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + datestr + imgFile.FileName);

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

                        rf_Assembly_ServicesImages.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_Assembly_ServicesImages.active_status != 1)
                {
                    rf_Assembly_ServicesImages.active_status = 0;
                }
                else
                {
                    rf_Assembly_ServicesImages.active_status = 1;
                }

                rf_Assembly_ServicesImages.created_at = DateTime.Now;
                rf_Assembly_ServicesImages.updated_at = DateTime.Now;
                db.RF_Assembly_Services_Images.Add(rf_Assembly_ServicesImages);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_AssemblyServiceImages_edit_Submit(RF_Assembly_Services_Images rf_AssemblyServicesImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Assembly_Services_Images.Where(x => x.id == rf_AssemblyServicesImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + datestr + formFile.FileName);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Assembly_Services/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                } 

                if (rf_AssemblyServicesImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult RF_SolutionCenters()
        {
            var checkrow = db.RF_Solution_Centers.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Solution_Centers = count_row, fod_RF_Solution_Centers = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_SolutionCenters_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Solution_Centers_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Solution_Centers_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Solution_Centers_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
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
        public IActionResult RF_SolutionCenters_submit(RF_Solution_Centers rf_SolutionCenters)
        {
            try
            {
                var checkrow = db.RF_Solution_Centers.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_SolutionCenters.created_at = DateTime.Now;
                    rf_SolutionCenters.updated_at = DateTime.Now;
                    db.RF_Solution_Centers.Add(rf_SolutionCenters);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_SolutionCenters.titleTH;
                    checkrow.titleENG = rf_SolutionCenters.titleENG;
                    checkrow.detailsTitleTH = rf_SolutionCenters.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_SolutionCenters.detailsTitleENG;
                    checkrow.link = rf_SolutionCenters.link;
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
        public IActionResult RF_SolutionCentersImages_create()
        {
            return View();
        }
        public IActionResult RF_SolutionCentersImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_SolutionCenters", "ResourceFacility");
            }
            var get_detail = db.RF_Solution_Centers_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_SolutionCenters", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Solution_Centers_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_SolutionCentersImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Solution_Centers_Images.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult RF_SolutionCentersImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Solution_Centers_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Solution_Centers_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolutionCentersImages_submit(RF_Solution_Centers_Images rf_SolutionCenters_Images,
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
                        rf_SolutionCenters_Images.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + datestr + imgFile.FileName);

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

                        rf_SolutionCenters_Images.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_SolutionCenters_Images.active_status != 1)
                {
                    rf_SolutionCenters_Images.active_status = 0;
                }
                else
                {
                    rf_SolutionCenters_Images.active_status = 1;
                }

                rf_SolutionCenters_Images.created_at = DateTime.Now;
                rf_SolutionCenters_Images.updated_at = DateTime.Now;
                db.RF_Solution_Centers_Images.Add(rf_SolutionCenters_Images);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_SolutionCentersImages_edit_Submit(RF_Solution_Centers_Images rf_SolutionCentersImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Solution_Centers_Images.Where(x => x.id == rf_SolutionCentersImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + datestr + formFile.FileName);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_Solution_Centers/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (rf_SolutionCentersImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }


        //
        public IActionResult RF_InnovationCenters()
        {
            var checkrow = db.RF_Innovation_Centers.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new Resource_FacilityModels { count_RF_Innovation_Centers= count_row, fod_RF_Innovation_Centers = checkrow };
            return View(model);
        }
        public async Task<IActionResult> RF_InnovationCenters_Image_getTable()
        {
            try
            {
                var Data_list = await db.RF_Innovation_Center_Images.ToListAsync();
                var add_count = new List<Resource_FacilityModels.RF_Solution_Centers_Images_table>();
                var count = 1;
                foreach (var items in Data_list)
                {
                    add_count.Add(new Resource_FacilityModels.RF_Solution_Centers_Images_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        upload_image = items.upload_image,
                        upload_image_ENG = items.upload_image_ENG,
                        updated_at = items.updated_at,
                        active_status = items.active_status,
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
        public IActionResult RF_InnovationCenters_submit(RF_Innovation_Centers rf_InnovationCenters)
        {
            try
            {
                var checkrow = db.RF_Innovation_Centers.FirstOrDefault();
                if (checkrow == null)
                {
                    rf_InnovationCenters.created_at = DateTime.Now;
                    rf_InnovationCenters.updated_at = DateTime.Now;
                    db.RF_Innovation_Centers.Add(rf_InnovationCenters);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.titleTH = rf_InnovationCenters.titleTH;
                    checkrow.titleENG = rf_InnovationCenters.titleENG;
                    checkrow.detailsTitleTH = rf_InnovationCenters.detailsTitleTH;
                    checkrow.detailsTitleENG = rf_InnovationCenters.detailsTitleENG;
                    checkrow.link = rf_InnovationCenters.link;
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
        public IActionResult RF_InnovationCentersImages_create()
        {
            return View();
        }
        public IActionResult RF_InnovationCentersImages_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("RF_InnovationCenters", "ResourceFacility");
            }
            var get_detail = db.RF_Innovation_Center_Images.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("RF_InnovationCenters", "ResourceFacility");
            }
            var model = new Resource_FacilityModels { RF_Innovation_Center_Images = get_detail };
            return View(model);
        }
        public IActionResult RF_InnovationCentersImages_changesStatus(int? id, string? status)
        {
            var get_data = db.RF_Solution_Centers_Images.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult RF_InnovationCentersImages_delete(int? id)
        {
            try
            {
                var checkrow = db.RF_Innovation_Center_Images.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePathTH = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + checkrow.upload_image);
                    if (System.IO.File.Exists(old_filePathTH) == true)
                    {
                        System.IO.File.Delete(old_filePathTH);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + checkrow.upload_image_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    db.RF_Innovation_Center_Images.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_InnovationCentersImages_submit(RF_Innovation_Center_Images rf_InnovationCenterImages,
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
                        rf_InnovationCenterImages.upload_image = datestr + imgFile.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + datestr + imgFile.FileName);

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

                        rf_InnovationCenterImages.upload_image_ENG = datestr + imgFile_ENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + datestr + imgFile_ENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            imgFile_ENG.CopyTo(stream);
                        }
                    }
                }

                if (rf_InnovationCenterImages.active_status != 1)
                {
                    rf_InnovationCenterImages.active_status = 0;
                }
                else
                {
                    rf_InnovationCenterImages.active_status = 1;
                }

                rf_InnovationCenterImages.created_at = DateTime.Now;
                rf_InnovationCenterImages.updated_at = DateTime.Now;
                db.RF_Innovation_Center_Images.Add(rf_InnovationCenterImages);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult RF_InnovationCentersImages_edit_Submit(RF_Innovation_Center_Images rf_InnovationCenterImages,
             List<IFormFile> upload_image, List<IFormFile> upload_image_ENG)
        {
            try
            {
                var old_data = db.RF_Innovation_Center_Images.Where(x => x.id == rf_InnovationCenterImages.id).FirstOrDefault();

                old_data.updated_at = DateTime.Now;

                if (upload_image.Count > 0)
                {
                    foreach (var formFile in upload_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + old_data.upload_image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.upload_image = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + datestr + formFile.FileName);

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
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + old_data.upload_image_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFile_ENG.FileName);
                            extension = extension.Replace(" ", "");

                            old_data.upload_image_ENG = datestr + formFile_ENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/RF_InnovationCenters/" + datestr + formFile_ENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile_ENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (rf_InnovationCenterImages.active_status != 1)
                {
                    old_data.active_status = 0;
                }
                else
                {
                    old_data.active_status = 1;
                }

                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Index()
        {
            return View();
        }
    }
}
