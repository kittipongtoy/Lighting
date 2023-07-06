using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;

namespace Lighting.Controllers.Backend
{
    //[Authorize]
    public class NewsController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public NewsController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        //show new feed
        public async Task<IActionResult> Index(int start = 0)
        {


            #region pagination
            var maximum_page = 6;
            var pagination_page = new List<int>();
            var page_count = _db.News.AsNoTracking().ToList().Count;
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

            var news_list = await _db.News.AsNoTracking().OrderByDescending(by => by.Id).Skip(start).Take(start > 0 ? maximum_page : start + maximum_page).ToListAsync();
            var output_news = new List<Output_NewsVm>();
            news_list.ForEach(news =>
            {
                output_news.Add(new Output_NewsVm
                {
                    Id = news.Id,
                    Content_TH = news.Content_TH,
                    Content_EN = news.Content_EN,
                    TitleImage = Path.Combine(news.ImagePath, "0.jpg"),
                    Title_TH = news.Title_TH,
                    Title_EN = news.Title_EN,
                    CreateDate_TH = news.CreateDate_TH,
                    CreateDate_EN = news.CreateDate_EN,
                    ImgList = Get_FileName(news.ImagePath)

                });
            });
            return View(output_news);
        }

        //manage
        public async Task<IActionResult> Manage_News_Page()
        {
            var news_list = await _db.News.AsNoTracking().OrderByDescending(by => by.Id).ToListAsync();
            var output_news = new List<Output_NewsVm>();
            news_list.ForEach(news =>
            {
                output_news.Add(new Output_NewsVm
                {
                    Id = news.Id,
                    Content_TH = news.Content_TH,
                    Content_EN = news.Content_EN,
                    TitleImage = Path.Combine(news.ImagePath, "0.jpg"),
                    Title_TH = news.Title_TH,
                    Title_EN = news.Title_EN,
                    CreateDate_TH = news.CreateDate_TH,
                    CreateDate_EN = news.CreateDate_EN,
                    ImgList = Get_FileName(news.ImagePath)

                });
            });
            return View(output_news);
        }

