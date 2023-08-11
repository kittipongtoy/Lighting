using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.NewImgContent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    public class ApplyImgContentController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public ApplyImgContentController(LightingContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        [HttpPost]
        public async Task<ActionResult> Save([FromForm] Input_img_ContentVM input) {
            var path = Path.Combine("upload_image", "Apply_Img_Content");
            try
            {
                var news_img_content = await _db.ApplyJobImgContents.FirstOrDefaultAsync( x => x.Id == 1);
                if (news_img_content != null)
                {
                    if (input.Benefit_img != null)
                    {
                        if (news_img_content.Benefit_img != null)
                        {
                            var old_file = Path.Combine(_env.WebRootPath, news_img_content.Benefit_img);
                            if (System.IO.File.Exists(old_file))
                            {
                                System.IO.File.Delete(old_file);
                            }
                        }
                        var save_path = Path.Combine(_env.WebRootPath, path, input.Benefit_img.FileName);
                        using (var stream = new FileStream(save_path, FileMode.Create))
                        {
                            await input.Benefit_img.CopyToAsync(stream);
                        }
                    }

                    if (input.Benefit_pdf != null)
                    {
                        if (news_img_content.Benefit_pdf != null)
                        {
                            var old_file = Path.Combine(_env.WebRootPath, news_img_content.Benefit_pdf);
                            if (System.IO.File.Exists(old_file))
                            {
                                System.IO.File.Delete(old_file);
                            }
                        }
                        var save_path = Path.Combine(_env.WebRootPath, path, input.Benefit_pdf.FileName);
                        using (var stream = new FileStream(save_path, FileMode.Create))
                        {
                            await input.Benefit_pdf.CopyToAsync(stream);
                        }
                    }

                    if (input.Position_img != null)
                    {
                        if (news_img_content.Position_img != null)
                        {
                            var old_file = Path.Combine(_env.WebRootPath, news_img_content.Position_img);
                            if (System.IO.File.Exists(old_file))
                            {
                                System.IO.File.Delete(old_file);
                            }
                        }
                        var save_path = Path.Combine(_env.WebRootPath, path, input.Position_img.FileName);
                        using (var stream = new FileStream(save_path, FileMode.Create))
                        {
                            await input.Position_img.CopyToAsync(stream);
                        }
                    }

                    if (input.Position_pdf != null)
                    {
                        if (news_img_content.Position_pdf != null)
                        {
                            var old_file = Path.Combine(_env.WebRootPath, news_img_content.Position_pdf);
                            if (System.IO.File.Exists(old_file))
                            {
                                System.IO.File.Delete(old_file);
                            }
                        }
                        var save_path = Path.Combine(_env.WebRootPath, path, input.Position_pdf.FileName);
                        using (var stream = new FileStream(save_path, FileMode.Create))
                        {
                            await input.Position_pdf.CopyToAsync(stream);
                        }
                    }

                    news_img_content.Position_pdf = input.Position_pdf != null ? Path.Combine(path, input.Position_pdf.FileName) : news_img_content.Position_pdf;
                    news_img_content.Position_img = input.Position_img != null ? Path.Combine(path, input.Position_img.FileName) : news_img_content.Position_img;
                    news_img_content.Benefit_pdf = input.Benefit_pdf != null ? Path.Combine(path, input.Benefit_pdf.FileName) : news_img_content.Benefit_pdf;
                    news_img_content.Benefit_img = input.Benefit_img != null ? Path.Combine(path, input.Benefit_img.FileName) : news_img_content.Benefit_img;
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                else
                {
                    if (input.Benefit_img != null)
                    {
                        var save_path = Path.Combine(_env.WebRootPath, path, input.Benefit_img.FileName);
                        using (var stream = new FileStream(save_path, FileMode.Create))
                        {
                            await input.Benefit_img.CopyToAsync(stream);
                        }
                    }

                    if (input.Benefit_pdf != null)
                    {
                        var save_path = Path.Combine(_env.WebRootPath, path, input.Benefit_pdf.FileName);
                        using (var stream = new FileStream(save_path, FileMode.Create))
                        {
                            await input.Benefit_pdf.CopyToAsync(stream);
                        }
                    }

                    if (input.Position_img != null)
                    {
                        var save_path = Path.Combine(_env.WebRootPath, path, input.Position_img.FileName);
                        using (var stream = new FileStream(save_path, FileMode.Create))
                        {
                            await input.Position_img.CopyToAsync(stream);
                        }
                    }

                    if (input.Position_pdf != null)
                    {
                        var save_path = Path.Combine(_env.WebRootPath, path, input.Position_pdf.FileName);
                        using (var stream = new FileStream(save_path, FileMode.Create))
                        {
                            await input.Position_pdf.CopyToAsync(stream);
                        }
                    }

                    await _db.ApplyJobImgContents.AddAsync(new ApplyImgContent
                    {
                        Benefit_img = input.Benefit_img != null ? Path.Combine(path, input.Benefit_img.FileName) : null,
                        Benefit_pdf = input.Benefit_pdf != null ? Path.Combine(path, input.Benefit_pdf.FileName) : null,
                        Position_img = input.Position_img != null ? Path.Combine(path, input.Position_img.FileName) : null,
                        Position_pdf = input.Position_pdf != null ? Path.Combine(path, input.Position_pdf.FileName) : null,
                    });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
            }
        }
        public async Task<ActionResult> ChangeContent()
        {
            var first = await _db.ApplyJobImgContents.FirstOrDefaultAsync();
            if (first == null) return View(new ApplyImgContent());
            return View(first);
        }
    }
}
