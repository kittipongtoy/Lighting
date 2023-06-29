using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class Investor_RelationsController : Controller
    {
        //private IConfiguration _config;
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;

        public Investor_RelationsController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }
        public IActionResult InvestorRelations_index()
        {
            return View();
        }        
        public IActionResult Message_Chairman_index()
        {
            var checkrow = db.M_message_chairman.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_row_chairman = count_row , fod_message_chairman = checkrow};
            return View(model);
        }
        public IActionResult Message_Chairman_delete(int? id)
        {
            try
            {
                var checkrow = db.M_chairman.Where(x => x.id == id).FirstOrDefault();
                if(checkrow != null)
                {
                    db.M_chairman.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Message_Chairman_index_getTable()
        {
            try
            {
                var Raw_list = db.M_chairman.ToList();
                var add_count = new List<table_model.M_chairman_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.M_chairman_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        name_en = items.name_en,
                        name_th = items.name_th,
                        rank_en = items.rank_en,
                        rank_th = items.rank_th,
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
        public IActionResult Message_Chairman_index_update(M_message_chairman m_Message_Chairman)
        {
            try
            {
                var checkrow = db.M_message_chairman.FirstOrDefault();
                if(checkrow == null)
                {
                    m_Message_Chairman.created_at = DateTime.Now;
                    db.M_message_chairman.Add(m_Message_Chairman);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.updated_at = DateTime.Now;
                    checkrow.vision_th = m_Message_Chairman.vision_th;
                    checkrow.vision_en = m_Message_Chairman.vision_en;
                    checkrow.detail_th = m_Message_Chairman.detail_th;
                    checkrow.detail_en = m_Message_Chairman.detail_en;
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Message_Chairman_changeStatus(int? id,string? status)
        {
            var get_data = db.M_chairman.Where(x => x.id == id).FirstOrDefault();
            if(status == "true")
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
        public IActionResult Message_Chairman_create()
        {
            return View();
        }
        public IActionResult Message_Chairman_create_insert(M_chairman m_Chairman, List<IFormFile> uploaded_image)
        {
            try
            {
                if (uploaded_image.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูปประธานกรรมการ" });
                }
                if (m_Chairman.name_th == null || m_Chairman.name_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อ - นามสกุล TH" });
                }
                if (m_Chairman.name_en == null || m_Chairman.name_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อ - นามสกุล EN" });
                }
                if (m_Chairman.rank_th == null || m_Chairman.rank_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่ง TH" });
                }
                if (m_Chairman.rank_en == null || m_Chairman.rank_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่ง EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        m_Chairman.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Chairman/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                if(m_Chairman.use_status != 1)
                {
                    m_Chairman.use_status = 0;
                }
                m_Chairman.created_at = DateTime.Now;
                db.M_chairman.Add(m_Chairman);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Message_Chairman_edit(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Message_Chairman_index", "Investor_Relations");
            }
            var get_detail = db.M_chairman.Where(x => x.id == id).FirstOrDefault();
            if(get_detail == null)
            {
                return RedirectToAction("Message_Chairman_index", "Investor_Relations");
            }
            var model = new model_input { fod_chairman = get_detail };
            return View(model);
        }
        public IActionResult Message_Chairman_edit_update(M_chairman m_Chairman, List<IFormFile> uploaded_image)
        {
            try
            {
                if (m_Chairman.name_th == null || m_Chairman.name_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อ - นามสกุล TH" });
                }
                if (m_Chairman.name_en == null || m_Chairman.name_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อ - นามสกุล EN" });
                }
                if (m_Chairman.rank_th == null || m_Chairman.rank_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่ง TH" });
                }
                if (m_Chairman.rank_en == null || m_Chairman.rank_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่ง EN" });
                }

                var old_data = db.M_chairman.Where(x=>x.id == m_Chairman.id).FirstOrDefault();

                if(uploaded_image.Count != 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Chairman/" + old_data.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            old_data.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Chairman/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                if (m_Chairman.use_status != 1)
                {
                    old_data.use_status = 0;
                }
                else
                {
                    old_data.use_status = 1;
                }
                old_data.name_th = m_Chairman.name_th;
                old_data.name_en = m_Chairman.name_en;
                old_data.rank_th = m_Chairman.rank_th;
                old_data.rank_en = m_Chairman.rank_en;
                old_data.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Philosophy_index()
        {
            return View();
        }
        public IActionResult Philosophy_index_insert(P_philosophy p_Philosophy, List<IFormFile> uploaded_image)
        {
            try
            {
                if (uploaded_image.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        p_Philosophy.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Philosophy/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                if (p_Philosophy.use_status != 1)
                {
                    p_Philosophy.use_status = 0;
                }
                else
                {
                    p_Philosophy.use_status = 1;
                }
                p_Philosophy.created_at = DateTime.Now;
                db.P_philosophy.Add(p_Philosophy);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        } 
        public IActionResult Philosophy_index_update(P_philosophy p_Philosophy, List<IFormFile> uploaded_image)
        {
            try
            {
                var get_oldData = db.P_philosophy.Where(x => x.id == p_Philosophy.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Philosophy/" + get_oldData.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            get_oldData.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Philosophy/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }

                
                if (p_Philosophy.use_status != 1)
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
        public IActionResult Philosophy_index_getTable()
        {
            try
            {
                var Raw_list = db.P_philosophy.ToList();
                var add_count = new List<table_model.P_philosophy_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.P_philosophy_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
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
        public IActionResult Philosophy_changeStatus(int? id, string? status)
        {
            var get_data = db.P_philosophy.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Philosophy_getData(int? id)
        {
            var get_data = db.P_philosophy.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "",data= get_data });
        }
        public IActionResult Philosophy_delete(int? id)
        {
            try
            {
                var checkrow = db.P_philosophy.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/Philosophy/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    db.P_philosophy.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Companyprofile_index()
        {
            return View();
        }
        public IActionResult Companyprofile_changeStatus(int? id, string? status)
        {
            var get_data = db.Companyprofile.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Companyprofile_delete(int? id)
        {
            try
            {
                var checkrow = db.Companyprofile.Where(x => x.id == id).FirstOrDefault();
                if (checkrow != null)
                {
                    db.Companyprofile.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Companyprofile_index_getTable()
        {
            try
            {
                var Raw_list = db.Companyprofile.ToList();
                var add_count = new List<table_model.Companyprofile_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.Companyprofile_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        updated_at = items.updated_at,
                        use_status = items.use_status,
                        detail_en = items.detail_en,
                        detail_th = items.detail_th,
                        title_en = items.title_en,
                        title_th = items.title_th
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
        public IActionResult Companyprofile_create()
        {
            return View();
        }
        public IActionResult Companyprofile_create_insert(Companyprofile companyprofile)
        {
            try
            {
                if (companyprofile.title_th == null || companyprofile.title_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (companyprofile.title_en == null || companyprofile.title_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }


                if (companyprofile.use_status != 1)
                {
                    companyprofile.use_status = 0;
                }
                else
                {
                    companyprofile.use_status = 1;
                }
                companyprofile.created_at = DateTime.Now;
                db.Companyprofile.Add(companyprofile);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Companyprofile_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Companyprofile_index", "Investor_Relations");
            }
            var get_detail = db.Companyprofile.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Companyprofile_index", "Investor_Relations");
            }
            var model = new model_input { fod_Companyprofile = get_detail };
            return View(model);
        }
        public IActionResult Companyprofile_edit_update(Companyprofile companyprofile)
        {
            try
            {
                if (companyprofile.title_th == null || companyprofile.title_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ TH" });
                }
                if (companyprofile.title_en == null || companyprofile.title_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ หัวข้อ EN" });
                }

                var get_oldData = db.Companyprofile.Where(x => x.id == companyprofile.id).FirstOrDefault();
                if (companyprofile.use_status != 1)
                {
                    get_oldData.use_status = 0;
                }
                else
                {
                    get_oldData.use_status = 1;
                }


                get_oldData.title_th = companyprofile.title_th;
                get_oldData.title_en = companyprofile.title_en;
                get_oldData.detail_th = companyprofile.detail_th;
                get_oldData.detail_en = companyprofile.detail_en;
                get_oldData.updated_at = DateTime.Now;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult CompanyOverview_index()
        {
            return View();
        }
        public IActionResult CompanyOverview_index_insert(Company_Overview company_Overview, List<IFormFile> uploaded_image)
        {
            try
            {
                if (uploaded_image.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        company_Overview.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CompanyOverview/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                if (company_Overview.use_status != 1)
                {
                    company_Overview.use_status = 0;
                }
                else
                {
                    company_Overview.use_status = 1;
                }
                company_Overview.created_at = DateTime.Now;
                db.Company_Overview.Add(company_Overview);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult CompanyOverview_index_update(Company_Overview company_Overview, List<IFormFile> uploaded_image)
        {
            try
            {
                var get_oldData = db.Company_Overview.Where(x => x.id == company_Overview.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CompanyOverview/" + get_oldData.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            get_oldData.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CompanyOverview/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }


                if (company_Overview.use_status != 1)
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
        public IActionResult CompanyOverview_index_getTable()
        {
            try
            {
                var Raw_list = db.Company_Overview.ToList();
                var add_count = new List<table_model.Company_Overview_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.Company_Overview_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
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
        public IActionResult CompanyOverview_changeStatus(int? id, string? status)
        {
            var get_data = db.Company_Overview.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult CompanyOverview_getData(int? id)
        {
            var get_data = db.Company_Overview.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }
        public IActionResult CompanyOverview_delete(int? id)
        {
            try
            {
                var checkrow = db.Company_Overview.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/CompanyOverview/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    db.Company_Overview.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Board_of_Directors_index()
        {
            return View();
        }
        public IActionResult Board_of_Directors_create(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Board_of_Directors_index", "Investor_Relations");
            }
            else
            {
                var convert_id = Convert.ToInt32(id);
                var model = new model_input { count_list_Board_of_Directors = convert_id };
                return View(model);
            }
           
        }
        public IActionResult Board_of_Directors_create_insert(Board_of_Directors board_Of_Directors, List<IFormFile> uploaded_image)
        {
            try
            {
                if (board_Of_Directors.name_th == null || board_Of_Directors.name_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อ - นามสกุล TH" });
                }
                if (board_Of_Directors.name_en == null || board_Of_Directors.name_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อ - นามสกุล EN" });
                }
                if (board_Of_Directors.position_th == null || board_Of_Directors.position_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่ง TH" });
                }
                if (board_Of_Directors.position_en == null || board_Of_Directors.position_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่ง EN" });
                }
                if (uploaded_image.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }
                if (board_Of_Directors.position_company_th == null || board_Of_Directors.position_company_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่งในบริษัท TH" });
                }
                if (board_Of_Directors.position_company_en == null || board_Of_Directors.position_company_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่งในบริษัท EN" });
                }
                if (board_Of_Directors.nationality_th == null || board_Of_Directors.nationality_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ สัญชาติ TH" });
                }
                if (board_Of_Directors.nationality_en == null || board_Of_Directors.nationality_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ สัญชาติ EN" });
                }
                if (board_Of_Directors.study_th == null || board_Of_Directors.study_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ การศึกษา TH" });
                }
                if (board_Of_Directors.study_en == null || board_Of_Directors.study_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ การศึกษา EN" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        board_Of_Directors.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BoardOfDirectors/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                if (board_Of_Directors.use_status != 1)
                {
                    board_Of_Directors.use_status = 0;
                }
                else
                {
                    board_Of_Directors.use_status = 1;
                }
                board_Of_Directors.created_at = DateTime.Now;
                db.Board_of_Directors.Add(board_Of_Directors);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Board_of_Directors_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Board_of_Directors_index", "Investor_Relations");
            }
            var get_detail = db.Board_of_Directors.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("Board_of_Directors_index", "Investor_Relations");
            }
            var model = new model_input { fod_Board_of_Directors = get_detail };
            return View(model);
        }
        public IActionResult Board_of_Directors_edit_update(Board_of_Directors board_Of_Directors, List<IFormFile> uploaded_image)
        {
            try
            {
                if (board_Of_Directors.name_th == null || board_Of_Directors.name_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อ - นามสกุล TH" });
                }
                if (board_Of_Directors.name_en == null || board_Of_Directors.name_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ชื่อ - นามสกุล EN" });
                }
                if (board_Of_Directors.position_th == null || board_Of_Directors.position_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่ง TH" });
                }
                if (board_Of_Directors.position_en == null || board_Of_Directors.position_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่ง EN" });
                }
                if (board_Of_Directors.position_company_th == null || board_Of_Directors.position_company_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่งในบริษัท TH" });
                }
                if (board_Of_Directors.position_company_en == null || board_Of_Directors.position_company_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ตำแหน่งในบริษัท EN" });
                }
                if (board_Of_Directors.nationality_th == null || board_Of_Directors.nationality_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ สัญชาติ TH" });
                }
                if (board_Of_Directors.nationality_en == null || board_Of_Directors.nationality_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ สัญชาติ EN" });
                }   
                if (board_Of_Directors.study_th == null || board_Of_Directors.study_th == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ การศึกษา TH" });
                }
                if (board_Of_Directors.study_en == null || board_Of_Directors.study_en == "")
                {
                    return Json(new { status = "error", message = "กรุณาระบุ การศึกษา EN" });
                }
                var get_oldData = db.Board_of_Directors.Where(x => x.id == board_Of_Directors.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BoardOfDirectors/" + get_oldData.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            get_oldData.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BoardOfDirectors/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }


                if (board_Of_Directors.use_status != 1)
                {
                    get_oldData.use_status = 0;
                }
                else
                {
                    get_oldData.use_status = 1;
                }
                get_oldData.updated_at = DateTime.Now;
                get_oldData.name_th = board_Of_Directors.name_th;
                get_oldData.name_en = board_Of_Directors.name_en;
                get_oldData.position_th = board_Of_Directors.position_th;
                get_oldData.position_en = board_Of_Directors.position_en;
                get_oldData.position_company_th = board_Of_Directors.position_company_th;
                get_oldData.position_company_en = board_Of_Directors.position_company_en;
                get_oldData.nationality_th = board_Of_Directors.nationality_th;
                get_oldData.nationality_en = board_Of_Directors.nationality_en;
                get_oldData.study_th = board_Of_Directors.study_th;
                get_oldData.study_en = board_Of_Directors.study_en;
                get_oldData.expertise_th = board_Of_Directors.expertise_th;
                get_oldData.expertise_en = board_Of_Directors.expertise_en;
                get_oldData.date_appointment_th = board_Of_Directors.date_appointment_th;
                get_oldData.date_appointment_en = board_Of_Directors.date_appointment_en;
                get_oldData.shares_held_th = board_Of_Directors.shares_held_th;
                get_oldData.shares_held_en = board_Of_Directors.shares_held_en;
                get_oldData.training_course_th = board_Of_Directors.training_course_th;
                get_oldData.training_course_en = board_Of_Directors.training_course_en;
                get_oldData.work_history_th = board_Of_Directors.work_history_th;
                get_oldData.work_history_en = board_Of_Directors.work_history_en;
                get_oldData.holding_position_th = board_Of_Directors.holding_position_th;
                get_oldData.holding_position_en = board_Of_Directors.holding_position_en;
                get_oldData.work_history_en = board_Of_Directors.work_history_en;
                get_oldData.Illegal_history_th = board_Of_Directors.Illegal_history_th;
                get_oldData.Illegal_history_en = board_Of_Directors.Illegal_history_en;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Board_of_Directors_index_getTable_board()
        {
            try
            {
                var Raw_list = db.Board_of_Directors.Where(x=>x.type_board == 1).ToList();
                var add_count = new List<table_model.Board_of_Directors_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.Board_of_Directors_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        position_th = items.position_th,
                        name_th = items.name_th,
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
        public IActionResult Board_of_Directors_index_getTable_management()
        {
            try
            {
                var Raw_list = db.Board_of_Directors.Where(x => x.type_board == 2).ToList();
                var add_count = new List<table_model.Board_of_Directors_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.Board_of_Directors_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
                        position_th = items.position_th,
                        name_th = items.name_th,
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
        public IActionResult Board_of_Directors_changeStatus(int? id, string? status)
        {
            var get_data = db.Board_of_Directors.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Board_of_Directors_getData(int? id)
        {
            var get_data = db.Board_of_Directors.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }
        public IActionResult Board_of_Directors_delete(int? id)
        {
            try
            {
                var checkrow = db.Board_of_Directors.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/BoardOfDirectors/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    db.Board_of_Directors.Remove(checkrow);
                    db.SaveChanges();
                }

                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Organizational_Structure_index()
        {
            return View();
        }
        public IActionResult Organizational_Structure_index_insert(OrganizationalStructure organizationalStructure, List<IFormFile> uploaded_image)
        {
            try
            {
                if (uploaded_image.Count == 0)
                {
                    return Json(new { status = "error", message = "กรุณา Upload รูป" });
                }

                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        organizationalStructure.image_name = datestr + extension;
                        var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/OrganizationalStructure/" + datestr + extension);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                if (organizationalStructure.use_status != 1)
                {
                    organizationalStructure.use_status = 0;
                }
                else
                {
                    organizationalStructure.use_status = 1;
                }
                organizationalStructure.created_at = DateTime.Now;
                db.OrganizationalStructure.Add(organizationalStructure);
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Organizational_Structure_index_update(OrganizationalStructure organizationalStructure, List<IFormFile> uploaded_image)
        {
            try
            {
                var get_oldData = db.OrganizationalStructure.Where(x => x.id == organizationalStructure.id).FirstOrDefault();
                if (uploaded_image.Count > 0)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/OrganizationalStructure/" + get_oldData.image_name);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }


                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            get_oldData.image_name = datestr + extension;
                            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/OrganizationalStructure/" + datestr + extension);

                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                }


                if (organizationalStructure.use_status != 1)
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
        public IActionResult Organizational_Structure_index_getTable()
        {
            try
            {
                var Raw_list = db.OrganizationalStructure.ToList();
                var add_count = new List<table_model.Organizational_Structure_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    add_count.Add(new table_model.Organizational_Structure_table
                    {
                        count_row = count,
                        id = items.id,
                        created_at = items.created_at,
                        image_name = items.image_name,
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
        public IActionResult Organizational_Structure_changeStatus(int? id, string? status)
        {
            var get_data = db.OrganizationalStructure.Where(x => x.id == id).FirstOrDefault();
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
        public IActionResult Organizational_Structure_getData(int? id)
        {
            var get_data = db.OrganizationalStructure.Where(x => x.id == id).FirstOrDefault();

            return Json(new { status = "success", message = "", data = get_data });
        }
        public IActionResult Organizational_Structure_delete(int? id)
        {
            try
            {
                var checkrow = db.OrganizationalStructure.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    var old_filePath = Path.Combine(_hostingEnvironment.WebRootPath, "upload_image/OrganizationalStructure/" + checkrow.image_name);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    db.OrganizationalStructure.Remove(checkrow);
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
