using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.ProjectRef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Lighting.Controllers.Backend
{
    public class ProjectRefController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;

        public ProjectRefController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Input_ProjectRefVM input)
        {
            if (ModelState.IsValid)
            {
                var folder = Guid.NewGuid().ToString();
                var path = Path.Combine("upload_image", "ProjectRef", folder);
                Directory.CreateDirectory(Path.Combine(_env.WebRootPath, path));
                try
                {
                    var category = await _db.Category_Projects.FirstOrDefaultAsync(cat => cat.Id == input.CategoryId);
                    if (category == null) throw new Exception("Category not found");
                    var profile_img_name = Guid.NewGuid().ToString().Substring(0, 5) + ".jpg";
                    using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, profile_img_name), FileMode.Create))
                    {
                        await input.Profile_Image.CopyToAsync(stream);
                    }

                    using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, input.File_Download.FileName), FileMode.Create))
                    {
                        await input.File_Download.CopyToAsync(stream);
                    }

                    foreach (var file in input.Image_List)
                    {
                        var sub_img_name = Guid.NewGuid().ToString().Substring(0, 5) + ".jpg";
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, sub_img_name), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }

                    var projectRef = new ProjectRef
                    {
                        Title_TH = input.Title_TH,
                        Title_EN = input.Title_EN,
                        Content_EN = input.Content_EN,
                        Content_TH = input.Content_TH,
                        Client = input.Client,
                        Design_Solution = input.Design_Solution,
                        Folder_Path = path,
                        Location_EN = input.Location_EN,
                        Location_TH = input.Location_TH,
                        Photo_Credit = input.Photo_Credit,
                        //CategoryId = input.CategoryId,
                        ProjectRef_Category = category,
                        File_Download = input.File_Download.FileName,
                        Profile_Image = profile_img_name,
                    };

                    await _db.ProjectRefs.AddAsync(projectRef);
                    await _db.SaveChangesAsync();
                    if(input.ProductId != null)
                    {
                        foreach (var productId in input.ProductId)
                        {
                            await _db.ProjectRef_Products.AddAsync(new ProjectRef_Product { ProductId= productId , ProjectId = projectRef.Id});
                            await _db.SaveChangesAsync();
                        }
                    }
                    
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    var delete = Path.Combine(_env.WebRootPath, path);
                    if (Directory.Exists(delete))
                    {
                        Directory.Delete(delete, true);
                    }
                    return Json(new { status = "error", message = "เกิดข้อผิดพลาด หรือซื่อไฟล์ซ้ำกัน " + ex.Message });
                }
            }

            return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }

        public async Task<IActionResult> Add_Page()
        {
            var category = await _db.Category_Projects
                .AsNoTracking()
                .Select(cat =>
                new Output_CategoryVM
                {
                    Image_Path = cat.Image_Path,
                    Id = cat.Id,
                    Name_EN = cat.Name_EN,
                    Name_TH = cat.Name_TH,
                })
                .ToListAsync();
            ViewData["category"] = await _db.Product_Categorys.ToListAsync();
            return View(category);
        }

        [HttpPost]
        public IActionResult DeleteImgByPath(string path)
        {
            try
            {
                var delete_file = Path.Combine(_env.WebRootPath, path);
                if (System.IO.File.Exists(delete_file))
                {
                    System.IO.File.Delete(delete_file);
                    return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
                }
                return Json(new { status = "error", message = "ไม่พบข้อมูล" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "เกิดข้อผิดพลาด " + ex.Message });
            }
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var project = await _db.ProjectRefs.FirstOrDefaultAsync(r => r.Id == id);
                if (project != null)
                {
                    var delete_folder = Path.Combine(_env.WebRootPath, project.Folder_Path);
                    if (Directory.Exists(delete_folder))
                    {
                        Directory.Delete(delete_folder, true);
                    }
                    _db.ProjectRefs.Remove(project);
                    await _db.SaveChangesAsync();

                   var products = await _db.ProjectRef_Products.Where(project => project.ProjectId == id).ToListAsync();
                    if (products != null)
                    {
                        _db.ProjectRef_Products.RemoveRange(products);
                        await _db.SaveChangesAsync();
                    }

                    return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
                }
                return Json(new { status = "error", message = "ไม่พบข้อมูล" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "เกิดข้อผิดพลาด " + ex.Message });
            }
        }

        public async Task<IActionResult> DeleteSubProduct(int projectId,int productId)
        {
            var products = await _db.ProjectRef_Products.Where(project => project.ProjectId==projectId && project.ProductId == productId).FirstOrDefaultAsync();
            if (products != null)
            {
                _db.ProjectRef_Products.Remove(products);
                await _db.SaveChangesAsync();
                return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }

        public async Task<IActionResult> Edit([FromForm] Input_ProjectRefVM input, [FromQuery] int id)
        {

            var project = await _db.ProjectRefs.FirstOrDefaultAsync(_ => _.Id == id);
            if (project != null)
            {
                var path = Path.Combine( project.Folder_Path);
                try
                {
                    var category = await _db.Category_Projects.FirstOrDefaultAsync(cat => cat.Id == input.CategoryId);
                    if (category == null) throw new Exception("Category not found");

                    if (input.Profile_Image != null)
                    {
                        var new_file_name = Guid.NewGuid().ToString().Substring(0, 5) + ".jpg";
                        var old_file = Path.Combine(_env.WebRootPath, path, project.Profile_Image);
                        if (System.IO.File.Exists(old_file))
                        {
                            System.IO.File.Delete(old_file);
                        }
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, new_file_name), FileMode.CreateNew))
                        {
                            await input.Profile_Image.CopyToAsync(stream);
                        }
                        project.Profile_Image = new_file_name;
                    }

                    if (input.File_Download != null)
                    {
                        var old_file = Path.Combine(_env.WebRootPath, path, project.File_Download);
                        if (System.IO.File.Exists(old_file))
                        {
                            System.IO.File.Delete(old_file);
                        }
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, input.File_Download.FileName), FileMode.CreateNew))
                        {
                            await input.File_Download.CopyToAsync(stream);
                        }
                        project.File_Download = input.File_Download.FileName;
                    }

                    if (input.Image_List != null)
                    {
                        foreach (var file in input.Image_List)
                        {
                            var new_file_name = Guid.NewGuid().ToString().Substring(0, 5) + ".jpg";
                            using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, new_file_name), FileMode.CreateNew))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }

                    project.Title_TH = input.Title_TH;
                    project.Title_EN = input.Title_EN;
                    project.Content_EN = input.Content_EN;
                    project.Content_TH = input.Content_TH;
                    project.Client = input.Client;
                    project.Design_Solution = input.Design_Solution;
                    project.Location_EN = input.Location_EN;
                    project.Location_TH = input.Location_TH;
                    project.Photo_Credit = input.Photo_Credit;
                    //category
                    //project.CategoryId = category.Id;
                    project.ProjectRef_Category = category;

                    await _db.SaveChangesAsync();

                    if (input.ProductId != null)
                    {
                        foreach (var productId in input.ProductId)
                        {
                            await _db.ProjectRef_Products.AddAsync(new ProjectRef_Product { ProductId = productId, ProjectId = project.Id });
                            await _db.SaveChangesAsync();
                        }
                    }

                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = "เกิดข้อผิดพลาด หรือซื่อไฟล์ซ้ำกัน " + ex.Message });
                }

            }


            return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }
        public async Task<IActionResult> Edit_Page(int id)
        {
            var project = await _db.ProjectRefs.Where(project => project.Id == id).ToListAsync();

            if (project != null)
            {
                var proj_output = project
                                .Select(proj => new Output_ProjectRefVM
                                {
                                    Id = proj.Id,
                                    //CategoryId = proj.CategoryId,
                                    Client = proj.Client,
                                    Content_EN = proj.Content_EN,
                                    Content_TH = proj.Content_TH,
                                    Design_Solution = proj.Design_Solution,
                                    File_Download = Path.Combine(proj.Folder_Path, proj.File_Download),
                                    Image_List = GetFileName(new List<string> { proj.File_Download, proj.Profile_Image }, proj.Folder_Path),
                                    Location_EN = proj.Location_EN,
                                    Location_TH = proj.Location_TH,
                                    Photo_Credit = proj.Photo_Credit,
                                    Title_EN = proj.Title_EN,
                                    Title_TH = proj.Title_TH,
                                    Profile_Image = Path.Combine(proj.Folder_Path, proj.Profile_Image),
                                }).FirstOrDefault();

                var category = await _db.Category_Projects
            .AsNoTracking()
            .Select(cat =>
            new Output_CategoryVM
            {
                Image_Path = cat.Image_Path,
                Id = cat.Id,
                Name_EN = cat.Name_EN,
                Name_TH = cat.Name_TH,
            })
            .ToListAsync();
                ViewBag.Category = category;


                return View(proj_output);
            }
            return NotFound("ไม่พบโปรเจค");
        }

        public IActionResult DownloadFile(string path)
        {
            var path_file = Path.Combine(_env.WebRootPath, path);
            if (System.IO.File.Exists(path_file))
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(path_file);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, Path.GetFileName(path_file));
            }
            return NotFound("file not found"); 
        }     

        public async Task<IActionResult> Manage_Page(int start)
        {
            var project = await _db.ProjectRefs
                .AsNoTracking()
                .OrderByDescending(r => r.Id)   
                .Skip(start)
                .Take(start + 20)
                .Select(project => new Output_ProjectRef_PreviewVM
                {
                    Id = project.Id,
                    PreView_Image = Path.Combine(project.Folder_Path, project.Profile_Image),
                    Title_EN = project.Title_EN,
                    Title_TH = project.Title_TH,
                })
                .ToListAsync();
            return View(project);
        }

        private List<string>? GetFileName(List<string> ignore_file_name, string path)
        {
            try
            {
                var file_name = Directory.GetFiles(Path.Combine(_env.WebRootPath, path))
                    .Where(filePath => !ignore_file_name.Contains(filePath.Split("\\").Reverse().First()))
                    .Select(file_name =>
                    {
                        return Path.Combine(path, file_name.Split("\\").Reverse().First());
                    })
                    .ToList();

                return file_name;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
