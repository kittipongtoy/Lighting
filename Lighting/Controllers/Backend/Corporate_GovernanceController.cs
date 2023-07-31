using Lighting.Extension;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Lighting.Models;
using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class Corporate_GovernanceController : Controller
    {
        //private IConfiguration _config;
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public Corporate_GovernanceController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }
        public IActionResult Corporate_governance_index()
        {
            var checkrow = db.CorporateGovernance.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_CorporateGovernance = count_row, fod_CorporateGovernance = checkrow };
            return View(model);
        }
        public IActionResult Corporate_governance_file_changeStatus(int? id, string? status)
        {
            var get_data = db.CorporateGovernance_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Corporate_governance_file_delete(int? id)
        {
            try
            {
                var checkrow = db.CorporateGovernance_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CorporateGovernanceFile/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CorporateGovernanceFile/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }

                    var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CorporateGovernanceFile/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePathENG) == true)
                    {
                        System.IO.File.Delete(old_filePathENG);
                    }

                    var old_filePath2ENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CorporateGovernanceFile/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath2ENG) == true)
                    {
                        System.IO.File.Delete(old_filePath2ENG);
                    }
                    db.CorporateGovernance_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Corporate_governance_index_getTable_file()
        {
            try
            {
                var Raw_list = db.CorporateGovernance_File.ToList();
                var add_count = new List<table_model.CorporateGovernance_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.CorporateGovernance_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th
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
        public IActionResult Corporate_governance_index_getTable_cate()
        {
            try
            {
                var Raw_list = db.CorporateGovernance_Cate.ToList();
                var add_count = new List<table_model.CorporateGovernance_Cate_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.CorporateGovernance_Cate_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        title_th = items.title_th,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
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
        public IActionResult Corporate_governance_index_update(CorporateGovernance corporateGovernance)
        {
            try
            {
                var checkrow = db.CorporateGovernance.FirstOrDefault();
                if (checkrow == null)
                {
                    corporateGovernance.created_at = DateTime.Now;
                    db.CorporateGovernance.Add(corporateGovernance);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = corporateGovernance.title_TH;
                    checkrow.title_ENG = corporateGovernance.title_ENG;
                    checkrow.detailsTitleTH = corporateGovernance.detailsTitleTH;
                    checkrow.detailsTitleENG = corporateGovernance.detailsTitleENG;
                    checkrow.detail_th = corporateGovernance.detail_th;
                    checkrow.detail_en = corporateGovernance.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Corporate_governance_create_file()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Corporate_governance_create_file_insert(CorporateGovernance_File corporateGovernance_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (corporateGovernance_File.title_file_th == null || corporateGovernance_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (corporateGovernance_File.title_file_en == null || corporateGovernance_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        corporateGovernance_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CorporateGovernanceFile/" + datestr + extension);

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
                        corporateGovernance_File.image_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CorporateGovernanceFile/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile_ENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        corporateGovernance_File.file_name = datestr + extension;
                        corporateGovernance_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CorporateGovernanceFile/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var ENG_File in uploaded_file_ENG)
                {
                    if (ENG_File.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(ENG_File.FileName);
                        corporateGovernance_File.file_name_ENG = datestr + extension;
                        corporateGovernance_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CorporateGovernanceFile/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            ENG_File.CopyTo(stream);
                        }
                    }
                }

                if (corporateGovernance_File.use_status != 1)
                {
                    corporateGovernance_File.use_status = 0;
                }
                else
                {
                    corporateGovernance_File.use_status = 1;
                }
                corporateGovernance_File.created_at = DateTime.Now;
                db.CorporateGovernance_File.Add(corporateGovernance_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Corporate_governance_edit_file(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Corporate_governance_index", "Corporate_Governance");
            }
            var get_detail = db.CorporateGovernance_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Corporate_governance_index", "Corporate_Governance");
            }
            var model = new model_input { fod_CorporateGovernance_File = get_detail };
            return View(model);
        }
        public IActionResult Corporate_governance_edit_file_update(CorporateGovernance_File corporateGovernance_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (corporateGovernance_File.title_file_th == null || corporateGovernance_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (corporateGovernance_File.title_file_en == null || corporateGovernance_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.CorporateGovernance_File.Where(x => x.id == corporateGovernance_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CorporateGovernanceFile/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CorporateGovernanceFile/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CorporateGovernanceFile/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CorporateGovernanceFile/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CorporateGovernanceFile/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CorporateGovernanceFile/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CorporateGovernanceFile/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CorporateGovernanceFile/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (corporateGovernance_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = corporateGovernance_File.title_file_th;
                old_data.title_file_en = corporateGovernance_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Corporate_governance_create_cate()
        {
            return View();
        }
        public IActionResult Corporate_governance_create_cate_insert(CorporateGovernance_Cate corporateGovernance_Cate)
        {
            try
            {
                if (corporateGovernance_Cate.title_th == null || corporateGovernance_Cate.title_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อหมวด TH" });
                }
                if (corporateGovernance_Cate.title_en == null || corporateGovernance_Cate.title_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อหมวด EN" });
                }

                if (corporateGovernance_Cate.use_status != 1)
                {
                    corporateGovernance_Cate.use_status = 0;
                }
                else
                {
                    corporateGovernance_Cate.use_status = 1;
                }
                corporateGovernance_Cate.created_at = DateTime.Now;
                db.CorporateGovernance_Cate.Add(corporateGovernance_Cate);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Corporate_governance_edit_cate(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Corporate_governance_index", "Corporate_Governance");
            }
            var get_detail = db.CorporateGovernance_Cate.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Corporate_governance_index", "Corporate_Governance");
            }
            var model = new model_input { fod_CorporateGovernance_Cate = get_detail };
            return View(model);
        }
        public IActionResult Corporate_governance_edit_cate_update(CorporateGovernance_Cate corporateGovernance_Cate)
        {
            try
            {
                if (corporateGovernance_Cate.title_th == null || corporateGovernance_Cate.title_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อหมวด TH" });
                }
                if (corporateGovernance_Cate.title_en == null || corporateGovernance_Cate.title_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อหมวด EN" });
                }

                var get_data = db.CorporateGovernance_Cate.Where(x => x.id == corporateGovernance_Cate.id).FirstOrDefault();

                if (corporateGovernance_Cate.use_status != 1)
                {
                    get_data.use_status = 0;
                }
                else
                {
                    get_data.use_status = 1;
                }
                get_data.updated_at = DateTime.Now;
                get_data.title_th = corporateGovernance_Cate.title_th;
                get_data.title_en = corporateGovernance_Cate.title_en;
                get_data.detail_th = corporateGovernance_Cate.detail_th;
                get_data.detail_en = corporateGovernance_Cate.detail_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Corporate_governance_cate_changeStatus(int? id, string? status)
        {
            var get_data = db.CorporateGovernance_Cate.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Corporate_governance_cate_delete(int? id)
        {
            try
            {
                var checkrow = db.CorporateGovernance_Cate.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    db.CorporateGovernance_Cate.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        // 
        public IActionResult Business_ethics_index()
        {
            var checkrow = db.O_business_ethics.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_business_ethics = count_row, fod_O_business_ethics = checkrow };
            return View(model);
        }
        public IActionResult Business_ethics_index_update(O_business_ethics o_Business_Ethics)
        {
            try
            {
                var checkrow = db.O_business_ethics.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Business_Ethics.created_at = DateTime.Now;
                    db.O_business_ethics.Add(o_Business_Ethics);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Business_Ethics.title_TH;
                    checkrow.title_ENG = o_Business_Ethics.title_ENG;
                    checkrow.titleDetails_TH = o_Business_Ethics.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Business_Ethics.titleDetails_ENG;
                    checkrow.detailsTitleTH = o_Business_Ethics.detailsTitleTH;
                    checkrow.detailsTitleENG = o_Business_Ethics.detailsTitleENG;
                    checkrow.detail_th = o_Business_Ethics.detail_th;
                    checkrow.detail_en = o_Business_Ethics.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Business_ethics_changeStatus(int? id, string? status)
        {
            var get_data = db.O_business_ethics_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Business_ethics_index_getTable()
        {
            try
            {
                var Raw_list = db.O_business_ethics_File.ToList();
                var add_count = new List<table_model.CorporateGovernance_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.CorporateGovernance_File_table
                    {
                        count_row = count,
                        id = items.id,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        created_at = items.created_at,
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
        public IActionResult Business_ethics_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Business_ethics_create_insert(O_business_ethics_File o_Business_Ethics_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Business_Ethics_File.title_file_th == null || o_Business_Ethics_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Business_Ethics_File.title_file_en == null || o_Business_Ethics_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Business_Ethics_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Business_Ethics_File.image_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Business_Ethics_File.file_name = datestr + extension;
                        o_Business_Ethics_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/BusinessEthics/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Business_Ethics_File.file_name_ENG = datestr + extension;
                        o_Business_Ethics_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/BusinessEthics/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }

                if (o_Business_Ethics_File.use_status != 1)
                {
                    o_Business_Ethics_File.use_status = 0;
                }
                else
                {
                    o_Business_Ethics_File.use_status = 1;
                }
                o_Business_Ethics_File.created_at = DateTime.Now;
                db.O_business_ethics_File.Add(o_Business_Ethics_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Business_ethics_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Business_ethics_index", "Corporate_Governance");
            }
            var get_detail = db.O_business_ethics_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Business_ethics_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_business_ethics_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Business_ethics_edit_update(O_business_ethics_File o_Business_Ethics_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Business_Ethics_File.title_file_th == null || o_Business_Ethics_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Business_Ethics_File.title_file_en == null || o_Business_Ethics_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_business_ethics_File.Where(x => x.id == o_Business_Ethics_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath2) == true)
                            {
                                System.IO.File.Delete(old_filePath2);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/BusinessEthics/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/BusinessEthics/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/BusinessEthics/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath3) == true)
                            {
                                System.IO.File.Delete(old_filePath3);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/BusinessEthics/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Business_Ethics_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Business_Ethics_File.title_file_th;
                old_data.title_file_en = o_Business_Ethics_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Business_ethics_delete(int? id)
        {
            try
            {
                var checkrow = db.O_business_ethics_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/BusinessEthics/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/BusinessEthics/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_business_ethics_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Business_ethics_Details_getTable()
        {
            try
            {
                var Raw_list = db.O_business_ethics_details.ToList();
                var add_count = new List<table_model.Business_ethics_details_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.Business_ethics_details_table
                    {
                        count_row = count,
                        id = items.id,
                        title_TH = items.title_TH,
                        title_ENG = items.title_ENG,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        created_at = items.created_at,
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

        public IActionResult Business_ethics_Detailscreate()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Business_ethics_Detailscreate_insert(O_business_ethics_details o_Business_ethics_details,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }

                if (o_Business_ethics_details.title_TH == null || o_Business_ethics_details.title_TH == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Business_ethics_details.title_ENG == null || o_Business_ethics_details.title_ENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Business_ethics_details.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Business_ethics_details.image_name_ENG = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                if (o_Business_ethics_details.use_status != 1)
                {
                    o_Business_ethics_details.use_status = 0;
                }
                else
                {
                    o_Business_ethics_details.use_status = 1;
                }
                o_Business_ethics_details.created_at = DateTime.Now;
                db.O_business_ethics_details.Add(o_Business_ethics_details);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Business_ethicsDetails_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Business_ethics_index", "Corporate_Governance");
            }
            var get_detail = db.O_business_ethics_details.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Business_ethics_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_business_ethics_Details = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Business_ethicsDetails_edit_update(O_business_ethics_details o_Business_ethics_details,
           List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG)
        {
            try
            {

                if (o_Business_ethics_details.title_TH == null || o_Business_ethics_details.title_TH == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Business_ethics_details.title_ENG == null || o_Business_ethics_details.title_ENG == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_business_ethics_details.Where(x => x.id == o_Business_ethics_details.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath2) == true)
                            {
                                System.IO.File.Delete(old_filePath2);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Business_ethics_details.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_TH = o_Business_ethics_details.title_TH;
                old_data.title_ENG = o_Business_ethics_details.title_ENG;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Business_ethicsDetails_changeStatus(int? id, string? status)
        {
            var get_data = db.O_business_ethics_details.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Business_ethicsDetails_delete(int? id)
        {
            try
            {
                var checkrow = db.O_business_ethics_details.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BusinessEthics/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }

                    db.O_business_ethics_details.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }


        //
        public IActionResult SustainabilityReport_index()
        {
            var get_data = db.Sustainability_Report.FirstOrDefault();
            var count = 0;
            if (get_data != null)
            {
                count = 1;
            }
            var model = new model_input { count_row_Sustainability_Report = count, fod_Sustainability_Report = get_data };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult SustainabilityReport_index_update(Sustainability_Report sustainability_Report,
            List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_file.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                var checkrow = db.Sustainability_Report.FirstOrDefault();
                if (checkrow == null)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            sustainability_Report.file_name = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SustainabilityReport/" + datestr + formFile.FileName);

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
                            sustainability_Report.file_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SustainabilityReport/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                    db.Sustainability_Report.Add(sustainability_Report);
                    db.SaveChanges();
                }
                else
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SustainabilityReport/" + checkrow.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            checkrow.file_name = datestr + formFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SustainabilityReport/" + datestr + formFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }

                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePathENG = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SustainabilityReport/" + checkrow.file_name_ENG);
                            if (System.IO.File.Exists(old_filePathENG) == true)
                            {
                                System.IO.File.Delete(old_filePathENG);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            checkrow.file_name_ENG = datestr + engFile.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/SustainabilityReport/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult CRS_policy_index()
        {
            var checkrow = db.O_CRS_policy.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_CRS_policy = count_row, fod_O_CRS_policy = checkrow };
            return View(model);
        }
        public IActionResult CRS_policy_index_update(O_CRS_policy o_CRS_Policy)
        {
            try
            {
                var checkrow = db.O_CRS_policy.FirstOrDefault();
                if (checkrow == null)
                {
                    o_CRS_Policy.created_at = DateTime.Now;
                    db.O_CRS_policy.Add(o_CRS_Policy);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_CRS_Policy.title_TH;
                    checkrow.title_ENG = o_CRS_Policy.title_ENG;
                    checkrow.titleDetails_TH = o_CRS_Policy.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_CRS_Policy.titleDetails_ENG;
                    checkrow.detailsTitleTH = o_CRS_Policy.detailsTitleTH;
                    checkrow.detailsTitleENG = o_CRS_Policy.detailsTitleENG;
                    checkrow.detail_th = o_CRS_Policy.detail_th;
                    checkrow.detail_en = o_CRS_Policy.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult CRS_policy_changeStatus(int? id, string? status)
        {
            var get_data = db.O_CRS_policy_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult CRS_policy_index_getTable()
        {
            try
            {
                var Raw_list = db.O_CRS_policy_File.ToList();
                var add_count = new List<table_model.CRS_policy_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.CRS_policy_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en

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
        public IActionResult CRS_policy_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult CRS_policy_create_insert(O_CRS_policy_File o_CRS_Policy_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_CRS_Policy_File.title_file_th == null || o_CRS_Policy_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_CRS_Policy_File.title_file_en == null || o_CRS_Policy_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_CRS_Policy_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CRSpolicy/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_CRS_Policy_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CRSpolicy/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_CRS_Policy_File.file_name = datestr + extension;
                        o_CRS_Policy_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CRSpolicy/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_CRS_Policy_File.file_name_ENG = datestr + engFile.FileName;
                        o_CRS_Policy_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CRSpolicy/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }
                if (o_CRS_Policy_File.use_status != 1)
                {
                    o_CRS_Policy_File.use_status = 0;
                }
                else
                {
                    o_CRS_Policy_File.use_status = 1;
                }
                o_CRS_Policy_File.created_at = DateTime.Now;
                db.O_CRS_policy_File.Add(o_CRS_Policy_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult CRS_policy_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("CRS_policy_index", "Corporate_Governance");
            }
            var get_detail = db.O_CRS_policy_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("CRS_policy_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_CRS_policy_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult CRS_policy_edit_update(O_CRS_policy_File o_CRS_Policy_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_CRS_Policy_File.title_file_th == null || o_CRS_Policy_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_CRS_Policy_File.title_file_en == null || o_CRS_Policy_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_CRS_policy_File.Where(x => x.id == o_CRS_Policy_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CRSpolicy/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CRSpolicy/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CRSpolicy/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath2) == true)
                            {
                                System.IO.File.Delete(old_filePath2);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CRSpolicy/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CRSpolicy/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CRSpolicy/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CRSpolicy/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath4) == true)
                            {
                                System.IO.File.Delete(old_filePath4);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CRSpolicy/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_CRS_Policy_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_CRS_Policy_File.title_file_th;
                old_data.title_file_en = o_CRS_Policy_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult CRS_policy_delete(int? id)
        {
            try
            {
                var checkrow = db.O_CRS_policy_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CRSpolicy/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CRSpolicy/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CRSpolicy/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/CRSpolicy/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }


                    db.O_CRS_policy_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Anti_fraud_index()
        {
            var checkrow = db.O_Anti_fraud.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Anti_fraud = count_row, fod_O_Anti_fraud = checkrow };
            return View(model);
        }
        public IActionResult Anti_fraud_index_update(O_Anti_fraud o_Anti_fraud)
        {
            try
            {
                var checkrow = db.O_Anti_fraud.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Anti_fraud.created_at = DateTime.Now;
                    db.O_Anti_fraud.Add(o_Anti_fraud);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Anti_fraud.title_TH;
                    checkrow.title_ENG = o_Anti_fraud.title_ENG;
                    checkrow.titleDetails_TH = o_Anti_fraud.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Anti_fraud.titleDetails_ENG;
                    checkrow.detailsTitleTH = o_Anti_fraud.detailsTitleTH;
                    checkrow.detailsTitleENG = o_Anti_fraud.detailsTitleENG;
                    checkrow.detail_th = o_Anti_fraud.detail_th;
                    checkrow.detail_en = o_Anti_fraud.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Anti_fraud_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Anti_fraud_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Anti_fraud_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Anti_fraud_File.ToList();
                var add_count = new List<table_model.Anti_fraud_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.Anti_fraud_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Anti_fraud_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Anti_fraud_create_insert(O_Anti_fraud_File o_Anti_fraud_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Anti_fraud_File.title_file_th == null || o_Anti_fraud_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Anti_fraud_File.title_file_en == null || o_Anti_fraud_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Anti_fraud_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/AntiFraud/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Anti_fraud_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/AntiFraud/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Anti_fraud_File.file_name = datestr + extension;
                        o_Anti_fraud_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/AntiFraud/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Anti_fraud_File.file_name_ENG = datestr + engFile.FileName;
                        o_Anti_fraud_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/AntiFraud/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }
                if (o_Anti_fraud_File.use_status != 1)
                {
                    o_Anti_fraud_File.use_status = 0;
                }
                else
                {
                    o_Anti_fraud_File.use_status = 1;
                }
                o_Anti_fraud_File.created_at = DateTime.Now;
                db.O_Anti_fraud_File.Add(o_Anti_fraud_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Anti_fraud_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Anti_fraud_index", "Corporate_Governance");
            }
            var get_detail = db.O_Anti_fraud_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Anti_fraud_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Anti_fraud_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Anti_fraud_edit_update(O_Anti_fraud_File o_Anti_fraud_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Anti_fraud_File.title_file_th == null || o_Anti_fraud_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Anti_fraud_File.title_file_en == null || o_Anti_fraud_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Anti_fraud_File.Where(x => x.id == o_Anti_fraud_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/AntiFraud/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/AntiFraud/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/AntiFraud/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/AntiFraud/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/AntiFraud/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/AntiFraud/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/AntiFraud/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath4) == true)
                            {
                                System.IO.File.Delete(old_filePath4);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/AntiFraud/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Anti_fraud_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Anti_fraud_File.title_file_th;
                old_data.title_file_en = o_Anti_fraud_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Anti_fraud_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Anti_fraud_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/AntiFraud/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/AntiFraud/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/AntiFraud/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/AntiFraud/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Anti_fraud_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Gift_entertainment_index()
        {
            var checkrow = db.O_Gift_entertainment.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Gift_entertainment = count_row, fod_O_Gift_entertainment = checkrow };
            return View(model);
        }
        public IActionResult Gift_entertainment_index_update(O_Gift_entertainment o_Gift_entertainment)
        {
            try
            {
                var checkrow = db.O_Gift_entertainment.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Gift_entertainment.created_at = DateTime.Now;
                    db.O_Gift_entertainment.Add(o_Gift_entertainment);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Gift_entertainment.title_TH;
                    checkrow.title_ENG = o_Gift_entertainment.title_ENG;
                    checkrow.titleDetails_TH = o_Gift_entertainment.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Gift_entertainment.titleDetails_ENG;
                    checkrow.detailsTitleTH = o_Gift_entertainment.detailsTitleTH;
                    checkrow.detailsTitleENG = o_Gift_entertainment.detailsTitleENG;
                    checkrow.detail_th = o_Gift_entertainment.detail_th;
                    checkrow.detail_en = o_Gift_entertainment.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Gift_entertainment_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Gift_entertainment_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Gift_entertainment_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Gift_entertainment_File.ToList();
                var add_count = new List<table_model.O_Gift_entertainment_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.O_Gift_entertainment_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Gift_entertainment_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Gift_entertainment_create_insert(O_Gift_entertainment_File o_Gift_entertainment_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Gift_entertainment_File.title_file_th == null || o_Gift_entertainment_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Gift_entertainment_File.title_file_en == null || o_Gift_entertainment_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Gift_entertainment_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Gift_entertainment/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Gift_entertainment_File.image_name = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Gift_entertainment/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Gift_entertainment_File.file_name = datestr + extension;
                        o_Gift_entertainment_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Gift_entertainment/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Gift_entertainment_File.file_name = datestr + engFile.FileName;
                        o_Gift_entertainment_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Gift_entertainment/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }

                if (o_Gift_entertainment_File.use_status != 1)
                {
                    o_Gift_entertainment_File.use_status = 0;
                }
                else
                {
                    o_Gift_entertainment_File.use_status = 1;
                }
                o_Gift_entertainment_File.created_at = DateTime.Now;
                db.O_Gift_entertainment_File.Add(o_Gift_entertainment_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Gift_entertainment_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Gift_entertainment_index", "Corporate_Governance");
            }
            var get_detail = db.O_Gift_entertainment_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Gift_entertainment_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Gift_entertainment_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Gift_entertainment_edit_update(O_Gift_entertainment_File o_Gift_entertainment_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Gift_entertainment_File.title_file_th == null || o_Gift_entertainment_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Gift_entertainment_File.title_file_en == null || o_Gift_entertainment_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Gift_entertainment_File.Where(x => x.id == o_Gift_entertainment_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Gift_entertainment/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Gift_entertainment/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Gift_entertainment/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath3) == true)
                            {
                                System.IO.File.Delete(old_filePath3);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Gift_entertainment/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Gift_entertainment/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Gift_entertainment/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Gift_entertainment/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath4) == true)
                            {
                                System.IO.File.Delete(old_filePath4);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Gift_entertainment/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Gift_entertainment_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Gift_entertainment_File.title_file_th;
                old_data.title_file_en = o_Gift_entertainment_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Gift_entertainment_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Gift_entertainment_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Gift_entertainment/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Gift_entertainment/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Gift_entertainment/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Gift_entertainment/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Gift_entertainment_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Channel_clue_index()
        {
            var checkrow = db.O_Channel_clue.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Channel_clue = count_row, fod_O_Channel_clue = checkrow };
            return View(model);
        }
        public IActionResult Channel_clue_index_update(O_Channel_clue o_Channel_clue)
        {
            try
            {
                var checkrow = db.O_Channel_clue.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Channel_clue.created_at = DateTime.Now;
                    db.O_Channel_clue.Add(o_Channel_clue);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Channel_clue.title_TH;
                    checkrow.title_ENG = o_Channel_clue.title_ENG;
                    checkrow.titleDetails_TH = o_Channel_clue.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Channel_clue.titleDetails_ENG;
                    checkrow.detailsTitleTH = o_Channel_clue.detailsTitleTH;
                    checkrow.detailsTitleENG = o_Channel_clue.detailsTitleENG;
                    checkrow.detail_th = o_Channel_clue.detail_th;
                    checkrow.detail_en = o_Channel_clue.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Channel_clue_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Channel_clue_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Channel_clue_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Channel_clue_File.ToList();
                var add_count = new List<table_model.O_Channel_clue_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.O_Channel_clue_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Channel_clue_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Channel_clue_create_insert(O_Channel_clue_File o_Channel_clue_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Channel_clue_File.title_file_th == null || o_Channel_clue_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Channel_clue_File.title_file_en == null || o_Channel_clue_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Channel_clue_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Channel_clue/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Channel_clue_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Channel_clue/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Channel_clue_File.file_name = datestr + extension;
                        o_Channel_clue_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Channel_clue/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Channel_clue_File.file_name_ENG = datestr + engFile.FileName;
                        o_Channel_clue_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Channel_clue/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }
                if (o_Channel_clue_File.use_status != 1)
                {
                    o_Channel_clue_File.use_status = 0;
                }
                else
                {
                    o_Channel_clue_File.use_status = 1;
                }
                o_Channel_clue_File.created_at = DateTime.Now;
                db.O_Channel_clue_File.Add(o_Channel_clue_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Channel_clue_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Channel_clue_index", "Corporate_Governance");
            }
            var get_detail = db.O_Channel_clue_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Channel_clue_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Channel_clue_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Channel_clue_edit_update(O_Channel_clue_File o_Channel_clue_File,
             List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Channel_clue_File.title_file_th == null || o_Channel_clue_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Channel_clue_File.title_file_en == null || o_Channel_clue_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Channel_clue_File.Where(x => x.id == o_Channel_clue_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Channel_clue/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Channel_clue/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Channel_clue/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Channel_clue/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Channel_clue/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Channel_clue/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Channel_clue/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Channel_clue/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }


                if (o_Channel_clue_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Channel_clue_File.title_file_th;
                old_data.title_file_en = o_Channel_clue_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Channel_clue_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Channel_clue_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Channel_clue/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Channel_clue/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Channel_clue/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Channel_clue/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Channel_clue_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Author_chairman_index()
        {
            var checkrow = db.O_Author_chairman.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Author_chairman = count_row, fod_O_Author_chairman = checkrow };
            return View(model);
        }
        public IActionResult Author_chairman_index_update(O_Author_chairman o_Author_chairman)
        {
            try
            {
                var checkrow = db.O_Author_chairman.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Author_chairman.created_at = DateTime.Now;
                    db.O_Author_chairman.Add(o_Author_chairman);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Author_chairman.title_TH;
                    checkrow.title_ENG = o_Author_chairman.title_ENG;
                    checkrow.titleDetails_TH = o_Author_chairman.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Author_chairman.titleDetails_ENG;
                    checkrow.detailsTitleENG = o_Author_chairman.detailsTitleENG;
                    checkrow.detail_th = o_Author_chairman.detail_th;
                    checkrow.detail_en = o_Author_chairman.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_chairman_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Author_chairman_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Author_chairman_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Author_chairman_File.ToList();
                var add_count = new List<table_model.O_Author_chairman_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.O_Author_chairman_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Author_chairman_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_chairman_create_insert(O_Author_chairman_File o_Author_chairman_File,
           List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Author_chairman_File.title_file_th == null || o_Author_chairman_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_chairman_File.title_file_en == null || o_Author_chairman_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_chairman_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Author_chairman_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_chairman_File.file_name = datestr + extension;
                        o_Author_chairman_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Author_chairman_File.file_name_ENG = datestr + engFile.FileName;
                        o_Author_chairman_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }

                if (o_Author_chairman_File.use_status != 1)
                {
                    o_Author_chairman_File.use_status = 0;
                }
                else
                {
                    o_Author_chairman_File.use_status = 1;
                }
                o_Author_chairman_File.created_at = DateTime.Now;
                db.O_Author_chairman_File.Add(o_Author_chairman_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_chairman_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Author_chairman_index", "Corporate_Governance");
            }
            var get_detail = db.O_Author_chairman_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Author_chairman_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Author_chairman_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_chairman_edit_update(O_Author_chairman_File o_Author_chairman_File,
             List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Author_chairman_File.title_file_th == null || o_Author_chairman_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_chairman_File.title_file_en == null || o_Author_chairman_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Author_chairman_File.Where(x => x.id == o_Author_chairman_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString();
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }


                if (o_Author_chairman_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Author_chairman_File.title_file_th;
                old_data.title_file_en = o_Author_chairman_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_chairman_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Author_chairman_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Author_chairman_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Author_chairman_executive_index()
        {
            var checkrow = db.O_Author_chairman_executive.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Author_chairman_executive = count_row, fod_O_Author_chairman_executive = checkrow };
            return View(model);
        }
        public IActionResult Author_chairman_executive_index_update(O_Author_chairman_executive o_Author_chairman_executive)
        {
            try
            {
                var checkrow = db.O_Author_chairman_executive.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Author_chairman_executive.created_at = DateTime.Now;
                    db.O_Author_chairman_executive.Add(o_Author_chairman_executive);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Author_chairman_executive.title_TH;
                    checkrow.title_ENG = o_Author_chairman_executive.title_ENG;
                    checkrow.titleDetails_TH = o_Author_chairman_executive.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Author_chairman_executive.titleDetails_ENG;
                    checkrow.detailsTitleENG = o_Author_chairman_executive.detailsTitleENG;
                    checkrow.detail_th = o_Author_chairman_executive.detail_th;
                    checkrow.detail_en = o_Author_chairman_executive.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_chairman_executive_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Author_chairman_executive_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Author_chairman_executive_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Author_chairman_executive_File.ToList();
                var add_count = new List<table_model.O_Author_chairman_executive_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.O_Author_chairman_executive_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Author_chairman_executive_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_chairman_executive_create_insert(O_Author_chairman_executive_File o_Author_chairman_executive_File,
             List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Author_chairman_executive_File.title_file_th == null || o_Author_chairman_executive_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_chairman_executive_File.title_file_en == null || o_Author_chairman_executive_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_chairman_executive_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman_executive/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Author_chairman_executive_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman_executive/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }


                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_chairman_executive_File.file_name = datestr + extension;
                        o_Author_chairman_executive_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman_executive/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Author_chairman_executive_File.file_name_ENG = datestr + engFile.FileName;
                        o_Author_chairman_executive_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman_executive/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }
                if (o_Author_chairman_executive_File.use_status != 1)
                {
                    o_Author_chairman_executive_File.use_status = 0;
                }
                else
                {
                    o_Author_chairman_executive_File.use_status = 1;
                }
                o_Author_chairman_executive_File.created_at = DateTime.Now;
                db.O_Author_chairman_executive_File.Add(o_Author_chairman_executive_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_chairman_executive_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Author_chairman_executive_index", "Corporate_Governance");
            }
            var get_detail = db.O_Author_chairman_executive_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Author_chairman_executive_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Author_chairman_executive_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_chairman_executive_edit_update(O_Author_chairman_executive_File o_Author_chairman_executive_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Author_chairman_executive_File.title_file_th == null || o_Author_chairman_executive_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_chairman_executive_File.title_file_en == null || o_Author_chairman_executive_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Author_chairman_executive_File.Where(x => x.id == o_Author_chairman_executive_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman_executive/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman_executive/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman_executive/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman_executive/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman_executive/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman_executive/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman_executive/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString();
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman_executive/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Author_chairman_executive_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Author_chairman_executive_File.title_file_th;
                old_data.title_file_en = o_Author_chairman_executive_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_chairman_executive_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Author_chairman_executive_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman_executive/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_chairman_executive/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman_executive/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_chairman_executive/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Author_chairman_executive_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Author_board_director_index()
        {
            var checkrow = db.O_Author_board_director.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Author_board_director = count_row, fod_O_Author_board_director = checkrow };
            return View(model);
        }
        public IActionResult Author_board_director_index_update(O_Author_board_director o_Author_board_director)
        {
            try
            {
                var checkrow = db.O_Author_board_director.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Author_board_director.created_at = DateTime.Now;
                    db.O_Author_board_director.Add(o_Author_board_director);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Author_board_director.title_TH;
                    checkrow.title_ENG = o_Author_board_director.title_ENG;
                    checkrow.titleDetails_TH = o_Author_board_director.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Author_board_director.titleDetails_ENG;
                    checkrow.detailsTitleENG = o_Author_board_director.detailsTitleENG;
                    checkrow.detail_th = o_Author_board_director.detail_th;
                    checkrow.detail_en = o_Author_board_director.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_board_director_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Author_board_director_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Author_board_director_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Author_board_director_File.ToList();
                var add_count = new List<table_model.O_Author_board_director_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.O_Author_board_director_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Author_board_director_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_board_director_create_insert(O_Author_board_director_File o_Author_board_director_File,
             List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Author_board_director_File.title_file_th == null || o_Author_board_director_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_board_director_File.title_file_en == null || o_Author_board_director_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_board_director_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_board_director/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Author_board_director_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_board_director/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_board_director_File.file_name = datestr + extension;
                        o_Author_board_director_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_board_director/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Author_board_director_File.file_name_ENG = datestr + engFile.FileName;
                        o_Author_board_director_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_board_director/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }

                if (o_Author_board_director_File.use_status != 1)
                {
                    o_Author_board_director_File.use_status = 0;
                }
                else
                {
                    o_Author_board_director_File.use_status = 1;
                }
                o_Author_board_director_File.created_at = DateTime.Now;
                db.O_Author_board_director_File.Add(o_Author_board_director_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_board_director_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Author_board_director_index", "Corporate_Governance");
            }
            var get_detail = db.O_Author_board_director_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Author_board_director_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Author_board_director_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_board_director_edit_update(O_Author_board_director_File o_Author_board_director_File,
             List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Author_board_director_File.title_file_th == null || o_Author_board_director_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_board_director_File.title_file_en == null || o_Author_board_director_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Author_board_director_File.Where(x => x.id == o_Author_board_director_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_board_director/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_board_director/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_board_director/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_board_director/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_board_director/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_board_director/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_board_director/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_board_director/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Author_board_director_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Author_board_director_File.title_file_th;
                old_data.title_file_en = o_Author_board_director_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_board_director_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Author_board_director_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_board_director/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_board_director/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_board_director/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_board_director/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Author_board_director_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Author_audit_committee_index()
        {
            var checkrow = db.O_Author_audit_committee.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Author_audit_committee = count_row, fod_O_Author_audit_committee = checkrow };
            return View(model);
        }
        public IActionResult Author_audit_committee_index_update(O_Author_audit_committee o_Author_audit_committee)
        {
            try
            {
                var checkrow = db.O_Author_audit_committee.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Author_audit_committee.created_at = DateTime.Now;
                    db.O_Author_audit_committee.Add(o_Author_audit_committee);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Author_audit_committee.title_TH;
                    checkrow.title_ENG = o_Author_audit_committee.title_ENG;
                    checkrow.titleDetails_TH = o_Author_audit_committee.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Author_audit_committee.titleDetails_ENG;
                    checkrow.detailsTitleENG = o_Author_audit_committee.detailsTitleENG;
                    checkrow.detail_th = o_Author_audit_committee.detail_th;
                    checkrow.detail_en = o_Author_audit_committee.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_audit_committee_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Author_audit_committee_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Author_audit_committee_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Author_audit_committee_File.ToList();
                var add_count = new List<table_model.O_Author_audit_committee_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.O_Author_audit_committee_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        image_name_ENG = items.image_name_ENG,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Author_audit_committee_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_audit_committee_create_insert(O_Author_audit_committee_File o_Author_audit_committee_File,
           List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Author_audit_committee_File.title_file_th == null || o_Author_audit_committee_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_audit_committee_File.title_file_en == null || o_Author_audit_committee_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_audit_committee_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_audit_committee/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Author_audit_committee_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_audit_committee/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_audit_committee_File.file_name = datestr + extension;
                        o_Author_audit_committee_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_audit_committee/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Author_audit_committee_File.file_name_ENG = datestr + engFile.FileName;
                        o_Author_audit_committee_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_audit_committee/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }

                if (o_Author_audit_committee_File.use_status != 1)
                {
                    o_Author_audit_committee_File.use_status = 0;
                }
                else
                {
                    o_Author_audit_committee_File.use_status = 1;
                }
                o_Author_audit_committee_File.created_at = DateTime.Now;
                db.O_Author_audit_committee_File.Add(o_Author_audit_committee_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_audit_committee_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Author_audit_committee_index", "Corporate_Governance");
            }
            var get_detail = db.O_Author_audit_committee_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Author_audit_committee_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Author_audit_committee_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_audit_committee_edit_update(O_Author_audit_committee_File o_Author_audit_committee_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Author_audit_committee_File.title_file_th == null || o_Author_audit_committee_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_audit_committee_File.title_file_en == null || o_Author_audit_committee_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Author_audit_committee_File.Where(x => x.id == o_Author_audit_committee_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_audit_committee/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_audit_committee/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_audit_committee/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_audit_committee/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_audit_committee/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_audit_committee/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_audit_committee/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_audit_committee/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Author_audit_committee_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Author_audit_committee_File.title_file_th;
                old_data.title_file_en = o_Author_audit_committee_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_audit_committee_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Author_audit_committee_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_audit_committee/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_audit_committee/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }

                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_audit_committee/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_audit_committee/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Author_audit_committee_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Author_cg_index()
        {
            var checkrow = db.O_Author_cg.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Author_cg = count_row, fod_O_Author_cg = checkrow };
            return View(model);
        }
        public IActionResult Author_cg_index_update(O_Author_cg o_Author_cg)
        {
            try
            {
                var checkrow = db.O_Author_cg.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Author_cg.created_at = DateTime.Now;
                    db.O_Author_cg.Add(o_Author_cg);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Author_cg.title_TH;
                    checkrow.title_ENG = o_Author_cg.title_ENG;
                    checkrow.titleDetails_TH = o_Author_cg.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Author_cg.titleDetails_ENG;
                    checkrow.detailsTitleENG = o_Author_cg.detailsTitleENG;
                    checkrow.detail_th = o_Author_cg.detail_th;
                    checkrow.detail_en = o_Author_cg.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_cg_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Author_cg_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Author_cg_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Author_cg_File.ToList();
                var add_count = new List<table_model.CorporateGovernance_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.CorporateGovernance_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Author_cg_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_cg_create_insert(O_Author_cg_File o_Author_cg_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Author_cg_File.title_file_th == null || o_Author_cg_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_cg_File.title_file_en == null || o_Author_cg_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_cg_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_cg/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Author_cg_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_cg/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_cg_File.file_name = datestr + extension;
                        o_Author_cg_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_cg/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Author_cg_File.file_name_ENG = datestr + engFile.FileName;
                        o_Author_cg_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_cg/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }

                if (o_Author_cg_File.use_status != 1)
                {
                    o_Author_cg_File.use_status = 0;
                }
                else
                {
                    o_Author_cg_File.use_status = 1;
                }
                o_Author_cg_File.created_at = DateTime.Now;
                db.O_Author_cg_File.Add(o_Author_cg_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_cg_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Author_cg_index", "Corporate_Governance");
            }
            var get_detail = db.O_Author_cg_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Author_cg_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Author_cg_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_cg_edit_update(O_Author_cg_File o_Author_cg_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Author_cg_File.title_file_th == null || o_Author_cg_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_cg_File.title_file_en == null || o_Author_cg_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Author_cg_File.Where(x => x.id == o_Author_cg_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_cg/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_cg/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_cg/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_cg/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_cg/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_cg/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_cg/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_cg/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Author_cg_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Author_cg_File.title_file_th;
                old_data.title_file_en = o_Author_cg_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_cg_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Author_cg_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_cg/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_cg/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }
                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_cg/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_cg/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Author_cg_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Author_executive_board_index()
        {
            var checkrow = db.O_Author_executive_board.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Author_executive_board = count_row, fod_O_Author_executive_board = checkrow };
            return View(model);
        }
        public IActionResult Author_executive_board_index_update(O_Author_executive_board o_Author_executive_board)
        {
            try
            {
                var checkrow = db.O_Author_executive_board.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Author_executive_board.created_at = DateTime.Now;
                    db.O_Author_executive_board.Add(o_Author_executive_board);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Author_executive_board.title_TH;
                    checkrow.title_ENG = o_Author_executive_board.title_ENG;
                    checkrow.titleDetails_TH = o_Author_executive_board.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Author_executive_board.titleDetails_ENG;
                    checkrow.detailsTitleENG = o_Author_executive_board.detailsTitleENG;
                    checkrow.detail_th = o_Author_executive_board.detail_th;
                    checkrow.detail_en = o_Author_executive_board.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_executive_board_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Author_executive_board_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Author_executive_board_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Author_executive_board_File.ToList();
                var add_count = new List<table_model.O_Author_executive_board_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.O_Author_executive_board_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Author_executive_board_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_executive_board_create_insert(O_Author_executive_board_File o_Author_executive_board_File,
           List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Author_executive_board_File.title_file_th == null || o_Author_executive_board_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_executive_board_File.title_file_en == null || o_Author_executive_board_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_executive_board_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_executive_board/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Author_executive_board_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_executive_board/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_executive_board_File.file_name = datestr + extension;
                        o_Author_executive_board_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_executive_board/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Author_executive_board_File.file_name_ENG = datestr + engFile.FileName;
                        o_Author_executive_board_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_executive_board/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }

                if (o_Author_executive_board_File.use_status != 1)
                {
                    o_Author_executive_board_File.use_status = 0;
                }
                else
                {
                    o_Author_executive_board_File.use_status = 1;
                }
                o_Author_executive_board_File.created_at = DateTime.Now;
                db.O_Author_executive_board_File.Add(o_Author_executive_board_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_executive_board_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Author_executive_board_index", "Corporate_Governance");
            }
            var get_detail = db.O_Author_executive_board_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Author_executive_board_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Author_executive_board_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_executive_board_edit_update(O_Author_executive_board_File o_Author_executive_board_File,
           List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Author_executive_board_File.title_file_th == null || o_Author_executive_board_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_executive_board_File.title_file_en == null || o_Author_executive_board_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Author_executive_board_File.Where(x => x.id == o_Author_executive_board_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_executive_board/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_executive_board/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_executive_board/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_executive_board/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_executive_board/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_executive_board/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }
                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_executive_board/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_executive_board/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Author_executive_board_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Author_executive_board_File.title_file_th;
                old_data.title_file_en = o_Author_executive_board_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_executive_board_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Author_executive_board_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_executive_board/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_executive_board/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }
                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_executive_board/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_executive_board/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Author_executive_board_File.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }

        //
        public IActionResult Author_secretary_index()
        {
            var checkrow = db.O_Author_secretary.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_O_Author_secretary = count_row, fod_O_Author_secretary = checkrow };
            return View(model);
        }
        public IActionResult Author_secretary_index_update(O_Author_secretary o_Author_secretary)
        {
            try
            {
                var checkrow = db.O_Author_secretary.FirstOrDefault();
                if (checkrow == null)
                {
                    o_Author_secretary.created_at = DateTime.Now;
                    db.O_Author_secretary.Add(o_Author_secretary);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.title_TH = o_Author_secretary.title_TH;
                    checkrow.title_ENG = o_Author_secretary.title_ENG;
                    checkrow.titleDetails_TH = o_Author_secretary.titleDetails_TH;
                    checkrow.titleDetails_ENG = o_Author_secretary.titleDetails_ENG;
                    checkrow.detailsTitleENG = o_Author_secretary.detailsTitleENG;
                    checkrow.detail_th = o_Author_secretary.detail_th;
                    checkrow.detail_en = o_Author_secretary.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_secretary_changeStatus(int? id, string? status)
        {
            var get_data = db.O_Author_secretary_File.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Author_secretary_index_getTable()
        {
            try
            {
                var Raw_list = db.O_Author_secretary_File.ToList();
                var add_count = new List<table_model.O_Author_secretary_File_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.O_Author_secretary_File_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        title_file_th = items.title_file_th,
                        title_file_en = items.title_file_en
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
        public IActionResult Author_secretary_create()
        {
            return View();
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_secretary_board_create_insert(O_Author_secretary_File o_Author_secretary_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {
                if (uploaded_image.Count == 0 || uploaded_image_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (uploaded_file.Count == 0 || uploaded_file_ENG.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload ไฟล์" });
                }
                if (o_Author_secretary_File.title_file_th == null || o_Author_secretary_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_secretary_File.title_file_en == null || o_Author_secretary_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_secretary_File.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_secretary/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var formFileENG in uploaded_image_ENG)
                {
                    if (formFileENG.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(formFileENG.FileName);
                        o_Author_secretary_File.image_name_ENG = datestr + formFileENG.FileName;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_secretary/" + datestr + formFileENG.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFileENG.CopyTo(stream);
                        }
                    }
                }


                foreach (var formFile in uploaded_file)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        o_Author_secretary_File.file_name = datestr + extension;
                        o_Author_secretary_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_secretary/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                foreach (var engFile in uploaded_file_ENG)
                {
                    if (engFile.Length > 0)
                    {
                        var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                        var extension = Path.GetExtension(engFile.FileName);
                        o_Author_secretary_File.file_name_ENG = datestr + engFile.FileName;
                        o_Author_secretary_File.file_type = extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_secretary/" + datestr + engFile.FileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            engFile.CopyTo(stream);
                        }
                    }
                }

                if (o_Author_secretary_File.use_status != 1)
                {
                    o_Author_secretary_File.use_status = 0;
                }
                else
                {
                    o_Author_secretary_File.use_status = 1;
                }
                o_Author_secretary_File.created_at = DateTime.Now;
                db.O_Author_secretary_File.Add(o_Author_secretary_File);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_secretary_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Author_secretary_index", "Corporate_Governance");
            }
            var get_detail = db.O_Author_secretary_File.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Author_secretary_index", "Corporate_Governance");
            }
            var model = new model_input { fod_O_Author_secretary_File = get_detail };
            return View(model);
        }
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public IActionResult Author_secretary_edit_update(O_Author_secretary_File o_Author_secretary_File,
            List<IFormFile> uploaded_image, List<IFormFile> uploaded_image_ENG, List<IFormFile> uploaded_file, List<IFormFile> uploaded_file_ENG)
        {
            try
            {

                if (o_Author_secretary_File.title_file_th == null || o_Author_secretary_File.title_file_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (o_Author_secretary_File.title_file_en == null || o_Author_secretary_File.title_file_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var old_data = db.O_Author_secretary_File.Where(x => x.id == o_Author_secretary_File.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_secretary/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_secretary/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_image_ENG.Count > 0)
                {
                    foreach (var formFileENG in uploaded_image_ENG)
                    {
                        if (formFileENG.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_secretary/" + old_data.image_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFileENG.FileName);
                            old_data.image_name_ENG = datestr + formFileENG.FileName;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_secretary/" + datestr + formFileENG.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFileENG.CopyTo(stream);
                            }
                        }
                    }
                }


                if (uploaded_file.Count > 0)
                {
                    foreach (var formFile in uploaded_file)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_secretary/" + old_data.file_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.file_name = datestr + extension;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_secretary/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (uploaded_file_ENG.Count > 0)
                {
                    foreach (var engFile in uploaded_file_ENG)
                    {
                        if (engFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_secretary/" + old_data.file_name_ENG);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss_");
                            var extension = Path.GetExtension(engFile.FileName);
                            old_data.file_name_ENG = datestr + engFile.FileName;
                            old_data.file_type = extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_secretary/" + datestr + engFile.FileName);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                engFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (o_Author_secretary_File.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.updated_at = DateTime.Now;
                old_data.title_file_th = o_Author_secretary_File.title_file_th;
                old_data.title_file_en = o_Author_secretary_File.title_file_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Author_secretary_delete(int? id)
        {
            try
            {
                var checkrow = db.O_Author_secretary_File.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_secretary/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    var old_filePath3 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Author_secretary/" + checkrow.image_name_ENG);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }
                    var old_filePath2 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_secretary/" + checkrow.file_name);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }
                    var old_filePath4 = Path.Combine(_hostingEnvironment.WebRootPath, "upload_file/Author_secretary/" + checkrow.file_name_ENG);
                    if (System.IO.File.Exists(old_filePath4) == true)
                    {
                        System.IO.File.Delete(old_filePath4);
                    }
                    db.O_Author_secretary_File.Remove(checkrow);
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
