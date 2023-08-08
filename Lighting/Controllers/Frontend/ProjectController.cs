﻿using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.ProjectRef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Frontend
{
    public class ProjectController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public ProjectController(LightingContext db, IWebHostEnvironment env)
        {

            _db = db;
            _env = env;

            //
        }

        public async Task<IActionResult> JsonNavBar()
        {
           var lang = Request.Cookies["lang"];
            if (lang == "EN") {
                var project = await _db.Category_Projects
                .AsNoTracking()
                .Select(project => new 
                {
                    Id = project.Id,
                    Image = project.Image_Path_Nav,
                    Name = project.Name_EN,
                })
                .ToListAsync();

                return Json(project);
            }
            else
            {
                var project = await _db.Category_Projects
                .AsNoTracking()
                .Select(project => new
                {
                    Id = project.Id,
                    Image = project.Image_Path_Nav,
                    Name = project.Name_TH,
                })
                .ToListAsync();

                return Json(project);
            }
        }

        public async Task<IActionResult> Project(int start)
        {
            var project = await _db.Category_Projects
                .AsNoTracking()
                .Skip(start)
                .Take(start + 12)
                    .Select(project => new Category_Project
                    {
                        Id = project.Id,
                        Image_Path = project.Image_Path,
                        Name_EN = project.Name_EN,
                        Name_TH = project.Name_TH,
                    })
                    .ToListAsync();

            #region pagination
            var maximum_page = 12;
            var pagination_page = new List<int>();
            var page_count = _db.Category_Projects.AsNoTracking().ToList().Count();
            var is_only_one_page = false;
            if (page_count <= maximum_page)
            {
                pagination_page.Add(0);
                is_only_one_page = true;
            }
            else
            {
                var max_number_page = (int)(page_count / maximum_page);
                for (int page_num = 0; page_num < max_number_page; page_num += 1)
                {
                    pagination_page.Add(page_num * maximum_page);
                }
            }
            //if last page 
            if ((page_count % maximum_page) != 0 && !is_only_one_page)
            {
                pagination_page.Add(pagination_page[pagination_page.Count - 1] + maximum_page);
            }
            ViewBag.Pagination = pagination_page;
            ViewBag.CurrentPage = start;
            ViewBag.MaximumPage = pagination_page.Max();
            #endregion

            return View(project);
        }

        public async Task<IActionResult> Project_Category(int categoryId, int start)
        {
            ViewBag.categoryId = categoryId;
            var category_name = await _db.Category_Projects.FirstOrDefaultAsync(cat => cat.Id == categoryId);
            ViewData["category"] = category_name;

            var project_cat = await _db.ProjectRefs
                 .AsNoTracking()
                 .Where(cat => cat.ProjectRef_CategoryId == categoryId)
                 .Skip(start)
                 .Take(start + 6)
                 .OrderByDescending(cat => cat.Id)
                 .Select(project =>
                 new Category_Project
                 {
                     Id = project.Id,
                     Image_Path = Path.Combine(project.Folder_Path, project.Profile_Image),
                     Name_EN = project.Title_TH,
                     Name_TH = project.Title_EN,
                 })
                 .ToListAsync();

            #region pagination
            var maximum_page = 6;
            var pagination_page = new List<int>();
            var page_count = _db.ProjectRefs.Where(cat => cat.ProjectRef_CategoryId == categoryId).ToList().Count;
            var is_only_one_page = false;
            if (page_count <= maximum_page)
            {
                pagination_page.Add(0);
                is_only_one_page = true;
            }
            else
            {
                var max_number_page = (int)(page_count / maximum_page);
                for (int page_num = 0; page_num < max_number_page; page_num += 1)
                {
                    pagination_page.Add(page_num * maximum_page);
                }
            }
            //if last page 
            if ((page_count % maximum_page) != 0 && !is_only_one_page)
            {
                pagination_page.Add(pagination_page[pagination_page.Count - 1] + maximum_page);
            }
            ViewBag.Pagination = pagination_page;
            ViewBag.CurrentPage = start;
            ViewBag.MaximumPage = pagination_page.Max();
            #endregion

            return View(project_cat);
        }

        public async Task<IActionResult> Project_Detail(int id)
        {
            var project = await _db.ProjectRefs.Include(project => project.ProjectRef_Category).Where(project => project.Id == id).ToListAsync();

            if (project != null)
            {
                ViewData["category"] = project.FirstOrDefault().ProjectRef_Category;
                var proj_output = project
                                .Select(proj => new Output_ProjectRefVM
                                {
                                    Id = proj.Id,
                                    //CategoryId = proj.CategoryId,
                                    Client = proj.Client,
                                    Content_EN = proj.Content_EN,
                                    Content_TH = proj.Content_TH,
                                    Design_Solution = proj.Design_Solution,
                                    //File_Download = Path.Combine(proj.Folder_Path, proj.File_Download),
                                    Image_List = GetFileName(new List<string> {/* proj.File_Download,*/ proj.Profile_Image }, proj.Folder_Path),
                                    Location_EN = proj.Location_EN,
                                    Location_TH = proj.Location_TH,
                                    Photo_Credit = proj.Photo_Credit,
                                    Title_EN = proj.Title_EN,
                                    Title_TH = proj.Title_TH,
                                    Profile_Image = Path.Combine(proj.Folder_Path, proj.Profile_Image),
                                     CategoryId = proj.ProjectRef_CategoryId
                                }).FirstOrDefault();

                 var project_product = await _db.ProjectRef_Products.AsNoTracking().Where(project => project.ProjectId == id).ToListAsync();
                if(project_product != null)
                {
                    var products = new List<Product>();
                    foreach( var product in project_product)
                    {
                        products.Add(await _db.Products.AsNoTracking()
                            .Where(pro => pro.Id == product.ProductId)
                            .Select(product => 
                            new Product { 
                                 Id = product.Id,
                             Preview_Image = Path.Combine("upload_image", "Product", product.Folder_Path,product.Preview_Image),
                              Product_CategoryId = product.Product_CategoryId,
                               Product_ModelId = product.Product_ModelId,
                             })
                            .FirstOrDefaultAsync());
                    }
                    if(products.Count > 0) {
                        ViewBag.CategoryId = products.First().Product_CategoryId;
                        ViewBag.SubCategoryId = products.First().Product_ModelId;

                        ViewData["products"] = products;

                    }

                    ViewData["categorys"] = await _db.ProjectRefs
                    .AsNoTracking()
                    .Where(proj => proj.ProjectRef_CategoryId == proj_output.CategoryId)
                    .OrderByDescending(proj => proj.Id)
                    .Select(pro =>
                    new ProjectRef
                    {
                        Profile_Image = Path.Combine(pro.Folder_Path, pro.Profile_Image),
                        Location_EN = pro.Location_EN,
                        Location_TH = pro.Location_TH,
                        Title_EN = pro.Title_EN,
                        Title_TH = pro.Title_TH,
                        Id = pro.Id
                    })
                    //.Take(10)
                    .ToListAsync();

                }
               

                return View(proj_output);
            }

            return Content("ไม่พบโปรเจค");
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
