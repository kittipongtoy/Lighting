using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.ProjectRef;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class ManageProjectCategoryController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;

        public ManageProjectCategoryController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Input_CategoryVM input)
        {
            if (ModelState.IsValid)
            {
                var file_name = Guid.NewGuid().ToString() + ".jpg";
                var path_file = Path.Combine("upload_image", "Image_Category", file_name);
                var save_path = Path.Combine(_env.WebRootPath, path_file);
                try
                {

                    using (var stream = new FileStream(save_path, FileMode.CreateNew))
                    {
                        await input.Image_File.CopyToAsync(stream);
                    }
                    var file_nav = Path.Combine( "upload_image", "Image_Category", Guid.NewGuid().ToString()+".jpg");
                    using (var stream = new FileStream(Path.Combine(_env.WebRootPath,file_nav), FileMode.CreateNew))
                    {
                        await input.Image_File_Nav.CopyToAsync(stream);
                    }
                    await _db.Category_Projects.AddAsync(new Category_Project
                    {
                        Image_Path = path_file,
                        Name_EN = input.Name_EN,
                        Name_TH = input.Name_TH,
                         Image_Path_Nav = file_nav
                         
                    });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });

                }
                catch (Exception ex)
                {
                    if (System.IO.File.Exists(save_path))
                    {
                        System.IO.File.Delete(save_path);
                    }
                    return Json(new { status = "error", message = "เกิดข้อผิดพลาด" });
                }
            }
            return Json(new { status = "error", message = "กรุณากรอกข้อมูลให้ครบ" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Input_CategoryVM input, [FromQuery] int id)
        {
            var category = await _db.Category_Projects.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category != null)
            {
                try
                {
                    var file_name = Guid.NewGuid().ToString() + ".jpg";
                    var path_file = Path.Combine("upload_image", "Image_Category", file_name);
                    var img_nav_path = Path.Combine("upload_image", "Image_Category", Guid.NewGuid().ToString() + ".jpg");
                    if (input.Image_File != null)
                    {
                        //delete old file
                        var old_file = Path.Combine(_env.WebRootPath, category.Image_Path);
                        if (System.IO.File.Exists(old_file))
                        {
                            System.IO.File.Delete(old_file);
                        }
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path_file), FileMode.CreateNew))
                        {
                            await input.Image_File.CopyToAsync(stream);
                        }
                    }
                    if (input.Image_File_Nav != null)
                    {

                        //delete old file
                        var old_file = Path.Combine(_env.WebRootPath, category.Image_Path_Nav);
                        if (System.IO.File.Exists(old_file))
                        {
                            System.IO.File.Delete(old_file);
                        }
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, img_nav_path), FileMode.CreateNew))
                        {
                            await input.Image_File_Nav.CopyToAsync(stream);
                        }
                    }
                    //update
                    category.Name_EN = input.Name_EN;
                    category.Name_TH = input.Name_TH;
                    category.Image_Path = input.Image_File != null ?  path_file: category.Image_Path;
                    category.Image_Path_Nav = input.Image_File_Nav != null ? img_nav_path : category.Image_Path_Nav;
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = "เกิดข้อผิดพลาด" });
                }

            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            var category = await _db.Category_Projects.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category != null)
            {
                var delete_file_path = Path.Combine(_env.WebRootPath, category.Image_Path);
                if (System.IO.File.Exists(delete_file_path))
                {
                    System.IO.File.Delete(delete_file_path);
                }
                var delete_file_path_nav = Path.Combine(_env.WebRootPath, category.Image_Path_Nav);
                if (System.IO.File.Exists(delete_file_path_nav))
                {
                    System.IO.File.Delete(delete_file_path_nav);
                }
                _db.Category_Projects.Remove(category);
                await _db.SaveChangesAsync();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }

        public async Task<IActionResult> Manage_Page()
        {
            var project = await _db.Category_Projects
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(project => new Category_Project
                {
                    Id = project.Id,
                    Image_Path = project.Image_Path,
                    Name_EN = project.Name_EN,
                    Name_TH = project.Name_TH,
                     Image_Path_Nav = project.Image_Path_Nav,
                })
                .ToListAsync();
            return View(project);
        }
    }
}
