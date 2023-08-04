using Lighting.Areas.Identity.Data;

using Lighting.Models.InputFilterModels.SmartSolution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class ManageSmartSolutionController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public ManageSmartSolutionController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Add([FromForm] Input_Smart_SolutionVM input)
        {
            var flderName = Guid.NewGuid().ToString();
            var path = Path.Combine("upload_image", "Smart_Solution_Link", flderName);
            var directory = Path.Combine(_env.WebRootPath, path);
            Directory.CreateDirectory(directory);
            try
            {
                var link = new List<Smart_Solution_Link>();

                if (input.DetailImg != null)
                {
                    using (var stream = new FileStream(Path.Combine(directory, input.DetailImg.FileName), FileMode.Create))
                    {
                        await input.DetailImg.CopyToAsync(stream);
                    }
                }

                if (input.LinkFiles != null)
                {
                    for (int i = 0; i < input.LinkFiles.Count; i++)
                    {
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, input.LinkFiles[i].FileName), FileMode.Create))
                        {
                            await input.LinkFiles[i].CopyToAsync(stream);
                        }
                        link.Add(
                            new Smart_Solution_Link
                            {
                                Path = Path.Combine(path, input.LinkFiles[i].FileName),
                                Link = input.Links[i],
                            });
                    }
                }

                if (input.PreviewImg != null)
                {
                    using (var stream = new FileStream(Path.Combine(directory, input.PreviewImg.FileName), FileMode.Create))
                    {
                        await input.PreviewImg.CopyToAsync(stream);
                    }
                }



                await _db.Smart_Solutions.AddRangeAsync(new Smart_Solution
                {
                    Links = link,
                    Explanation_EN = input.Explanation_EN,
                    Explanation_TH = input.Explanation_TH,
                    PreviewImg = input?.PreviewImg == null ? null : Path.Combine(path, input.PreviewImg.FileName),
                    DetailImg = input?.DetailImg == null ? null : Path.Combine(path, input.DetailImg.FileName),
                    Content_EN = input?.Content_EN,
                    Content_TH = input?.Content_TH,
                    TitleName_EN = input.TitleName_EN,
                    TitleName_TH = input.TitleName_TH,
                });
                await _db.SaveChangesAsync();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            catch (Exception ex)
            {
                if (Directory.Exists(directory))
                {
                    Directory.Delete(directory, true);
                }
                return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
            }
        }

        public async Task<IActionResult> Edit([FromForm] Input_Smart_SolutionVM input, [FromQuery] int id)
        {

            try
            {
                var solution = await _db.Smart_Solutions.FirstOrDefaultAsync(x => x.Id == id);
                if (solution != null)
                {
                    //get path from db
                    var path = Path.GetDirectoryName(
                        solution.PreviewImg != null 
                        ? solution.PreviewImg : solution.DetailImg != null 
                        ? solution.DetailImg:"");

                    var directory = Path.Combine(_env.WebRootPath,path);
                    var link = new List<Smart_Solution_Link>();

                    if (input.DetailImg != null)
                    {
                        if(solution.DetailImg != null)
                        {
                            var oldFile_path = Path.Combine(_env.WebRootPath, solution.DetailImg);
                            if (System.IO.File.Exists(oldFile_path))
                            {
                                System.IO.File.Delete(oldFile_path);
                            }
                        }

                        using (var stream = new FileStream(Path.Combine(directory, input.DetailImg.FileName), FileMode.Create))
                        {
                            await input.DetailImg.CopyToAsync(stream);
                        }
                    }

                    if (input.LinkFiles != null)
                    {
                        for (int i = 0; i < input.LinkFiles.Count; i++)
                        {
                            using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, input.LinkFiles[i].FileName), FileMode.Create))
                            {
                                await input.LinkFiles[i].CopyToAsync(stream);
                            }
                            link.Add(
                                new Smart_Solution_Link
                                {
                                    Path = Path.Combine(path, input.LinkFiles[i].FileName),
                                    Link = input.Links[i],
                                });
                        }
                    }

                    if (input.PreviewImg != null)
                    {
                        if (solution.PreviewImg != null)
                        {
                            var oldFile_path = Path.Combine(_env.WebRootPath, solution.PreviewImg);
                            if (System.IO.File.Exists(oldFile_path))
                            {
                                System.IO.File.Delete(oldFile_path);
                            }
                        }
                        using (var stream = new FileStream(Path.Combine(directory, input.PreviewImg.FileName), FileMode.Create))
                        {
                            await input.PreviewImg.CopyToAsync(stream);
                        }
                    }

                    solution.PreviewImg = input.PreviewImg != null ? Path.Combine(path, input.PreviewImg.FileName) : solution.PreviewImg;
                    solution.DetailImg = input.DetailImg != null ? Path.Combine(path, input.DetailImg.FileName) : solution.DetailImg;
                    solution.Links = link;
                    solution.Explanation_TH = input.Explanation_TH;
                    solution.Explanation_EN = input?.Explanation_EN;
                    solution.Content_EN = input?.Content_EN;
                    solution.Content_TH = input?.Content_TH;
                    solution.TitleName_TH = input?.TitleName_TH;
                    solution.TitleName_EN = input?.TitleName_EN;

                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }

                return Json(new { status = "error", message = "ไม่พบข้ออมูล" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
            }
        }

        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            var solution = await _db.Smart_Solutions.Include(x => x.Links).FirstOrDefaultAsync(x => x.Id == id);
            if (solution != null)
            {
                try
                {
                    //remove folder image 1
                    if (solution.DetailImg != null)
                    {
                        var path = Path.Combine(_env.WebRootPath, Path.GetDirectoryName(solution.DetailImg));
                        if (Directory.Exists(path))
                        {
                            Directory.Delete(path, true);
                        }
                    }
                    //remove folder image 2
                    if (solution.PreviewImg != null)
                    {
                        var path1 = Path.Combine(_env.WebRootPath, Path.GetDirectoryName(solution.PreviewImg));
                        if (Directory.Exists(path1))
                        {
                            Directory.Delete(path1, true);
                        }
                    }
                    //remove relation
                    _db.Smart_Solution_Links.RemoveRange(solution.Links);
                    //remove entity
                    _db.Smart_Solutions.Remove(solution);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }
        public async Task<IActionResult> DeleteLinkById([FromQuery] int id)
        {
            var link = await _db.Smart_Solution_Links.FirstOrDefaultAsync(x => x.Id == id);
            if (link != null)
            {
                try
                {
                    //delete file
                    if (link != null)
                    {
                        var file_path = Path.Combine(_env.WebRootPath, link.Path);
                        if (System.IO.File.Exists(file_path))
                        {
                            System.IO.File.Delete(file_path);
                        }
                    }
                    _db.Smart_Solution_Links.Remove(link);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }
        public async Task<IActionResult> Manage_Page()
        {
            var solution = await _db.Smart_Solutions
                .AsNoTracking()
                .Include(x => x.Links)
                .Select(solution => new Output_Smart_SolutionVM
                {
                    Id = solution.Id,
                    Content_EN = solution.Content_EN,
                    Content_TH = solution.Content_TH,
                    Explanation_EN = solution.Explanation_EN,
                    Explanation_TH = solution.Explanation_TH,
                    Links = solution.Links,
                    DetailImg = solution.DetailImg,
                    PreviewImg = solution.PreviewImg,
                    TitleName_EN = solution.TitleName_EN,
                    TitleName_TH = solution.TitleName_TH,
                })
                .ToListAsync();
            return View(solution);
        }

        public IActionResult Add_Page()
        {
            return View();
        }

        public async Task<IActionResult> Edit_Page(int id)
        {
            var solution = await _db.Smart_Solutions.AsNoTracking().Include(x => x.Links).FirstOrDefaultAsync(solution => solution.Id == id);
            if (solution != null)
            {
                return View(solution);
            }
            return NotFound();
        }
    }
}
