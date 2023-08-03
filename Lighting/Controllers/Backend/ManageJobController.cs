using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.ApplyJob;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class ManageJobController : Controller
    {
        private readonly LightingContext _db;
        public ManageJobController(LightingContext db)
        {
            _db = db;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var jobs = await _db.ApplyJobs
        //        .OrderByDescending(job => job.Id)
        //        .Select(job => new Output_ApplyJobVM
        //        {
        //            Id = job.Id,
        //            Date_EN = job.Date_EN,
        //            Date_TH = job.Date_TH,
        //            Email1 = job.Email1,
        //            Email2 = job.Email2,
        //            PhoneNumber = job.PhoneNumber,
        //            PositionName_EN = job.PositionName_EN,
        //            PositionName_TH = job.PositionName_TH,
        //            Qualification_EN = job.Qualification_EN,
        //            Qualification_TH = job.Qualification_TH,
        //            Quantity = job.Quantity,
        //            Respondsibility_EN = job.Respondsibility_EN,
        //            Respondsibility_TH = job.Respondsibility_TH,
        //            WorkPlace_EN = job.WorkPlace_EN,
        //            WorkPlace_TH = job.WorkPlace_TH,
        //        })
        //        .ToListAsync();

        //    return View(jobs);
        //}
        public IActionResult Add_Job_Page()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            var job = await _db.ApplyJobs.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (job != null)
            {
                _db.ApplyJobs.Remove(job);
                await _db.SaveChangesAsync();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Input_ApplyJobVM input, [FromQuery] int id)
        {
            var job = await _db.ApplyJobs.Where(job => job.Id == id).FirstOrDefaultAsync();
            if (job != null)
            {
                job.PositionName_EN = input.PositionName_EN;
                job.Date_EN = input.Date_EN;
                job.Date_TH = input.Date_TH;
                job.Email1 = input.Email1;
                job.Email2 = input.Email2;
                job.PhoneNumber = input.PhoneNumber;
                job.PositionName_TH = input.PositionName_TH;
                job.Qualification_EN = input.Qualification_EN;
                job.Qualification_TH = input.Qualification_TH;
                job.Quantity = input.Quantity;
                job.Respondsibility_EN = input.Respondsibility_EN;
                job.Respondsibility_TH = input.Respondsibility_TH;
                job.WorkPlace_EN = input.WorkPlace_EN;
                job.WorkPlace_TH = input.WorkPlace_TH;
                await _db.SaveChangesAsync();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }
        public async Task<IActionResult> Edit_Job_Page(int id)
        {
            var job = await _db.ApplyJobs.AsNoTracking().Where(job => job.Id == id).FirstOrDefaultAsync();
            if (job != null)
            {
                var output_job = new Output_ApplyJobVM
                {
                    Id = job.Id,
                    Date_EN = job.Date_EN,
                    Date_TH = job.Date_TH,
                    Email1 = job.Email1,
                    Email2 = job.Email2,
                    PhoneNumber = job.PhoneNumber,
                    PositionName_EN = job.PositionName_EN,
                    PositionName_TH = job.PositionName_TH,
                    Qualification_EN = job.Qualification_EN,
                    Qualification_TH = job.Qualification_TH,
                    Quantity = job.Quantity,
                    Respondsibility_EN = job.Respondsibility_EN,
                    Respondsibility_TH = job.Respondsibility_TH,
                    WorkPlace_EN = job.WorkPlace_EN,
                    WorkPlace_TH = job.WorkPlace_TH,
                };
                return View(output_job);
            }
            return RedirectToAction("Manage_Job_Page");
        }
        public async Task<IActionResult> Manage_Job_Page()
        {
            var jobs = await _db.ApplyJobs
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(job =>
                new Output_ApplyJobVM
                {
                    Id = job.Id,
                    Date_EN = job.Date_EN,
                    Date_TH = job.Date_TH,
                    Email1 = job.Email1,
                    Email2 = job.Email2,
                    PhoneNumber = job.PhoneNumber,
                    PositionName_EN = job.PositionName_EN,
                    PositionName_TH = job.PositionName_TH,
                    Qualification_EN = job.Qualification_EN,
                    Qualification_TH = job.Qualification_TH,
                    Quantity = job.Quantity,
                    Respondsibility_EN = job.Respondsibility_EN,
                    Respondsibility_TH = job.Respondsibility_TH,
                    WorkPlace_EN = job.WorkPlace_EN,
                    WorkPlace_TH = job.WorkPlace_TH,
                }).ToListAsync();

            return View(jobs);
        }
        [HttpPost]
        public async Task<IActionResult> Add_Job([FromForm] Input_ApplyJobVM job)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _db.ApplyJobs.AddAsync(new ApplyJob
                    {
                        PositionName_EN = job.PositionName_EN,
                        Date_EN = job.Date_EN,
                        Date_TH = job.Date_TH,
                        Email1 = job.Email1,
                        Email2 = job.Email2,
                        PhoneNumber = job.PhoneNumber,
                        PositionName_TH = job.PositionName_TH,
                        Qualification_EN = job.Qualification_EN,
                        Qualification_TH = job.Qualification_TH,
                        Quantity = job.Quantity,
                        Respondsibility_EN = job.Respondsibility_EN,
                        Respondsibility_TH = job.Respondsibility_TH,
                        WorkPlace_EN = job.WorkPlace_EN,
                        WorkPlace_TH = job.WorkPlace_TH,
                    });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }
            return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }
    }
}
