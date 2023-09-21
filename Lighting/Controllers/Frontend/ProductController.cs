﻿using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Product;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Lighting.Controllers.Frontend
{
    public class ProductController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public ProductController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        [HttpPost]
        public async Task<IActionResult> LoadProduct(int subcategoryId)
        {
            var lang = Request.Cookies["lang"];
            var category = await _db.Product_Categorys.AsNoTracking().ToListAsync();
            var subCategory = await _db.Product_Models.AsNoTracking().ToListAsync();
            var product = await _db.Products.AsNoTracking().Where(x => x.Product_ModelId == subcategoryId).ToListAsync();
           var p =  product.Select(x => new
            {
                Img = Path.Combine("upload_image", "Product", x.Folder_Path, x.Preview_Image),
                IPRating = x.IP_Rating,
                Power = x.Power,
                Name = x.Model,
                Dimention = x.Dimension,
                Category = (lang == "TH" ? category.FirstOrDefault(cat => cat.Id == x.Product_CategoryId)!.Name_TH: category.FirstOrDefault(cat => cat.Id == x.Product_CategoryId)!.Name_EN),
                SubCategory = (lang == "TH" ? subCategory.FirstOrDefault(sub => sub.Id == x.Product_ModelId)!.Name_TH : subCategory.FirstOrDefault(sub => sub.Id == x.Product_ModelId)!.Name_EN)
            });

            return Json(p);
        }
        [HttpPost]
        public async Task<IActionResult> NavBarSearchListJson()
        {
            var listCategory = new List<SearchList>();
            var lang = Request.Cookies["lang"];
            var categorys = await _db.Product_Categorys.AsNoTracking().ToListAsync();
            foreach (var category in categorys)
            {
                if(lang == "TH")
                {
                    listCategory.Add(new SearchList
                    {
                        CategoryName = category.Name_TH,
                        SubCategory = await _db.Product_Models.AsNoTracking().Where(x => x.Product_CategoryId == category.Id).Select(x => new SubCategory { Id = x.Id, Name = x.Name_TH }).ToListAsync()
                    });
                }
                else
                {
                    listCategory.Add(new SearchList
                    {
                        CategoryName = category.Name_EN,
                        SubCategory = await _db.Product_Models.AsNoTracking().Where(x => x.Product_CategoryId == category.Id)!.Select(x => new SubCategory { Id = x.Id, Name = x.Name_EN }).ToListAsync()
                    });
                }
            }
            return Json(listCategory);
        }
        public async Task<IActionResult> SearchJson(string search)

        {


            List<Search> searches = new List<Search>();
            Regex regex = new Regex(@"^[0-9]");

            if (search != null)
            {
                if (regex.Matches(search).Count > 0) //search watt
                {
                    var watts = await _db.Products.AsNoTracking().Where(product => product.Power.ToLower().StartsWith(search.ToLower())).ToListAsync();
                    foreach (var w in watts)
                    {
                        searches.Add(new Search
                        {
                            Category = _db.Product_Categorys.AsNoTracking().Where(cat => cat.Id == w.Product_CategoryId).FirstOrDefault()?.Name_EN,
                            Subcategory = _db.Product_Models.AsNoTracking().Where(product_Model => product_Model.Id == w.Product_ModelId).FirstOrDefault()?.Name_EN,
                            Product = w.Model
                        });
                    }
                }
                var model = await _db.Products.AsNoTracking().Where(product => product.Model.ToLower().Contains(search.ToLower())).ToListAsync();
                foreach (var m in model)
                {
                    searches.Add(new Search
                    {
                        Category = _db.Product_Categorys.AsNoTracking().Where(pro_cat => pro_cat.Id == m.Product_CategoryId)?.FirstOrDefault()?.Name_EN,
                        Subcategory = _db.Product_Models.AsNoTracking().Where(model => model.Id == m.Product_ModelId)?.FirstOrDefault()?.Name_EN,
                        Product = m.Model
                    });
                }
                var category = await _db.Product_Categorys.AsNoTracking().Where(cat => cat.Name_EN.ToLower().Contains(search.ToLower()) || cat.Name_TH.Contains(search)).ToListAsync();
                if (category.Count > 0) //search category
                {
                    foreach (var cat in category)
                    {
                        searches.Add(new Search
                        {
                            Category = cat.Name_EN
                        });
                    }
                }

                var model_or_subcategory = await _db.Product_Models.AsNoTracking().Where(cat => cat.Name_EN.ToLower().Contains(search.ToLower()) || cat.Name_TH.Contains(search)).ToListAsync();
                if (model_or_subcategory.Count > 0) //search category
                {
                    foreach (var model_or_subcat in model_or_subcategory)
                    {
                        searches.Add(new Search
                        {
                            Subcategory = model_or_subcat.Name_EN,
                            Category = _db.Product_Categorys.AsNoTracking().Where(pro_cat => pro_cat.Id == model_or_subcat.Product_CategoryId)?.FirstOrDefault()?.Name_EN,
                        });
                    }
                }
            }
            return Json(searches);

        }
        public async Task<IActionResult> JsonNavBar()
        {
            var lang = Request.Cookies["lang"];
            if (lang == "TH")
            {
                var category = await _db.Product_Categorys
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(cat =>
                new
                {
                    Id = cat.Id,
                    Name = cat.Name_TH,
                    Image = cat.Image
                })
                .ToListAsync();

                return Json(category);
                ;
            }
            else
            {
                var category = await _db.Product_Categorys
                    .AsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .Select(cat =>
                    new
                    {
                        Id = cat.Id,
                        Name = cat.Name_EN,
                        Image = cat.Image
                    })
                    .ToListAsync();

                return Json(category);
            }
        }
        public async Task<IActionResult> Product()
        {
            var category = await _db.Product_Categorys
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(cat =>
                new Output_ProductCategoryVM
                {
                    Id = cat.Id,
                    Name_EN = cat.Name_EN,
                    Name_TH = cat.Name_TH,
                    Image = cat.Image
                })
                .ToListAsync();
            return View(category);
        }

        public async Task<IActionResult> Product_Category(string category,int? ProductId)
        {
            if (category != null && category != "")
            {
                var allCategory = await _db.Product_Categorys
                             .AsNoTracking()
                             .OrderByDescending(x => x.Id)
                             .Select(cat =>
                             new Output_ProductCategoryVM
                             {
                                 Id = cat.Id,
                                 Name_EN = cat.Name_EN,
                                 Name_TH = cat.Name_TH,
                                 Image = cat.Image
                             })
                             .ToListAsync();
                var selected_category = await _db.Product_Categorys
                             .AsNoTracking()
                             .Where(product_cat => product_cat.Name_EN.ToLower().StartsWith(category.ToLower()) || product_cat.Name_TH.StartsWith(category)).FirstOrDefaultAsync();
                if (selected_category == null) return RedirectToAction("Product");
                var sub_category = await _db.Product_Models
                             .AsNoTracking()
                             //.Where(sub_cat => sub_cat.Name_EN.ToLower().StartsWith(category.ToLower()) || sub_cat.Name_TH.StartsWith(category))
                             .Where(pro_model => pro_model.Product_CategoryId == selected_category.Id)
                             .OrderByDescending(x => x.Id)
                             .Select(cat =>
                             new Output_ProductModelVM
                             {
                                 Id = cat.Id,
                                 Name_EN = cat.Name_EN,
                                 Name_TH = cat.Name_TH,
                                 Image = Path.Combine("upload_image", "Product_Model", cat.Image)
                             })
                             .ToListAsync();

                ViewData["All_Category"] = allCategory;
                ViewData["Sub_Category"] = sub_category;

                ViewBag.Category = category;
            }
            else 
            {
                var allCategory = await _db.Product_Categorys
                                .AsNoTracking()
                                .OrderByDescending(x => x.Id)
                                .Select(cat =>
                                new Output_ProductCategoryVM
                                {
                                    Id = cat.Id,
                                    Name_EN = cat.Name_EN,
                                    Name_TH = cat.Name_TH,
                                    Image = cat.Image
                                })
                                .ToListAsync();
                ViewData["All_Category"] = allCategory;

                var selected_category = await _db.Product_Categorys.FirstOrDefaultAsync(x=>x.Id == ProductId);

                if (selected_category == null) return RedirectToAction("Product");
                var sub_category = await _db.Product_Models
                             .AsNoTracking()
                             //.Where(sub_cat => sub_cat.Name_EN.ToLower().StartsWith(category.ToLower()) || sub_cat.Name_TH.StartsWith(category))
                             .Where(pro_model => pro_model.Product_CategoryId == selected_category.Id)
                             .OrderByDescending(x => x.Id)
                             .Select(cat =>
                             new Output_ProductModelVM
                             {
                                 Id = cat.Id,
                                 Name_EN = cat.Name_EN,
                                 Name_TH = cat.Name_TH,
                                 Image = Path.Combine("upload_image", "Product_Model", cat.Image)
                             })
                             .ToListAsync();

                
                ViewData["Sub_Category"] = sub_category;

                ViewBag.Category = selected_category.Name_EN;
            }
            return View();
        }

        public async Task<IActionResult> Product_Subcategory(string category, string sub_category, int start)
        {
            var allCategory = await _db.Product_Categorys
             .AsNoTracking()
             .OrderByDescending(x => x.Id)
             .Select(cat =>
             new Output_ProductCategoryVM
             {
                 Id = cat.Id,
                 Name_EN = cat.Name_EN,
                 Name_TH = cat.Name_TH,
                 Image = cat.Image
             })
             .ToListAsync();

            var allSub_category = await _db.Product_Models
                         .AsNoTracking()
                         //.Where(sub_cat => sub_cat.Product_CategoryId == categoryId)
                         .OrderByDescending(x => x.Id)
                         .Select(cat =>
                         new Output_ProductModelVM
                         {
                             Id = cat.Id,
                             Name_EN = cat.Name_EN,
                             Name_TH = cat.Name_TH,
                             Image = cat.Image
                         })
                         .ToListAsync();
            //var selected_category = allCategory.Where(cat => cat.Name_EN.ToLower().StartsWith(category.ToLower()) || cat.Name_TH.StartsWith(category)).FirstOrDefault();
            var selected_subCategory = allSub_category.Where(sub_cat => sub_cat.Name_EN.ToLower().StartsWith(sub_category.ToLower()) || sub_cat.Name_TH.StartsWith(sub_category)).FirstOrDefault();
            var product = await _db.Products
                .AsNoTracking()
                .Include(pro => pro.ProductSpect)
                .Where(pro => pro.Product_ModelId == selected_subCategory.Id)
                .OrderByDescending(x => x.Id)
                .Select(pro =>
                new Output_ProductVM
                {
                    Id = pro.Id,
                    Product_CategoryId = pro.Product_CategoryId,
                    Product_ModelId = pro.Product_ModelId,
                    Application = pro.Application,

                    Type_EN = pro.Type_EN,
                    Type_TH = pro.Type_TH,
                    MORE_INFORMATION = pro.MORE_INFORMATION,
                    Model = pro.Model,
                    //spect
                    IP_Rating = pro.IP_Rating,
                    Dimension = pro.Dimension,
                    Power = pro.Power,
                    Product_Spects = pro.ProductSpect.ToList(),
                    //Beam_Angle = pro.Beam_Angle,
                    //Control_Gear = pro.Control_Gear,
                    //Equivalent = pro.Equivalent,
                    //Finishing = pro.Finishing,
                    //Gasket = pro.Gasket,
                    //Housing = pro.Housing,
                    //Lamp_Colour = pro.Lamp_Colour,
                    //Lens = pro.Lens,
                    //Luminaire_Lifetime = pro.Luminaire_Lifetime,
                    //Mounting = pro.Mounting,
                    //Power_Supply = pro.Power_Supply,
                    //Source = pro.Source,
                    //Luminaire_Output = pro.Luminaire_Output,

                    Folder_Path = pro.Folder_Path,
                    CUTSHEET = pro.CUTSHEET == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.CUTSHEET),
                    CATALOGUE = pro.CATALOGUE == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.CATALOGUE),
                    IESFILE = pro.IESFILE == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.IESFILE),
                    Preview_Imamge = pro.Preview_Image == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.Preview_Image),

                })
                .ToListAsync();

            ViewData["All_Category"] = allCategory;
            ViewData["Sub_Category"] = allSub_category;

            ViewBag.Category = category;
            ViewBag.SubCategory = sub_category;

            #region pagination
            var maximum_page = 12;
            var pagination_page = new List<int>();
            var page_count = product.Count;
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
            return View(product);
        }

        public async Task<IActionResult> Product_Detail(string category, string sub_category, string model)
        {
            try
            {
                var all_category = await _db.Product_Categorys
                 .AsNoTracking()
                 .OrderByDescending(x => x.Id)
                 .Select(cat =>
                 new Output_ProductCategoryVM
                 {
                     Id = cat.Id,
                     Name_EN = cat.Name_EN,
                     Name_TH = cat.Name_TH,
                     Image = cat.Image
                 })
                 .ToListAsync();
                var current_category = all_category.Where(x => x.Name_EN.ToLower().StartsWith(category.ToLower()) || x.Name_TH.StartsWith(category)).FirstOrDefault();
                if (current_category == null) return NotFound();
                var all_sub_category = await _db.Product_Models
                             .AsNoTracking()
                             .Where(x => x.Product_CategoryId == current_category.Id)
                             .OrderByDescending(x => x.Id)
                             .Select(cat =>
                             new Output_ProductModelVM
                             {
                                 Id = cat.Id,
                                 Name_EN = cat.Name_EN,
                                 Name_TH = cat.Name_TH,
                                 Image = Path.Combine("upload_image", "Product_Model", cat.Image)
                             })
                             .ToListAsync();

                ViewData["All_Category"] = all_category;
                ViewData["Sub_Category"] = all_sub_category;

                ViewBag.Category = category;
                ViewBag.SubCategory = sub_category;

                var product = await _db.Products
                    .AsNoTracking()
                    .Include(pro => pro.ProductSpect)
                    .Where(pro => pro.Model.ToLower().StartsWith(model.ToLower()))
                    .Select(pro =>
                      new Output_ProductVM
                      {
                          Id = pro.Id,
                          Product_CategoryId = pro.Product_CategoryId,
                          Product_ModelId = pro.Product_ModelId,
                          Application = pro.Application,
                          MORE_INFORMATION = pro.MORE_INFORMATION,
                          Type_EN = pro.Type_EN,
                          Type_TH = pro.Type_TH,
                          Model = pro.Model,
                          //spect
                          Power = pro.Power,
                          Dimension = pro.Dimension,
                          IP_Rating = pro.IP_Rating,
                          Product_Spects = pro.ProductSpect.ToList(),
                          //Beam_Angle = pro.Beam_Angle,
                          //Control_Gear = pro.Control_Gear,
                          //Equivalent = pro.Equivalent,
                          //Finishing = pro.Finishing,
                          //Gasket = pro.Gasket,
                          //Housing = pro.Housing,
                          //Lamp_Colour = pro.Lamp_Colour,
                          //Lens = pro.Lens,
                          //Luminaire_Lifetime = pro.Luminaire_Lifetime,
                          //Mounting = pro.Mounting,
                          //Power_Supply = pro.Power_Supply,
                          //Source = pro.Source,
                          //Luminaire_Output = pro.Luminaire_Output,

                          Folder_Path = pro.Folder_Path,
                          CUTSHEET = pro.CUTSHEET == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.CUTSHEET),
                          CATALOGUE = pro.CATALOGUE == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.CATALOGUE),
                          RFA = pro.RFA == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.RFA),
                          IESFILE = pro.IESFILE == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.IESFILE),
                          Preview_Imamge = pro.Preview_Image == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.Preview_Image),
                          SUB_IMG = pro.SUB_IMG == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.SUB_IMG),

                      })
                    .FirstOrDefaultAsync();

                if (product != null)
                {
                    product.LIGHT_DISTRIBUTION = GET_FILE(Path.Combine("upload_image", "Product", product.Folder_Path, "technical_img"));
                    product.Technical_Drawing_Img = GET_FILE(Path.Combine("upload_image", "Product", product.Folder_Path, "light_ditribute_img"));

                    return View(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        private List<string> GET_FILE(string path)
        {
            try
            {
                return Directory.GetFiles(Path.Combine(_env.WebRootPath, path))
                    .Select(path =>
                    {
                        var arStr = path.Split("\\").Reverse().Take(5).Reverse();
                        return string.Join("/", arStr);
                    }).ToList();
            }
            catch (Exception ex)
            {
                return new List<string>();
            }

        }
    }

    class Search
    {
        public string? Product { get; set; }
        public string? Subcategory { get; set; }
        public string? Category { get; set; }
    }

    class SubCategory
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    class SearchList
    {
        public string CategoryName { get; set; }
        public List<SubCategory?> SubCategory { get; set; }
    }
}
