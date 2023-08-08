using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.ApplyJob;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Frontend
{
    public class ApplyJobController : Controller
    {
        private readonly LightingContext _db;
        public ApplyJobController(LightingContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> ApplyJob()
        {
            var jobs = await _db.ApplyJobs
                .AsNoTracking()
                .OrderByDescending(job => job.Id)
                .Select(job => new Output_ApplyJobVM
                {
                    Id = job.Id,
                    Date_EN = job.Date_EN,
                    Date_TH = job.Date_TH,
                    Email1 = job.Email1,
                    //Email2 = job.Email2,
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
                })
                .ToListAsync();
            var img_content = await _db.ApplyJobImgContents.FirstOrDefaultAsync();
            ViewData["JobImage"] = img_content;
            return View(jobs);
        }
    }
}
