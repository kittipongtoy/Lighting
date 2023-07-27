using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                .Where(pro => pro.Product_ModelId == sub_categoryId)
                .OrderByDescending(x => x.Id)
                .Select(pro =>
                new Output_ProductVM
                {
                    Id = pro.Id,
                    Product_CategoryId = pro.Product_CategoryId,
                    Product_ModelId = pro.Product_ModelId,
                    Application = pro.Application,
                    Beam_Angle = pro.Beam_Angle,
                    Type_EN = pro.Type_EN,
                    Type_TH = pro.Type_TH,

                    Control_Gear = pro.Control_Gear,
                    Dimension = pro.Dimension,
                    Equivalent = pro.Equivalent,
                    Finishing = pro.Finishing,
                    Gasket = pro.Gasket,
                    Housing = pro.Housing,

                    IP_Rating = pro.IP_Rating,
                    Lamp_Colour = pro.Lamp_Colour,
                    Lens = pro.Lens,
                    Luminaire_Lifetime = pro.Luminaire_Lifetime,
                    Model = pro.Model,
                    Mounting = pro.Mounting,
                    MORE_INFORMATION = pro.MORE_INFORMATION,
                    Power = pro.Power,
                    Power_Supply = pro.Power_Supply,
                    Source = pro.Source,
                    Luminaire_Output = pro.Luminaire_Output,

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
                    .Where(pro => pro.Id == id)
                    .Select(pro =>
                      new Output_ProductVM
                      {
                          Id = pro.Id,
                          Product_CategoryId = pro.Product_CategoryId,
                          Product_ModelId = pro.Product_ModelId,
                          Application = pro.Application,
                          Beam_Angle = pro.Beam_Angle,
                          Type_EN = pro.Type_EN,
                          Type_TH = pro.Type_TH,

                          Control_Gear = pro.Control_Gear,
                          Dimension = pro.Dimension,
                          Equivalent = pro.Equivalent,
                          Finishing = pro.Finishing,
                          Gasket = pro.Gasket,
                          Housing = pro.Housing,

                          IP_Rating = pro.IP_Rating,
                          Lamp_Colour = pro.Lamp_Colour,
                          Lens = pro.Lens,
                          Luminaire_Lifetime = pro.Luminaire_Lifetime,
                          Model = pro.Model,
                          Mounting = pro.Mounting,
                          MORE_INFORMATION = pro.MORE_INFORMATION,
                          Power = pro.Power,
                          Power_Supply = pro.Power_Supply,
                          Source = pro.Source,
                          Luminaire_Output = pro.Luminaire_Output,

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
}
