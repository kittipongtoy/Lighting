using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Frontend
{
    public class SmartSolutionController : Controller
    {
        private readonly LightingContext _db;
        public SmartSolutionController(LightingContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> JsonNavBar()
        {
            var lang = Request.Cookies["lang"];
            if (lang == "EN")
            {
                var solutions = await _db.Smart_Solutions
                    .AsNoTracking()
                    .Select(x => new
                    {
                        Name = x.TitleName_EN,
                        Image = x.PreviewImg

                    })
                    .ToListAsync();
                return Json(solutions);
            }
            else
            {
                var solutions = await _db.Smart_Solutions
                .AsNoTracking()
                .Select(x => new
                {
                    Name = x.TitleName_TH,
                    Image = x.PreviewImg

                })
                .ToListAsync();
                return Json(solutions);
            }
        }
        public async Task<IActionResult> SmartSolution()
        {
            var solutions = await _db.Smart_Solutions.AsNoTracking().ToListAsync();
            return View(solutions);
        }

        public async Task<IActionResult> SmartSolutionDetail(string name)
        {
            var solution = await _db.Smart_Solutions.AsNoTracking().Include(x => x.Links).FirstOrDefaultAsync(s => s.TitleName_EN.ToLower().Contains(name.ToLower()) || s.TitleName_TH.StartsWith(name));
            if (solution == null) { return NotFound(); }
            return View(solution);
        }
    }
}