        public async Task<IActionResult> Delete_News(int id)
        {

            var news_delete = await _db.News.Where(news => news.Id == id).FirstOrDefaultAsync();
            if (news_delete != null)
            {
                try
                {
                    var delete_path = Path.Combine(_env.WebRootPath, news_delete.ImagePath);
                    if (Directory.Exists(delete_path))
                    {
                        Directory.Delete(delete_path, true);
                        _db.News.Remove(news_delete);
                        await _db.SaveChangesAsync();
                        return Json(new { status = "success", message = "ลบข้อมูลเรียบร้อย" });
                    }
                    else
                    {
                        return Json(new { status = "error", message = "ไม่พบไฟล์นี้" });
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }

            }
            return Json(new { status = "error", message = "ไม่พบข่าวนี้" });
        }

        public async Task<IActionResult> News_Detail_Page(int id)
        {
            var news = await _db.News.AsNoTracking().Where(news => news.Id.Equals(id)).FirstOrDefaultAsync();
            if (news != null)
            {
                var newsVM = new Output_NewsVm
                {
                    Id = news.Id,
                    Content_TH = news.Content_TH,
                    Content_EN = news.Content_EN,
                    TitleImage = Path.Combine(news.ImagePath, "0.jpg"),
                    Title_TH = news.Title_TH,
                    Title_EN = news.Title_EN,
                    CreateDate_TH = news.CreateDate_TH,
                    CreateDate_EN = news.CreateDate_EN,
                    ImgList = Get_FileName(news.ImagePath)
                };

                return View(newsVM);

            }
            return RedirectToAction("index");
        }
        public IActionResult Add_News_Page()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete_Img()
        {
            try
            {
                var path_file_name = Request.Form["path"];
                var root_path = _env.WebRootPath;
                var delete_file = Path.Combine(root_path, path_file_name);
                if (System.IO.File.Exists(delete_file))
                {
                    System.IO.File.Delete(delete_file);
                    return Json(new { status = "success", message = "ลบเรียบร้อย" });
                }
                return Json(new { status = "error", messagess = "ไม่พบไฟล์" });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", messagess = "เกิดข้อผิดพลาด" });
            }
        }
        public async Task<IActionResult> Edit_News_Page(int id)
        {
            var edit = await _db.News.FirstOrDefaultAsync(news => news.Id == id);
            if (edit != null)
            {
                var root_path = _env.WebRootPath;
                var output_edit_model = new Output_NewsVm
                {
                    Id = edit.Id,
                    Title_TH = edit.Title_TH,
                    Title_EN = edit.Title_EN,
                    Content_TH = edit.Content_TH,
                    Content_EN = edit.Content_EN,
                    CreateDate_TH = edit.CreateDate_TH,
                    CreateDate_EN = edit.CreateDate_EN,
                    TitleImage = Path.Combine(edit.ImagePath, "0.jpg"),
                    ImgList = Get_FileName(edit.ImagePath)

                };
                return View(output_edit_model);
            }
            return RedirectToAction("Manage_News");
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Input_NewsVm input_News, [FromQuery, Required] int id)
        {

            var edite = await _db.News.FirstOrDefaultAsync(news => news.Id.Equals(id));
            if (edite != null)
            {
                var root_path = _env.WebRootPath;
                var abs_path = Path.Combine(root_path, edite.ImagePath);
                if (input_News.TitleImage != null) //change img
                {
                    if (System.IO.File.Exists(Path.Combine(abs_path, "0.jpg")))
                    {
                        System.IO.File.Delete(Path.Combine(abs_path, "0.jpg"));
                        using (var stream = new FileStream(Path.Combine(abs_path, "0.jpg"), FileMode.Create))
                        {
                            await input_News.TitleImage.CopyToAsync(stream);
                        }
                    }
                }

                if (input_News.ImgList.Count > 0)//add image
                {
                    for (int index_file = 0; index_file < input_News.ImgList.Count; index_file++)
                    {
                        var new_name = Guid.NewGuid().ToString().Substring(0, 5);
                        using (var stream = new FileStream(Path.Combine(abs_path, new_name + ".jpg"), FileMode.Create))
                        {
                            await input_News.ImgList[index_file].CopyToAsync(stream);
                        }
                    }
                }
                edite.Title_TH = input_News.Title_TH;
                edite.Title_EN = input_News.Title_EN;
                edite.Content_TH = input_News.Content_TH;
                edite.Content_EN = input_News.Content_EN;
                edite.CreateDate_TH = input_News.CreateDate_TH;
                edite.CreateDate_EN = input_News.CreateDate_EN;

                await _db.SaveChangesAsync();
                return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
            }

            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }

        [HttpPost]
        public async Task<IActionResult> Add_News([FromForm] Input_NewsVm newsVm)
        {
            if (ModelState.IsValid)
            {
                var new_folder = Guid.NewGuid().ToString().Substring(0, 8);
                var root_path = _env.WebRootPath;
                var save_path = Path.Combine("upload_image", "news", new_folder);
                try
                {
                    #region check file type
                    //should save only .jpg and .png
                    //if (newsVm.TitleImage.Name.ToLower().EndsWith(".jpg") || newsVm.TitleImage.Name.ToLower().EndsWith(".png")) return Json(new { status = "error", message = "กรุณาใส่ รูปที่เป็น png jpg" });
                    //bool isAllValid = true;
                    //foreach (var file_img in newsVm.ImgList)
                    //{
                    //    if (file_img.Name.ToLower().EndsWith(".jpg") || file_img.Name.ToLower().EndsWith(".png"))
                    //    {

                    //    }
                    //    else
                    //    {
                    //        isAllValid = false;
                    //        break;
                    //    }
                    //}
                    #endregion

                    if (newsVm.TitleImage == null)
                    {
                        return Json(new { status = "error", message = "กรุณาใส่ รูปหัวข้อ" });
                    }


                    if (!System.IO.File.Exists(save_path))
                    {
                        System.IO.Directory.CreateDirectory(Path.Combine(root_path, save_path));
                        //title image
                        using (var stream = new FileStream(Path.Combine(root_path, save_path, "0.jpg"), FileMode.Create))
                        {
                            await newsVm.TitleImage.CopyToAsync(stream);
                        }

                        if (newsVm.ImgList.Count > 0)
                        {
                            for (int index = 0; index < newsVm.ImgList.Count; index++)
                            {
                                var new_file_name = Guid.NewGuid().ToString().Substring(0, 5);
                                using (var file_stream = new FileStream(Path.Combine(root_path, save_path, new_file_name + ".jpg"), FileMode.Create))
                                {
                                    await newsVm.ImgList[index].CopyToAsync(file_stream);
                                }
                            }
                        }

                        var news = new News
                        {
                            Title_EN = newsVm.Title_EN,
                            Title_TH = newsVm.Title_TH,
                            Content_TH = newsVm.Content_TH,
                            Content_EN = newsVm.Content_EN,
                            CreateDate_TH = newsVm.CreateDate_TH,
                            CreateDate_EN = newsVm.CreateDate_EN,
                            ImagePath = save_path
                        };
                        _db.News.Add(news);
                        await _db.SaveChangesAsync();

                        return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                    }
                }
                catch (Exception ex)
                {
                    System.IO.Directory.Delete(Path.Combine(root_path, save_path), true);
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }
            return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }

        private List<string> Get_FileName(string path)
        {
            return Directory.GetFiles(Path.Combine(_env.WebRootPath, path))
                    .Where(path => !path.EndsWith("0.jpg"))
                    .Select(path =>
                    {
                        var new_path = path.Split('\\').Reverse().Take(4).Reverse();
                        return string.Join("/", new_path);
                    })
                    .ToList();
        }
    }
}
