using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class PrivacyController : Controller
    {
        private readonly LightingContext db;
        private IWebHostEnvironment _hostingEnvironment;
        public CultureInfo provider = CultureInfo.InvariantCulture;
        public PrivacyController(LightingContext context, IWebHostEnvironment environment)
        {
            //_config = config;
            db = context;
            _hostingEnvironment = environment;
        }
        public IActionResult privacy_index()
        {
            var checkrow = db.privacy_PolicyTitles.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_privacy_PolicyTitles = count_row, fod_privacy_PolicyTitles = checkrow };
            return View(model);
        }
        public async Task<IActionResult> privacy_Policys_getTable()
        {
            try
            {
                var Raw_list = await db.privacy_Policys.OrderByDescending(x=>x.year).ThenBy(x=>x.typeOfPolicy_id).ToListAsync();
                var add_count = new List<PrivacyModels.privacy_Policys_table>();
                var count = 1;
                foreach (var items in Raw_list)
                {
                    var getData = db.privacy_Policys.FirstOrDefault(x => x.id == items.id);

                    add_count.Add(new PrivacyModels.privacy_Policys_table
                    {
                        count_row = count,
                        id = items.id,
                        year = getData.year.Value.Year.ToString(),
                        detailsTH = items.detailsTH,
                        detailsENG = items.detailsENG,
                        typeOfPolicy_id = items.typeOfPolicy_id,
                        typeOfPolicy = items.typeOfPolicy,
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
        public IActionResult privacy_PolicysTitles_addData(privacy_PolicyTitles privacyPolicyTitles)
        {
            try
            {
                var checkrow = db.privacy_PolicyTitles.FirstOrDefault();
                if (checkrow == null)
                {
                    privacyPolicyTitles.created_at = DateTime.Now;
                    privacyPolicyTitles.updated_at = DateTime.Now;
                    db.privacy_PolicyTitles.Add(privacyPolicyTitles);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.headTitleTH = privacyPolicyTitles.headTitleTH;
                    checkrow.headTitleENG = privacyPolicyTitles.headTitleENG;
                    checkrow.privacy_TitleTH = privacyPolicyTitles.privacy_TitleTH;
                    checkrow.privacy_TitleENG = privacyPolicyTitles.privacy_TitleENG;
                    checkrow.privacy_NoticeTitleTH = privacyPolicyTitles.privacy_NoticeTitleTH;
                    checkrow.privacy_NoticeTitleENG = privacyPolicyTitles.privacy_NoticeTitleENG;
                    checkrow.cctv_privacyTitleTH = privacyPolicyTitles.cctv_privacyTitleTH;
                    checkrow.cctv_privacyTitleENG = privacyPolicyTitles.cctv_privacyTitleENG;
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
        public IActionResult privacy_create()
        {
            return View();
        }
        public IActionResult privacy_create_submit(privacy_Policys privacyPolicys, string? Year_Str)
        {
            try
            {
                if (privacyPolicys.typeOfPolicy_id == 0)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ type of privacy policy!" });
                }
                else if (privacyPolicys.typeOfPolicy_id == 1)
                {
                    privacyPolicys.typeOfPolicy = "Privacy Policy​";
                }
                else if (privacyPolicys.typeOfPolicy_id == 2)
                {
                    privacyPolicys.typeOfPolicy = "Privacy Notice สำหรับผู้สมัครงานและพนักงาน";
                }
                else if (privacyPolicys.typeOfPolicy_id == 3)
                {
                    privacyPolicys.typeOfPolicy = "CCTV Privacy Policy​";
                }

                if (privacyPolicys.active_status != 1)
                {
                    privacyPolicys.active_status = 0;
                }
                else
                {
                    privacyPolicys.active_status = 1;
                }

                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));

                var getData = db.privacy_Policys.FirstOrDefault(x => x.typeOfPolicy_id == privacyPolicys.typeOfPolicy_id && x.year.Value.Year == InsertDate_year.Year);
                if (getData != null)
                {
                    return Json(new { status = "error", message = "The input data of Year or type of privacy policy already taken!" });
                }

                if (privacyPolicys.active_status == 1)
                {
                    var check_other = from up2 in db.privacy_Policys
                                      where up2.active_status == 1 && up2.typeOfPolicy_id == privacyPolicys.typeOfPolicy_id
                                      select up2;
                    foreach (privacy_Policys up2 in check_other)
                    {
                        up2.active_status = 0;
                    }
                    db.SaveChanges();
                }

                privacyPolicys.year = InsertDate_year;
                privacyPolicys.created_at = DateTime.Now;
                privacyPolicys.updated_at = DateTime.Now;
                db.privacy_Policys.Add(privacyPolicys);
                db.SaveChanges();

                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult privacy_Policys_changeStatus(int? id, string? status)
        {
            var i = 0;
            try
            {
                var DB = db.privacy_Policys.FirstOrDefault(x => x.id == id);
                if (DB != null)
                {
                    if (DB.active_status != 1)
                    {
                        var Change = db.privacy_Policys.Where(x=>x.typeOfPolicy_id==DB.typeOfPolicy_id).ToList();
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

        } 
        public IActionResult privacy_edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("privacy_index", "Privacy");
            }
            var get_detail = db.privacy_Policys.Where(x => x.id == id).FirstOrDefault();
            if (get_detail == null)
            {
                return RedirectToAction("privacy_index", "Privacy");
            }
            var model = new model_input { fod_privacy_Policys = get_detail };
            return View(model);
        }
        public IActionResult privacy_edit_submit(privacy_Policys privacyPolicys, string? Year_Str)
        {
            try
            {
                if (privacyPolicys.typeOfPolicy_id == 0)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ type of privacy policy!" });
                }
                else if (privacyPolicys.typeOfPolicy_id == 1)
                {
                    privacyPolicys.typeOfPolicy = "Privacy Policy​";
                }
                else if (privacyPolicys.typeOfPolicy_id == 2)
                {
                    privacyPolicys.typeOfPolicy = "Privacy Notice สำหรับผู้สมัครงานและพนักงาน";
                }
                else if (privacyPolicys.typeOfPolicy_id == 3)
                {
                    privacyPolicys.typeOfPolicy = "CCTV Privacy Policy​";
                }

                if (Year_Str == null)
                {
                    return Json(new { status = "error", message = "กรุณาระบุ ปี!" });
                }
                DateTime InsertDate_year = DateTime.ParseExact(Year_Str, "yyyy", new CultureInfo("en-US"));


                var get_data = db.privacy_Policys.Where(x => x.id == privacyPolicys.id).FirstOrDefault();

                if (privacyPolicys.active_status != 1)
                {
                    get_data.active_status = 0;
                }
                else
                {
                    get_data.active_status = 1;
                }

                var listData = db.privacy_Policys.Where(x => x.id != get_data.id).ToList();
                foreach (var item in listData)
                {
                    var getData = db.privacy_Policys.FirstOrDefault(x => x.typeOfPolicy_id == privacyPolicys.typeOfPolicy_id && x.id == item.id && x.year.Value.Year == InsertDate_year.Year);
                    if (getData != null)
                    {
                        return Json(new { status = "error", message = "The input data of Year or type of privacy policy already taken!" });
                    }
                }
                get_data.year = InsertDate_year;
                get_data.updated_at = DateTime.Now;
                get_data.detailsTH = privacyPolicys.detailsTH;
                get_data.detailsENG = privacyPolicys.detailsENG;
                db.SaveChanges();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message, inner = e.InnerException });
            }
        }
        public IActionResult Get_Edit_privacy_Policys(int? id)
        {
            var InfoDataedit = db.privacy_Policys.Where(x => x.id == id).FirstOrDefault();
            if (InfoDataedit != null)
            {
                return Json(InfoDataedit);
            }
            return Json(new { alert = 0 });
        }
        public IActionResult privacy_Policys_delete(int? id)
        {
            try
            {
                var checkrow = db.privacy_Policys.Where(x => x.id == id).FirstOrDefault();

                if (checkrow != null)
                {
                    db.privacy_Policys.Remove(checkrow);
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
        public IActionResult cookies_index()
        {
            var checkrow = db.cookies_policy.FirstOrDefault();
            var count_row = 0;
            if (checkrow != null)
            {
                count_row = 1;
            }
            var model = new model_input { count_cookies_policy = count_row, fod_cookies_policy = checkrow };
            return View(model);
        }
        public IActionResult cookies_Policys_submit(cookies_policy cookies_Policy)
        {
            try
            {
                var checkrow = db.cookies_policy.FirstOrDefault();
                if (checkrow == null)
                {
                    cookies_Policy.created_at = DateTime.Now;
                    cookies_Policy.updated_at = DateTime.Now;
                    db.cookies_policy.Add(cookies_Policy);
                    db.SaveChanges();
                }
                else
                {
                    checkrow.headTitleTH = cookies_Policy.headTitleTH;
                    checkrow.headTitleENG = cookies_Policy.headTitleENG;
                    checkrow.detailsTH = cookies_Policy.detailsTH;
                    checkrow.detailsENG = cookies_Policy.detailsENG; 
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




    }
}
