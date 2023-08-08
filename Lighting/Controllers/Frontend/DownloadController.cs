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
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType == "CATALOGUE").ToList().Count;
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
                .Where(download => download.DownloadType == "CATALOGUE")
                .OrderByDescending(by => by.Id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            var output = download_list.Select(download => new Output_DownloadVM
            {
                Id = download.Id,
                Name_EN = download.Name_EN,
                Name_TH = download.Name_TH,
                File = GetFileName(download.File_Path),
                Image = download.File_Path + "/0.jpg",
                File_EN = GetFileName_EN(download.File_Path_EN),
                Image_EN = download.File_Path_EN + "/1.jpg",

            });


            return View(output);
        }
        public async Task<IActionResult> COMPANY_PROFILE_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType == "COMPANY PROFILE").ToList().Count;
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
                .Where(download => download.DownloadType == "COMPANY PROFILE")
                .OrderByDescending(by => by.Id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            var output = download_list.Select(download => new Output_DownloadVM
            {
                Id = download.Id,
                Name_EN = download.Name_EN,
                Name_TH = download.Name_TH,
                File = GetFileName(download.File_Path),
                Image = download.File_Path + "/0.jpg",
                File_EN = GetFileName_EN(download.File_Path_EN),
                Image_EN = download.File_Path_EN + "/1.jpg",
            });


            return View(output);
        }
        public async Task<IActionResult> IES_FILE_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType == "IES FILE").ToList().Count;
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
                .Where(download => download.DownloadType == "IES FILE")
                .OrderByDescending(by => by.Id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            var output = download_list.Select(download => new Output_DownloadVM
            {
                Id = download.Id,
                Name_EN = download.Name_EN,
                Name_TH = download.Name_TH,
                File = GetFileName(download.File_Path),
                Image = download.File_Path + "/0.jpg",
                File_EN = GetFileName_EN(download.File_Path_EN),
                Image_EN = download.File_Path_EN + "/1.jpg",
            });


            return View(output);
        }
        public async Task<IActionResult> L_AND_BIM_OBJECT_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType == "L&E BIM OBJECTS").ToList().Count;
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
                .Where(download => download.DownloadType == "L&E BIM OBJECTS")
                .OrderByDescending(by => by.Id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            var output = download_list.Select(download => new Output_DownloadVM
            {
                Id = download.Id,
                Name_EN = download.Name_EN,
                Name_TH = download.Name_TH,
                File = GetFileName(download.File_Path),
                Image = download.File_Path + "/0.jpg", 
                File_EN = GetFileName_EN(download.File_Path_EN),
                Image_EN = download.File_Path_EN + "/1.jpg",
                L_AND_BIM_Link = download.L_AND_BIM_Link
            });

            return View(output);
        }
        public async Task<IActionResult> LEAFLET_Page(int start)
        {
            #region pagination
            var maximum_page = 10;
            var pagination_page = new List<int>();
            var page_count = _db.Downloads.AsNoTracking().Where(download => download.DownloadType == "LEAFLET").ToList().Count;
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
                .Where(download => download.DownloadType == "LEAFLET")
                .OrderByDescending(by => by.Id)
                .Skip(start)
                .Take(start > 0 ? maximum_page : start + maximum_page)
                .ToListAsync();

            var output = download_list.Select(download => new Output_DownloadVM
            {
                Id = download.Id,
                Name_EN = download.Name_EN,
                Name_TH = download.Name_TH,
                File = GetFileName(download.File_Path),
                Image = download.File_Path + "/0.jpg",
                File_EN = GetFileName_EN(download.File_Path_EN),
                Image_EN = download.File_Path_EN + "/1.jpg",
            });


            return View(output);
        }

        private string? GetFileName(string path)
        {
            try
            {
                var path_folder = Path.Combine(_env.WebRootPath, path);
                if (Directory.Exists(path_folder))
                {
                    return Directory.GetFiles(path_folder)
                                         .Where(file => Path.GetFileName(file).StartsWith("00"))
                                         .FirstOrDefault()
                                         .Split("\\")
                                         .Reverse()
                                         .Take(4)
                                         .Reverse()
                                         .Aggregate("", (prev, curr) => prev + "/" + curr);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        } 
        private string? GetFileName_EN(string path)
        {
            try
            {
                var path_folder = Path.Combine(_env.WebRootPath, path);
                if (Directory.Exists(path_folder))
                {
                    return Directory.GetFiles(path_folder)
                                         .Where(file => Path.GetFileName(file).StartsWith("11"))
                                         .FirstOrDefault()
                                         .Split("\\")
                                         .Reverse()
                                         .Take(4)
                                         .Reverse()
                                         .Aggregate("", (prev, curr) => prev + "/" + curr);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }


    }
}
