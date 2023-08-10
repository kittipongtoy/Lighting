using Microsoft.AspNetCore.Mvc;
using Lighting.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Lighting.Models.InputFilterModels.News;
using Lighting.Extension;

namespace Lighting.Controllers.Frontend
{
    public class NewController : Controller
    {

        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public NewController(LightingContext db, IWebHostEnvironment env)
        {
            _env = env;
            _db = db;
        }
        public async Task<IActionResult> New(int start = 0)
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

        public async Task<IActionResult> NewDetail(int id)
        {
            var news = await _db.News.AsNoTracking().Where(news => news.Id.Equals(id)).FirstOrDefaultAsync();
            if (news != null)
            {
                var newsVM = new Output_NewsVm
                {
                    Id = news.Id,
                    Content_TH =news.Content_TH,
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

        private List<string> Get_FileName(string path)
        {
            try
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
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        //private List<string> Get_FileName(string path)
        //{
        //    return Directory.GetFiles(Path.Combine(_env.WebRootPath, path))
        //            .Where(path => !path.EndsWith("0.jpg"))
        //            .Select(path =>
        //            {
        //                var new_path = path.Split('\\').Reverse().Take(4).Reverse();
        //                return string.Join("/", new_path);
        //            })
        //            .ToList();
        //}
    }
}
