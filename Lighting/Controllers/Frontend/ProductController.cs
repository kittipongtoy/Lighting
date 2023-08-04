using Lighting.Areas.Identity.Data;
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
                            CategoryId = w.Product_CategoryId,
                            SubcategoryId = w.Product_ModelId,
                            ProductId = w.Id
                        });
                    }
                }
                var model = await _db.Products.AsNoTracking().Where(product => product.Model.ToLower().Contains(search.ToLower())).ToListAsync();
                foreach (var m in model)
                {
                    searches.Add(new Search
                    {
                        CategoryId = m.Product_CategoryId,
                        SubcategoryId = m.Product_ModelId,
                        ProductId = m.Id
                    });
                }
                var category = await _db.Product_Categorys.AsNoTracking().Where(cat => cat.Name_EN.ToLower().Contains(search) || cat.Name_TH.Contains(search)).ToListAsync();
                if (category.Count > 0) //search category
                {
                    foreach (var cat in category)
                    {
                        searches.Add(new Search
                        {
                            CategoryId = cat.Id
                        });
                    }
                }

                var model_or_subcategory = await _db.Product_Models.AsNoTracking().Where(cat => cat.Name_EN.ToLower().Contains(search) || cat.Name_TH.ToLower().Contains(search)).ToListAsync();
                if (model_or_subcategory.Count > 0) //search category
                {
                    foreach (var model_or_subcat in model_or_subcategory)
                    {
                        searches.Add(new Search
                        {
                            SubcategoryId = model_or_subcat.Id,
                             CategoryId = model_or_subcat.Product_CategoryId
                        });
                    }
                }
            }
            return Json(searches);

        }
        public async Task<IActionResult> JsonNavBar()
        {
            var lang = Request.Cookies["lang"];
            if (lang == "EN"){
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
;            }
            else
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

        public async Task<IActionResult> Product_Category(int categoryId)
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

            var sub_category = await _db.Product_Models
                         .AsNoTracking()
                         .Where(sub_cat => sub_cat.Product_CategoryId == categoryId)
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

            ViewData["All_Category"] = category;
            ViewData["Sub_Category"] = sub_category;

            ViewBag.CategoryId = categoryId;

            return View();
        }

        public async Task<IActionResult> Product_Subcategory(int categoryId, int sub_categoryId, int start)
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

            var sub_category = await _db.Product_Models
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

            var product = await _db.Products
                .AsNoTracking()
                .Include(pro => pro.ProductSpect)
                .Where(pro => pro.Product_ModelId == sub_categoryId)
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

            ViewData["All_Category"] = category;
            ViewData["Sub_Category"] = sub_category;

            ViewBag.CategoryId = categoryId;
            ViewBag.SubCategoryId = sub_categoryId;

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

        public async Task<IActionResult> Product_Detail(int categoryId, int sub_categoryId, int id)
        {
            try
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

                var sub_category = await _db.Product_Models
                             .AsNoTracking()
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

                ViewData["All_Category"] = category;
                ViewData["Sub_Category"] = sub_category;

                ViewBag.CategoryId = categoryId;
                ViewBag.SubCategoryId = sub_categoryId;

                var product = await _db.Products
                    .AsNoTracking()
                    .Include(pro => pro.ProductSpect)
                    .Where(pro => pro.Id == id)
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

                if(product != null)
                {
                    product.LIGHT_DISTRIBUTION = GET_FILE(Path.Combine("upload_image", "Product", product.Folder_Path, "technical_img"));
                    product.Technical_Drawing_Img = GET_FILE(Path.Combine("upload_image", "Product", product.Folder_Path, "light_ditribute_img"));

                    return View(product);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound();
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
        public int? ProductId { get; set; }
        public int? SubcategoryId { get; set; }
        public int? CategoryId { get; set; }
    }
}
