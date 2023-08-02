using Lighting.Areas.Identity.Data;
using Lighting.Migrations;
using Lighting.Models.InputFilterModels.IR_Index;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class IR_IndexController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public IR_IndexController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Banner()
        {
            var banner = _db.IR_Banner.FirstOrDefault();
            ViewBag.img_src = banner?.ImageBanner;
            return View();
        }

        public IActionResult TableBanner()
        {
            return View();
        }

        public IActionResult Banner_Add()
        {
            return View();
        }

        public async Task<IActionResult> Banner_Add_Submit([FromForm] IFormFile? file)
        {
            try
            {
                var path = Path.Combine("upload_image", "IR_Banner");
                if (file != null)
                {
                    using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    await _db.IR_Banner.AddAsync(
                        new IR_Banner
                        {
                            ImageBanner = Path.Combine(path, file.FileName),
                            created_at = DateTime.Now,
                            updated_at = DateTime.Now,
                        });
                    await _db.SaveChangesAsync();
                    return new JsonResult(new { status = "success", message = "success" });

                }
                return new JsonResult(new { status = "error", message = "ไม่พบข้อมูล " });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", message = "เกิดข้อผิดพลาด " + ex.Message });
            }
        }

        public IActionResult Banner_Edit()
        {

            return View();
        }

        public IActionResult GetBanner_Edit()
        {
            return View();
        }

        public async Task<IActionResult> Banner_Edit_Submit([FromForm] IFormFile? file)
        {
            try
            {
                var path = Path.Combine("upload_image", "IR_Banner");
                if (file != null)
                {
                    var banner = _db.IR_Banner.FirstOrDefault();
                    if (banner != null)
                    {
                        var oldFile = Path.Combine(_env.WebRootPath, banner?.ImageBanner);
                        if (System.IO.File.Exists(oldFile))
                        {
                            System.IO.File.Delete(oldFile);
                        }

                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        banner.ImageBanner = Path.Combine(path, file.FileName);
                        banner.updated_at = DateTime.Now;

                        await _db.SaveChangesAsync();
                        return new JsonResult(new { status = "success", message = "success" });
                    }


                }
                return new JsonResult(new { status = "error", message = "ไม่พบข้อมูล " });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", message = "เกิดข้อผิดพลาด " + ex.Message });
            }
        }

        public IActionResult Banner_Delete()
        {
            return View();
        }

        public IActionResult Banner_Change()
        {
            return View();
        }

        public async Task<IActionResult> Button_Below_Banner()
        {
            var btns = await _db.IR_Button_Below_Banner.ToArrayAsync();
            return View(btns);
        }

        public IActionResult TableButton_Below_Banner()
        {
            return View();
        }

        public IActionResult Button_Below_Banner_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Button_Below_Banner_Add_Submit([FromForm] Input_IR_IndexVM input)
        {

            try
            {
                var path = Path.Combine("upload_image", "IR_Button_Below_Banner", input?.Icon?.FileName);

                if (input.Icon != null)
                {
                    using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path), FileMode.Create))
                    {
                        await input.Icon.CopyToAsync(stream);
                    }
                }
                await _db.IR_Button_Below_Banner.AddAsync(new IR_Button_Below_Banner
                {
                    Icon = path,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    Title_EN = input.Title_EN,
                    Title_TH = input.Title_TH,
                    Link = input.Link,
                });
                await _db.SaveChangesAsync();
                return new JsonResult(new { status = "success", message = "success" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", message = "เกิดข้อผิดพลาด " + ex.Message });
            }
        }

        public async Task<IActionResult> Button_Below_Banner_Edit(int id)
        {
            var btn = await _db.IR_Button_Below_Banner.FirstOrDefaultAsync(x => x.Id == id);
            return View(btn);
        }

        public IActionResult GetButton_Below_Banner_Edit()
        {
            return View();
        }

        public async Task<IActionResult> Button_Below_Banner_Edit_Submit([FromForm] Input_IR_IndexVM input, [FromQuery] int id)
        {
            try
            {
                
                var btn = _db.IR_Button_Below_Banner.FirstOrDefault(x => x.Id == id);
                if (btn != null)
                {

                    var path = Path.Combine("upload_image", "IR_Button_Below_Banner");
                    if (input.Icon != null)
                    {
                        var save_path = Path.Combine(path, input?.Icon?.FileName);
                        if (btn?.Icon != null)
                        {
                            var oldFile = Path.Combine(_env.WebRootPath, btn?.Icon);
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path,input.Icon.FileName), FileMode.Create))
                        {
                            await input.Icon.CopyToAsync(stream);
                        }
                    }

                    btn.Icon = (input.Icon != null ? Path.Combine(path,input.Icon.FileName) : btn.Icon);
                    btn.created_at = DateTime.Now;
                    btn.updated_at = DateTime.Now;
                    btn.Title_EN = input.Title_EN;
                    btn.Title_TH = input.Title_TH;
                    btn.Link = input.Link;

                    await _db.SaveChangesAsync();
                    return new JsonResult(new { status = "success", message = "success" });
                }
                return new JsonResult(new { status = "error", message = "ไม่พบข้อมูล" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { status = "error", message = "เกิดข้อผิดพลาด " + ex.Message });
            }
        }

        public IActionResult Button_Below_Banner_Delete()
        {
            return View();
        }

        public IActionResult Button_Below_Banner_Change()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT_Aadd()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT_Edit()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT_Delete()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT_Change()
        {
            return View();
        }

        public IActionResult Summary_Financial_Highlights()
        {
            return View();
        }

        public IActionResult Summary_Financial_Highlights_Add()
        {
            return View();
        }

        public IActionResult Summary_Financial_Highlights_Edit()
        {
            return View();
        }

        public IActionResult Summary_Financial_Highlights_Delete()
        {
            return View();
        }

        public IActionResult Summary๘Financial_Highlights_Change()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Report_Add()
        {
            return View();
        }

        public IActionResult Report_Add_Submit()
        {
            return View();
        }

        public IActionResult Report_Edit()
        {
            return View();
        }

        public IActionResult Get_Report_Edit()
        {
            return View();
        }

        public IActionResult Report_Edit_Submit()
        {
            return View();
        }

        public IActionResult Report_Delete()
        {
            return View();
        }

        public IActionResult Report_Change()
        {
            return View();
        }

        public IActionResult HIGHLIGHT()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Add()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Add_Submit()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Edit()
        {
            return View();
        }

        public IActionResult GetHIGHLIGHT_Edit()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Edit_Submit()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Delete()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Change()
        {
            return View();
        }
    }
}
