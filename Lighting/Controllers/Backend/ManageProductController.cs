using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Xml.Linq;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class ManageProductController : Controller
    {

        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public ManageProductController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> SubcategoryJson(int categoryId)
        {
            var subcategory = await _db.Product_Models.AsNoTracking().Where(x => x.Product_CategoryId == categoryId).ToListAsync();
            return Json(subcategory);
        }
        public async Task<ActionResult> Add_Product_Page()
        {
            ViewData["category"] = await _db.Product_Categorys.ToListAsync();
            //ViewData["model"] = await _db.Product_Models.ToListAsync();
            return View();
        }

        public async Task<ActionResult> Edit_Product_Page(int id)
        {
            var path = Path.Combine("upload_image", "Product");
            var product = await _db.Products
                .Include(pro => pro.ProductSpect)
                .Where(pro => pro.Id == id)
                .Select(pro =>
                new Output_ProductVM
                {
                    Id = pro.Id,
                    Product_CategoryId = pro.Product_CategoryId,
                    Product_ModelId = pro.Product_ModelId,
                    Application = pro.Application,

                    Type_EN = pro.Type_EN,
                    Type_TH = pro.Type_TH,
                    Model = pro.Model,
                    MORE_INFORMATION = pro.MORE_INFORMATION,

                    Product_Spects = pro.ProductSpect.ToList(),
                    //spect
                    IP_Rating = pro.IP_Rating,
                    Dimension = pro.Dimension,
                    Power = pro.Power,

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
                    CUTSHEET = pro.CUTSHEET == null ? null : Path.Combine(path, pro.Folder_Path, pro.CUTSHEET),
                    CATALOGUE = pro.CATALOGUE == null ? null : Path.Combine(path, pro.Folder_Path, pro.CATALOGUE),
                    IESFILE = pro.IESFILE == null ? null : Path.Combine(path, pro.Folder_Path, pro.IESFILE),
                    RFA = pro.RFA == null ? null : Path.Combine(path, pro.Folder_Path, pro.RFA),
                    Preview_Imamge = pro.Preview_Image == null ? null : Path.Combine(path, pro.Folder_Path, pro.Preview_Image),
                    SUB_IMG = pro.SUB_IMG == null ? null : Path.Combine(path, pro.Folder_Path, pro.SUB_IMG),

                }).FirstOrDefaultAsync();

            if (product != null)
            {
                product.Technical_Drawing_Img = GET_FILE(Path.Combine(path, product.Folder_Path, "technical_img"));
                product.LIGHT_DISTRIBUTION = GET_FILE(Path.Combine(path, product.Folder_Path, "light_ditribute_img"));

                ViewData["category"] = await _db.Product_Categorys.ToListAsync();
                ViewData["model"] = await _db.Product_Models.ToListAsync();

                return View(product);
            }
            return NotFound("product not found");
        }

        [HttpPost]
        public async Task<IActionResult> Edit_CategoryById([FromForm] Input_ProductCategoryVM input, [FromQuery] int id)
        {
            var category = await _db.Product_Categorys.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category != null)
            {
                try
                {
                    if (input.Image != null)
                    {
                        var path_old_path = Path.Combine(_env.WebRootPath, category.Image);
                        if (System.IO.File.Exists(path_old_path))
                        {
                            System.IO.File.Delete(path_old_path);
                        }
                        var image_name = Guid.NewGuid().ToString().Substring(0, 6) + ".jpg";
                        var path = Path.Combine("upload_image", "Product_Category", image_name);
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path), FileMode.Create))
                        {
                            await input.Image.CopyToAsync(stream);
                        }
                        category.Image = path;

                    }
                    category.Name_TH = input.Name_TH;
                    category.Name_EN = input.Name_EN;

                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "faile", message = "เกิดข้อผอดพลาด:"+ex.Message });
                }

            }
            return Json(new { status = "faile", message = "ไม่พบข้อมูล" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete_CategoryById(int id)
        {
            var category = await _db.Product_Categorys.FirstOrDefaultAsync(cat => cat.Id == id);
            if (category != null)
            {
                try
                {
                    var delete_file = Path.Combine(_env.WebRootPath, category.Image);
                    if (System.IO.File.Exists(delete_file))
                    {
                        System.IO.File.Delete(delete_file);
                    }
                    _db.Product_Categorys.Remove(category);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "faile", message = "เกิดข้อผิดพลาด" });
                }
            }
            return Json(new { status = "faile", message = "ไม่พบข้อมูล" });
        }

        [HttpPost]
        public async Task<IActionResult> Add_Category([FromForm] Input_ProductCategoryVM input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var image_name = Guid.NewGuid().ToString().Substring(0, 6) + ".jpg";
                    var path = Path.Combine("upload_image", "Product_Category", image_name);
                    if (input.Image != null)
                    {
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path), FileMode.Create))
                        {
                            await input.Image.CopyToAsync(stream);
                        }
                    }
                    await _db
                        .Product_Categorys
                        .AddAsync(
                        new Product_Category
                        {
                            Name_EN = input.Name_EN,
                            Name_TH = input.Name_TH,
                            Image = input.Image == null ? "" : path
                        });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "fail", message = "เกิดข้อผิดพลาด" });
                }
            }
            return Json(new { status = "fail", message = "กรุณกรอกข้อมูลให้ครับ" });
        }

        public async Task<ActionResult> Manage_Category_Page()
        {
            var category = await _db.Product_Categorys
                .OrderByDescending(cat => cat.Id)
                .Select(cat =>
                new Output_ProductCategoryVM
                {
                    Id = cat.Id,
                    Name_EN = cat.Name_EN,
                    Name_TH = cat.Name_TH,
                    Image = cat.Image
                }).ToListAsync();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit_ModelById([FromForm] Input_ProductModelVM input, [FromQuery] int id)
        {
            var model = await _db.Product_Models.FirstOrDefaultAsync(cat => cat.Id == id);
            if (model != null)
            {
                try
                {
                    var new_file_img = Guid.NewGuid().ToString() + ".jpg";
                    if (input.Image != null)
                    {
                        var old_img_path = Path.Combine(_env.WebRootPath, "upload_image", "Product_Model", model.Image);
                        if (System.IO.File.Exists(old_img_path))
                        {
                            System.IO.File.Delete(old_img_path);
                        }
                        var new_img_path = Path.Combine(_env.WebRootPath, "upload_image", "Product_Model", new_file_img);
                        using (var stream = new FileStream(new_img_path, FileMode.Create))
                        {
                            await input.Image.CopyToAsync(stream);
                        }
                        model.Image = new_file_img;
                    }

                    model.Name_TH = input.Name_TH;
                    model.Name_EN = input.Name_EN;
                    model.Product_CategoryId = input.Product_CategoryId;

                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "faile", message = "ไม่พบข้อมูล :" + ex.Message });
                }
            }
            return Json(new { status = "faile", message = "ไม่พบข้อมูล" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete_ModelById(int id)
        {
            var model = await _db.Product_Models.FirstOrDefaultAsync(cat => cat.Id == id);
            if (model != null)
            {
                try
                {
                    var path_file = Path.Combine(_env.WebRootPath, "upload_image", "Product_Model", model.Image);
                    if (System.IO.File.Exists(path_file))
                    {
                        System.IO.File.Delete(path_file);
                    }
                    _db.Product_Models.Remove(model);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "faile", message = "เกิดข้อผิดพลาด " + ex.Message });
                }
            }
            return Json(new { status = "faile", message = "ไม่พบข้อมูล" });
        }

        [HttpPost]
        public async Task<IActionResult> Add_Model([FromForm] Input_ProductModelVM input)
        {
            if (ModelState.IsValid)
            {
                var img_name = Guid.NewGuid().ToString() + ".jpg";
                var path = Path.Combine("upload_image", "Product_Model", img_name);

                try
                {

                    if (input.Image != null)
                    {
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path), FileMode.Create))
                        {
                            await input.Image.CopyToAsync(stream);
                        }
                    }
                    await _db
                        .Product_Models
                        .AddAsync(
                        new Product_Model
                        {
                            Name_EN = input.Name_EN,
                            Name_TH = input.Name_TH,
                            Image = img_name,
                            Product_CategoryId = input.Product_CategoryId,
                        });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    var error_file_path = Path.Combine(_env.WebRootPath, path, img_name);
                    if (System.IO.File.Exists(error_file_path))
                    {
                        System.IO.File.Delete(error_file_path);
                    }
                    return Json(new { status = "fail", message = "เกิดข้อผิดพลาด" });
                }
            }
            return Json(new { status = "fail", message = "กรุณากรอกข้อมูลให้ครับ" });
        }
        public async Task<IActionResult> Manage_Model_Page()
        {
            var model = await _db.Product_Models
                .AsNoTracking()
                .OrderByDescending(model => model.Id)
                .Select(model => new Output_ProductModelVM
                {
                    Id = model.Id,
                    Name_EN = model.Name_EN,
                    Name_TH = model.Name_TH,
                    Product_CategoryId = model.Product_CategoryId,
                    Image = Path.Combine("upload_image", "Product_Model", model.Image)
                })
                .ToListAsync();
            ViewData["category"] = await _db.Product_Categorys.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add_Product([FromForm] Input_ProductVM input)
        {
            if (ModelState.IsValid)
            {
                var folder_name = Guid.NewGuid().ToString();
                var path = Path.Combine("upload_image", "Product", folder_name);
                var directory = Path.Combine(_env.WebRootPath, path);
                Directory.CreateDirectory(directory);

                var product = new Product();


                try
                {
                    var preview_img = Path.Combine(directory, input.Preview_Image.FileName);
                    using (var stream = new FileStream(preview_img, FileMode.Create))
                    {
                        await input.Preview_Image.CopyToAsync(stream);
                    }

                    if (input.SUB_IMG != null)
                    {
                        var sub_img = Path.Combine(_env.WebRootPath, path, input.SUB_IMG.FileName);
                        using (var stream = new FileStream(sub_img, FileMode.Create))
                        {
                            await input.SUB_IMG.CopyToAsync(stream);
                        }
                    }

                    if (input.CUTSHEET != null)
                    {
                        var cut_sheet = Path.Combine(_env.WebRootPath, path, input.CUTSHEET.FileName);
                        using (var stream = new FileStream(cut_sheet, FileMode.Create))
                        {
                            await input.CUTSHEET.CopyToAsync(stream);
                        }
                    }

                    if (input.IESFILE != null)
                    {
                        var ies_file = Path.Combine(_env.WebRootPath, path, input.IESFILE.FileName);
                        using (var stream = new FileStream(ies_file, FileMode.Create))
                        {
                            await input.IESFILE.CopyToAsync(stream);
                        }
                    }

                    if (input.CATALOGUE != null)
                    {
                        var catalogue = Path.Combine(_env.WebRootPath, path, input.CATALOGUE.FileName);
                        using (var stream = new FileStream(catalogue, FileMode.Create))
                        {
                            await input.CATALOGUE.CopyToAsync(stream);
                        }
                    }

                    if (input.RFA != null)
                    {
                        var rfa = Path.Combine(_env.WebRootPath, path, input.RFA.FileName);
                        using (var stream = new FileStream(rfa, FileMode.Create))
                        {
                            await input.RFA.CopyToAsync(stream);
                        }
                    }

                    if (input.Technical_Drawing_Img != null)
                    {
                        var folder = Path.Combine(_env.WebRootPath, path, "technical_img");
                        Directory.CreateDirectory(folder);
                        foreach (var tect_img in input.Technical_Drawing_Img)
                        {
                            var more_infor = Path.Combine(_env.WebRootPath, path, "technical_img", tect_img.FileName);
                            using (var stream = new FileStream(more_infor, FileMode.Create))
                            {
                                await tect_img.CopyToAsync(stream);
                            }
                        }
                    }

                    if (input.LIGHT_DISTRIBUTION != null)
                    {
                        var folder = Path.Combine(_env.WebRootPath, path, "light_ditribute_img");
                        Directory.CreateDirectory(folder);
                        foreach (var light_ditribute in input.LIGHT_DISTRIBUTION)
                        {
                            var more_infor = Path.Combine(_env.WebRootPath, path, "light_ditribute_img", light_ditribute.FileName);
                            using (var stream = new FileStream(more_infor, FileMode.Create))
                            {
                                await light_ditribute.CopyToAsync(stream);
                            }
                        }
                    }

                    product.Folder_Path = folder_name;
                    //file
                    product.Preview_Image = input.Preview_Image.FileName;
                    product.SUB_IMG = input.SUB_IMG?.FileName;
                    product.CUTSHEET = input.CUTSHEET?.FileName;
                    product.CATALOGUE = input.CATALOGUE?.FileName;
                    product.RFA = input.RFA?.FileName;
                    product.IESFILE = input.IESFILE?.FileName;
                    product.MORE_INFORMATION = input.MORE_INFORMATION;

                    product.Product_CategoryId = input.Product_CategoryId;
                    product.Product_ModelId = input.Product_ModelId;
                    product.Model = input.Model;
                    product.Type_EN = input.Type_EN;
                    product.Type_TH = input.Type_TH;
                    product.Application = input.Application;
                    //product.Technical_Drawing = input.Technical_Drawing;
                    product.Technical_Drawing_Img = Path.Combine(path, "technical_img");
                    product.LIGHT_DISTRIBUTION = Path.Combine(path, "light_ditribute_img");
                    //detail
                    product.IP_Rating = input.IP_Rating;
                    product.Power = input.Power;
                    product.Dimension = input.Dimension;

                    var product_spect = new List<Product_Spect>();
                    if (input.Spect_Name != null && input.Spect_Value != null)
                    {
                        for (int i = 0; i < input.Spect_Name.Count; i++)
                        {
                            product_spect.Add(new Product_Spect
                            {
                                Name = input.Spect_Name[i],
                                Value = input.Spect_Value[i]
                            });
                        }
                    }
                    product.ProductSpect = product_spect;
                    //product.Housing = input.Housing;
                    //product.Finishing = input.Finishing;
                    //product.Lens = input.Lens;
                    //product.Gasket = input.Gasket;
                    //product.Mounting = input.Mounting;
                    //product.Source = input.Source;
                    //product.Lamp_Colour = input.Lamp_Colour;
                    //product.Luminaire_Output = input.Luminaire_Output;
                    //product.Beam_Angle = input.Beam_Angle;
                    //product.Control_Gear = input.Control_Gear;
                    //product.Power_Supply = input.Power_Supply;
                    //product.Luminaire_Lifetime = input.Luminaire_Lifetime;
                    //product.Equivalent = input.Equivalent;

                    await _db.Products.AddAsync(product);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    Directory.Delete(directory, true);
                    return Json(new { status = "fail", message = "เกิดข้อผิดพลาด อาจมีชื่อไฟล์ซ้ำกัน" });
                }
            }
            return Json(new { status = "fail", message = "กรุณากรอกข้อมูลให้ครบ" });
        }
        [HttpPost]
        public async Task<IActionResult> EditSpect([FromQuery]int? id=null,string name="",string  value="")
        {
            if (id != null)
            {
                var product = await _db.Product_Spects.FirstOrDefaultAsync(x => x.Id == id);
                if (product != null)
                {
                    product.Name = name;
                    product.Value = value;
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
            }
            return Json(new { status = "fail", message = "ไม่พบข้อมูล" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete_ProductById(int id)
        {
            try
            {
                var product = await _db.Products.Include(pro => pro.ProductSpect).FirstOrDefaultAsync(pro => pro.Id == id);
                if (product != null)
                {
                    var path = Path.Combine(_env.WebRootPath, "upload_image", "Product", product.Folder_Path);
                    if (Directory.Exists(path))
                    {
                        Directory.Delete(path, true);
                    }
                    if (product.ProductSpect != null)
                    {
                        _db.Product_Spects.RemoveRange(product.ProductSpect);
                    }
                    await _db.SaveChangesAsync();
                    _db.Products.Remove(product);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                return Json(new { status = "fail", message = "ไม่พบข้อมูล" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "fail", message = "เกิดข้อผิดพลาด" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSpectById(int id)
        {
            var product_spect = await _db.Product_Spects.Where(pro => pro.Id == id).FirstOrDefaultAsync();
            if (product_spect != null)
            {
                _db.Product_Spects.Remove(product_spect);
                await _db.SaveChangesAsync();
                return Json(new { status = "success", message = "ลบมูลเรียบร้อย" });
            }
            return Json(new { status = "fail", message = "ไม่พบข้อมูล" });
        }
        [HttpPost]
        public async Task<IActionResult> Edit_Product([FromForm] Input_ProductVM input, [FromQuery] int id)
        {

            var product = await _db.Products.Include(pro => pro.ProductSpect).FirstOrDefaultAsync(pro => pro.Id == id);
            if (product != null)
            {

                var path = Path.Combine("upload_image", "Product", product.Folder_Path);
                var directory = Path.Combine(_env.WebRootPath, path);
                try
                {

                    if (input.Preview_Image != null)
                    {
                        var preview_img = Path.Combine(directory, input.Preview_Image.FileName);
                        if (product.Preview_Image != null)
                        {
                            var delete_file = Path.Combine(_env.WebRootPath, path, product.Preview_Image);
                            if (System.IO.File.Exists(delete_file))
                            {
                                System.IO.File.Delete(delete_file);
                            }
                        }

                        using (var stream = new FileStream(preview_img, FileMode.Create))
                        {
                            await input.Preview_Image.CopyToAsync(stream);
                        }
                    }

                    if (input.SUB_IMG != null)
                    {
                        var sub_img = Path.Combine(directory, input.SUB_IMG.FileName);
                        if (product.SUB_IMG != null)
                        {
                            var delete_file = Path.Combine(_env.WebRootPath, path, product.SUB_IMG);
                            if (System.IO.File.Exists(delete_file))
                            {
                                System.IO.File.Delete(delete_file);
                            }
                        }

                        using (var stream = new FileStream(sub_img, FileMode.Create))
                        {
                            await input.SUB_IMG.CopyToAsync(stream);
                        }
                    }

                    if (input.CUTSHEET != null)
                    {
                        if (product.CUTSHEET != null)
                        {
                            var delete_file = Path.Combine(_env.WebRootPath, path, product.CUTSHEET);
                            if (System.IO.File.Exists(delete_file))
                            {
                                System.IO.File.Delete(delete_file);
                            }
                        }

                        var cut_sheet = Path.Combine(_env.WebRootPath, path, input.CUTSHEET.FileName);
                        using (var stream = new FileStream(cut_sheet, FileMode.Create))
                        {
                            await input.CUTSHEET.CopyToAsync(stream);
                        }
                    }

                    if (input.IESFILE != null)
                    {
                        if (product.IESFILE != null)
                        {
                            var delete_file = Path.Combine(_env.WebRootPath, path, product.IESFILE);
                            if (System.IO.File.Exists(delete_file))
                            {
                                System.IO.File.Delete(delete_file);
                            }
                        }
                        var ies_file = Path.Combine(_env.WebRootPath, path, input.IESFILE.FileName);
                        using (var stream = new FileStream(ies_file, FileMode.Create))
                        {
                            await input.IESFILE.CopyToAsync(stream);
                        }
                    }

                    if (input.CATALOGUE != null)
                    {
                        if (product.CATALOGUE != null)
                        {
                            var delete_file = Path.Combine(path, product.CATALOGUE);
                            if (System.IO.File.Exists(delete_file))
                            {
                                System.IO.File.Delete(delete_file);
                            }
                        }
                        var catalogue = Path.Combine(_env.WebRootPath, path, input.CATALOGUE.FileName);
                        using (var stream = new FileStream(catalogue, FileMode.Create))
                        {
                            await input.CATALOGUE.CopyToAsync(stream);
                        }
                    }

                    if (input.RFA != null)
                    {
                        if (product.RFA != null)
                        {
                            var delete_file = Path.Combine(path, product.RFA);
                            if (System.IO.File.Exists(delete_file))
                            {
                                System.IO.File.Delete(delete_file);
                            }
                        }
                        var rfa = Path.Combine(_env.WebRootPath, path, input.RFA.FileName);
                        using (var stream = new FileStream(rfa, FileMode.Create))
                        {
                            await input.RFA.CopyToAsync(stream);
                        }
                    }

                    if (input.Technical_Drawing_Img != null)
                    {
                        var folder = Path.Combine(_env.WebRootPath, path, "technical_img");
                        if (Directory.Exists(folder))
                        {
                            Directory.Delete(folder, true);
                        }
                        Directory.CreateDirectory(folder);
                        foreach (var tect_img in input.Technical_Drawing_Img)
                        {
                            var more_infor = Path.Combine(_env.WebRootPath, path, "technical_img", tect_img.FileName);
                            using (var stream = new FileStream(more_infor, FileMode.Create))
                            {
                                await tect_img.CopyToAsync(stream);
                            }
                        }
                    }

                    if (input.LIGHT_DISTRIBUTION != null)
                    {
                        var folder = Path.Combine(_env.WebRootPath, path, "light_ditribute_img");
                        if (Directory.Exists(folder))
                        {
                            Directory.Delete(folder, true);
                        }
                        Directory.CreateDirectory(folder);
                        foreach (var light_ditribute in input.LIGHT_DISTRIBUTION)
                        {
                            var more_infor = Path.Combine(_env.WebRootPath, path, "light_ditribute_img", light_ditribute.FileName);
                            using (var stream = new FileStream(more_infor, FileMode.Create))
                            {
                                await light_ditribute.CopyToAsync(stream);
                            }
                        }
                    }

                    //product.Folder_Path = folder_name;
                    //file
                    product.Preview_Image = input.Preview_Image != null ? input.Preview_Image.FileName : product.Preview_Image;
                    product.SUB_IMG = input.SUB_IMG != null ? input.SUB_IMG.FileName : product.SUB_IMG;
                    product.CUTSHEET = input.CUTSHEET != null ? input.CUTSHEET.FileName : product.CUTSHEET;
                    product.CATALOGUE = input.CATALOGUE != null ? input.CATALOGUE.FileName : product.CATALOGUE;
                    product.RFA = input.RFA != null ? input.RFA.FileName : product.RFA;
                    product.IESFILE = input.IESFILE != null ? input.IESFILE.FileName : product.IESFILE;

                    product.MORE_INFORMATION = input.MORE_INFORMATION;

                    product.Product_CategoryId = input.Product_CategoryId;
                    product.Product_ModelId = input.Product_ModelId;
                    product.Model = input.Model;
                    product.Type_EN = input.Type_EN;
                    product.Type_TH = input.Type_TH;
                    product.Application = input.Application;

                    product.Technical_Drawing_Img = Path.Combine(path, "technical_img");
                    product.LIGHT_DISTRIBUTION = Path.Combine(path, "light_ditribute_img");
                    //detail
                    product.IP_Rating = input.IP_Rating;
                    product.Power = input.Power;
                    product.Dimension = input.Dimension;

                    var product_spect = new List<Product_Spect>();
                    if (input.Spect_Name != null && input.Spect_Value != null)
                    {
                        for (int i = 0; i < input.Spect_Name.Count; i++)
                        {
                            product_spect.Add(new Product_Spect
                            {
                                Name = input.Spect_Name[i],
                                Value = input.Spect_Value[i]
                            });
                        }
                    }
                    product.ProductSpect.AddRange(product_spect);
                    //product.Housing = input.Housing;
                    //product.Finishing = input.Finishing;
                    //product.Lens = input.Lens;
                    //product.Gasket = input.Gasket;
                    //product.Mounting = input.Mounting;
                    //product.Source = input.Source;
                    //product.Lamp_Colour = input.Lamp_Colour;
                    //product.Luminaire_Output = input.Luminaire_Output;
                    //product.Beam_Angle = input.Beam_Angle;
                    //product.Control_Gear = input.Control_Gear;
                    //product.Power_Supply = input.Power_Supply;
                    //product.Luminaire_Lifetime = input.Luminaire_Lifetime;
                    //product.Equivalent = input.Equivalent;

                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    //Directory.Delete(directory, true);
                    return Json(new { status = "fail", message = "เกิดข้อผิดพลาด อาจมีชื่อไฟล์ซ้ำกัน:" + ex.Message });
                }
            }
            return Json(new { status = "fail", message = "ไท่พบข้อมูล" });
        }
        public async Task<ActionResult> Manage_Product_Page()
        {
            var product = await _db.Products
                .OrderByDescending(cat => cat.Id)
                .Select(pro =>
                new Output_ProductVM
                {
                    Id = pro.Id,
                    Product_CategoryId = pro.Product_CategoryId,
                    Product_ModelId = pro.Product_ModelId,
                    Application = pro.Application,
                    Type_EN = pro.Type_EN,
                    Type_TH = pro.Type_TH,
                    Model = pro.Model,
                    MORE_INFORMATION = pro.MORE_INFORMATION,
                    //spect
                    Power = pro.Power,
                    Dimension = pro.Dimension,
                    IP_Rating = pro.IP_Rating,
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
                    SUB_IMG = pro.SUB_IMG == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.SUB_IMG),
                    IESFILE = pro.IESFILE == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.IESFILE),
                    Preview_Imamge = pro.Preview_Image == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.Preview_Image),

                })
                .ToListAsync();

            product.ForEach(productItem =>
            {
                productItem.Technical_Drawing_Img = GET_FILE(Path.Combine("upload_image", "Product", productItem.Folder_Path, "technical_img"));
                productItem.LIGHT_DISTRIBUTION = GET_FILE(Path.Combine("upload_image", "Product", productItem.Folder_Path, "light_ditribute_img"));
            });

            ViewData["category"] = await _db.Product_Categorys.ToListAsync();

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Search()
        {
            var product = await _db.Products
    .AsNoTracking()
    .OrderByDescending(cat => cat.Id)
    .Select(pro =>
    new
    {
        Id = pro.Id,
        Product_CategoryId = pro.Product_CategoryId,
        Product_ModelId = pro.Product_ModelId,
        Application = pro.Application,
        //Beam_Angle = pro.Beam_Angle,
        Type_EN = pro.Type_EN,
        Type_TH = pro.Type_TH,

        //Control_Gear = pro.Control_Gear,
        //Dimension = pro.Dimension,
        //Equivalent = pro.Equivalent,
        //Finishing = pro.Finishing,
        //Gasket = pro.Gasket,
        //Housing = pro.Housing,

        //IP_Rating = pro.IP_Rating,
        //Lamp_Colour = pro.Lamp_Colour,
        //Lens = pro.Lens,
        //Luminaire_Lifetime = pro.Luminaire_Lifetime,
        Model = pro.Model,
        //Mounting = pro.Mounting,
        //MORE_INFORMATION = pro.MORE_INFORMATION,
        Power = pro.Power,
        //Power_Supply = pro.Power_Supply,
        //Source = pro.Source,
        //Luminaire_Output = pro.Luminaire_Output,

        //Folder_Path = pro.Folder_Path,
        //CUTSHEET = pro.CUTSHEET == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.CUTSHEET),
        //CATALOGUE = pro.CATALOGUE == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.CATALOGUE),
        //IESFILE = pro.IESFILE == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.IESFILE),
        Preview_Imamge = pro.Preview_Image == null ? null : Path.Combine("upload_image", "Product", pro.Folder_Path, pro.Preview_Image),

    })
    .ToListAsync();
            return Json(product);
        }
        [AllowAnonymous]
        public IActionResult DwonloadFile(string? path)
        {
            if (path == null) return NotFound();
            var dowload_path = Path.Combine(_env.WebRootPath, path);
            if (System.IO.File.Exists(dowload_path))
            {
                byte[] file = System.IO.File.ReadAllBytes(dowload_path);
                return File(file, "text/plain", Path.GetFileName(dowload_path));
            }
            return NotFound();
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
                return new();
            }

        }
    }
}
