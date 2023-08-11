using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Download;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Frontend
{
    public class DownloadController : Controller
    {
        readonly private LightingContext _db;
        readonly private IWebHostEnvironment _env;
        public DownloadController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Download()
        {
            return View();
        }

        public async Task<IActionResult> CATALOGUE_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType_id == 2).ToList().Count;
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
            if (page_count % maximum_page != 0 && !is_only_one_page)
            {
                pagination_page.Add(pagination_page[pagination_page.Count - 1] + maximum_page);
            }
            ViewBag.Pagination = pagination_page;
            ViewBag.CurrentPage = start;
            ViewBag.MaximumPage = pagination_page.Max();
            #endregion

            var download_list = await _db.Downloads
                .AsNoTracking()
                .Where(download => download.DownloadType_id == 2)
                .OrderByDescending(by => by.id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            //var output = download_list.Select(download => new Output_DownloadVM
            //{
            //    id = download.id,
            //    Name_EN = download.Name_EN,
            //    Name_TH = download.Name_TH,
            //    upload_image = download.upload_image,
            //    upload_image_ENG = download.upload_image_ENG,
            //    file_name = download.file_name,
            //    file_name_ENG = download.file_name_ENG,
            //    L_AND_BIM_Link = download.L_AND_BIM_Link
            //});

            ViewBag.Head = await _db.DownloadHeads.ToListAsync();
            ViewBag.TitleMenu = await _db.DownloadTypes.ToListAsync(); 
            ViewBag.Content = download_list;

            return View();
        }
        public async Task<IActionResult> COMPANY_PROFILE_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType_id == 3).ToList().Count;
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
            if (page_count % maximum_page != 0 && !is_only_one_page)
            {
                pagination_page.Add(pagination_page[pagination_page.Count - 1] + maximum_page);
            }
            ViewBag.Pagination = pagination_page;
            ViewBag.CurrentPage = start;
            ViewBag.MaximumPage = pagination_page.Max();
            #endregion

            var download_list = await _db.Downloads
                .AsNoTracking()
                .Where(download => download.DownloadType_id == 3)
                .OrderByDescending(by => by.id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            //var output = download_list.Select(download => new Output_DownloadVM
            //{
            //    id = download.id,
            //    Name_EN = download.Name_EN,
            //    Name_TH = download.Name_TH,
            //    upload_image = download.upload_image,
            //    upload_image_ENG = download.upload_image_ENG,
            //    file_name = download.file_name,
            //    file_name_ENG = download.file_name_ENG,
            //    L_AND_BIM_Link = download.L_AND_BIM_Link
            //});

            ViewBag.Head = await _db.DownloadHeads.ToListAsync();
            ViewBag.TitleMenu = await _db.DownloadTypes.ToListAsync();
            ViewBag.Content = download_list;

            return View();
        }
        public async Task<IActionResult> IES_FILE_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType_id == 4).ToList().Count;
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
            if (page_count % maximum_page != 0 && !is_only_one_page)
            {
                pagination_page.Add(pagination_page[pagination_page.Count - 1] + maximum_page);
            }
            ViewBag.Pagination = pagination_page;
            ViewBag.CurrentPage = start;
            ViewBag.MaximumPage = pagination_page.Max();
            #endregion

            var download_list = await _db.Downloads
                .AsNoTracking()
                .Where(download => download.DownloadType_id == 4)
                .OrderByDescending(by => by.id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            //var output = download_list.Select(download => new Output_DownloadVM
            //{
            //    id = download.id,
            //    Name_EN = download.Name_EN,
            //    Name_TH = download.Name_TH,
            //    upload_image = download.upload_image,
            //    upload_image_ENG = download.upload_image_ENG,
            //    file_name = download.file_name,
            //    file_name_ENG = download.file_name_ENG,
            //    L_AND_BIM_Link = download.L_AND_BIM_Link
            //});

            ViewBag.Head = await _db.DownloadHeads.ToListAsync();
            ViewBag.TitleMenu = await _db.DownloadTypes.ToListAsync();
            ViewBag.Content = download_list;

            return View();
        }
        public async Task<IActionResult> L_AND_BIM_OBJECT_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType_id == 1).ToList().Count;
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
            if (page_count % maximum_page != 0 && !is_only_one_page)
            {
                pagination_page.Add(pagination_page[pagination_page.Count - 1] + maximum_page);
            }
            ViewBag.Pagination = pagination_page;
            ViewBag.CurrentPage = start;
            ViewBag.MaximumPage = pagination_page.Max();
            #endregion

            var download_list = await _db.Downloads
                .AsNoTracking()
                .Where(download => download.DownloadType_id == 1)
                .OrderByDescending(by => by.id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            //var output = download_list.Select(download => new Output_DownloadVM
            //{
            //    id = download.id,
            //    Name_EN = download.Name_EN,
            //    Name_TH = download.Name_TH,
            //    upload_image = download.upload_image,
            //    upload_image_ENG = download.upload_image_ENG,
            //    file_name = download.file_name,
            //    file_name_ENG = download.file_name_ENG,
            //    L_AND_BIM_Link = download.L_AND_BIM_Link
            //});

            ViewBag.Head = await _db.DownloadHeads.ToListAsync();
            ViewBag.TitleMenu = await _db.DownloadTypes.ToListAsync();
            ViewBag.Content = download_list;

            return View();
        }
        public async Task<IActionResult> LEAFLET_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType_id == 5).ToList().Count;
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
            if (page_count % maximum_page != 0 && !is_only_one_page)
            {
                pagination_page.Add(pagination_page[pagination_page.Count - 1] + maximum_page);
            }
            ViewBag.Pagination = pagination_page;
            ViewBag.CurrentPage = start;
            ViewBag.MaximumPage = pagination_page.Max();
            #endregion

            var download_list = await _db.Downloads
                .AsNoTracking()
                .Where(download => download.DownloadType_id == 5)
                .OrderByDescending(by => by.id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            //var output = download_list.Select(download => new Output_DownloadVM
            //{
            //    id = download.id,
            //    Name_EN = download.Name_EN,
            //    Name_TH = download.Name_TH,
            //    upload_image = download.upload_image,
            //    upload_image_ENG = download.upload_image_ENG,
            //    file_name = download.file_name,
            //    file_name_ENG = download.file_name_ENG,
            //    L_AND_BIM_Link = download.L_AND_BIM_Link
            //}); 

            ViewBag.Head = await _db.DownloadHeads.ToListAsync();
            ViewBag.TitleMenu = await _db.DownloadTypes.ToListAsync();
            ViewBag.Content = download_list;

            return View();
        }
         
    }
}
