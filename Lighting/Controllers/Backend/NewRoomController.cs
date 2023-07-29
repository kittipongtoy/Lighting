using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class NewRoomController : Controller
	{
		private readonly LightingContext _context;
		private readonly ILogger<NewRoomController> _logger;
		private IWebHostEnvironment _hostEnvironment;

		public NewRoomController(ILogger<NewRoomController> logger, LightingContext lightingContext, IWebHostEnvironment hostEnvironment)
		{ 
			_logger = logger;
			_context = lightingContext;
			_hostEnvironment = hostEnvironment;
		}

		public IActionResult Stock_Market_Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> DataTable_Stock_Market()
		{
			try
			{
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_Stock_MarketResponse>();
                var IR_Stock_Market = await _context.IR_Stock_Market.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Stock_Market)
                {
                    list.Add(new ResponseDTO.IR_Stock_MarketResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        SubTitle_TH = item.SubTitle_TH == null ? "" : item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN == null ? "" : item.SubTitle_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue) ||
                           x.SubTitle_EN.Contains(searchValue) ||
                           x.SubTitle_TH.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
			catch (Exception error)
			{
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
		}

        public IActionResult Stock_Market_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Stock_Market_Add_Submit(RequestDTO.Stock_MarketRequest model)
        {
            try
            {
                IR_Stock_Market iR_Stock_Market = new IR_Stock_Market();
                iR_Stock_Market.Title_EN = model.Title_EN;
                iR_Stock_Market.Title_TH = model.Title_TH;
                iR_Stock_Market.SubTitle_EN = model.SubTitle_EN;
                iR_Stock_Market.SubTitle_TH = model.SubTitle_TH;
                iR_Stock_Market.Status = model.Status;
                iR_Stock_Market.updated_at = DateTime.Now;
                iR_Stock_Market.created_at = DateTime.Now;
                _context.IR_Stock_Market.Add(iR_Stock_Market);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Stock_Market_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetStock_Market(int? Id)
        {
            try
            {
                var DB = await _context.IR_Stock_Market.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Stock_Market_Edit_Submit(RequestDTO.Stock_MarketRequest model)
        {
            try
            {
                var iR_Stock_Market = _context.IR_Stock_Market.FirstOrDefault(x => x.Id == model.Id);
                if (iR_Stock_Market is not null)
                {
                    iR_Stock_Market.Title_EN = model.Title_EN;
                    iR_Stock_Market.Title_TH = model.Title_TH;
                    iR_Stock_Market.SubTitle_EN = model.SubTitle_EN;
                    iR_Stock_Market.SubTitle_TH = model.SubTitle_TH;
                    iR_Stock_Market.Status = model.Status;
                    iR_Stock_Market.updated_at = DateTime.Now;
                    _context.Entry(iR_Stock_Market).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Stock_Market_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Stock_Market.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_Stock_Market.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Stock_Market_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Stock_Market.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DataTable_IR_NewDetail()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_NewDetailResponse>();
                var IR_NewDetail = await _context.IR_NewDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_NewDetail)
                {
                    list.Add(new ResponseDTO.IR_NewDetailResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_NewDetail_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> IR_NewDetail_Add_Submit(RequestDTO.IR_NewDetailRequest model)
        {
            IR_NewDetail iR_NewDetail = new IR_NewDetail();
            try
            {
                foreach (var formFile in model.uploaded_fileTH)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_NewDetail.FileName_TH = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in model.uploaded_fileEN)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_NewDetail.FileName_EN = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                iR_NewDetail.Title_TH = model.Title_TH;
                iR_NewDetail.Title_EN = model.Title_EN;
                if (model.NewDate is not null)
                { 
                    iR_NewDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                }
                iR_NewDetail.Detail_TH = model.Detail_TH;
                iR_NewDetail.Detail_EN = model.Detail_EN;
                iR_NewDetail.Status = model.Status;
                iR_NewDetail.created_at = DateTime.Now;
                iR_NewDetail.updated_at = DateTime.Now;
                _context.IR_NewDetail.Add(iR_NewDetail);
                await _context.SaveChangesAsync();

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                if (iR_NewDetail.FileName_TH is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + iR_NewDetail.FileName_TH);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }

                if (iR_NewDetail.FileName_EN is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + iR_NewDetail.FileName_EN);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_NewDetail_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetIR_NewDetail(int? Id)
        {
            try
            {
                var DB = await _context.IR_NewDetail.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> IR_NewDetail_Edit_Submit(RequestDTO.IR_NewDetailRequest model)
        {
            try
            {
                var iR_NewDetail = await _context.IR_NewDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (iR_NewDetail is not null)
                {
                    foreach (var formFile in model.uploaded_fileTH)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + iR_NewDetail.FileName_TH);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            iR_NewDetail.FileName_TH = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }

                    foreach (var formFile in model.uploaded_fileEN)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + iR_NewDetail.FileName_EN);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            iR_NewDetail.FileName_EN = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }

                    iR_NewDetail.Title_TH = model.Title_TH;
                    iR_NewDetail.Title_EN = model.Title_EN;
                    if (model.NewDate is not null)
                    {
                        iR_NewDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                    }
                    iR_NewDetail.Detail_TH = model.Detail_TH;
                    iR_NewDetail.Detail_EN = model.Detail_EN;
                    iR_NewDetail.Status = model.Status;
                    iR_NewDetail.updated_at = DateTime.Now;
                    _context.Entry(iR_NewDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> IR_NewDetail_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_NewDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + DB.FileName_EN);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    var old_filePatho = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + DB.FileName_TH);
                    if (System.IO.File.Exists(old_filePatho) == true)
                    {
                        System.IO.File.Delete(old_filePatho);
                    }

                    _context.IR_NewDetail.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> IR_NewDetail_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_NewDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Latest_News_Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> DataTable_Latest_News()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_Latest_NewsResponse>();
                var IR_Stock_Market = await _context.IR_Latest_News.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Stock_Market)
                {
                    list.Add(new ResponseDTO.IR_Latest_NewsResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        SubTitle_TH = item.SubTitle_TH == null ? "" : item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN == null ? "" : item.SubTitle_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue) ||
                           x.SubTitle_EN.Contains(searchValue) ||
                           x.SubTitle_TH.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Latest_News_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Latest_News_Add_Submit(RequestDTO.Latest_NewsRequest model)
        {
            try
            {
                IR_Latest_New IR_Latest_New = new IR_Latest_New();
                IR_Latest_New.Title_EN = model.Title_EN;
                IR_Latest_New.Title_TH = model.Title_TH;
                IR_Latest_New.SubTitle_EN = model.SubTitle_EN;
                IR_Latest_New.SubTitle_TH = model.SubTitle_TH;
                IR_Latest_New.Status = model.Status;
                IR_Latest_New.updated_at = DateTime.Now;
                IR_Latest_New.created_at = DateTime.Now;
                _context.IR_Latest_News.Add(IR_Latest_New);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Latest_News_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLatest_News(int? Id)
        {
            try
            {
                var DB = await _context.IR_Latest_News.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Latest_News_Edit_Submit(RequestDTO.Latest_NewsRequest model)
        {
            try
            {
                var IR_Latest_News = _context.IR_Latest_News.FirstOrDefault(x => x.Id == model.Id);
                if (IR_Latest_News is not null)
                {
                    IR_Latest_News.Title_EN = model.Title_EN;
                    IR_Latest_News.Title_TH = model.Title_TH;
                    IR_Latest_News.SubTitle_EN = model.SubTitle_EN;
                    IR_Latest_News.SubTitle_TH = model.SubTitle_TH;
                    IR_Latest_News.Status = model.Status;
                    IR_Latest_News.updated_at = DateTime.Now;
                    _context.Entry(IR_Latest_News).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Latest_News_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Latest_News.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_Latest_News.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Latest_News_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Latest_News.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DataTable_Latest_NewsDetail()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_Latest_NewsDetailResponse>();
                var IR_NewDetail = await _context.IR_Latest_NewDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_NewDetail)
                {
                    list.Add(new ResponseDTO.IR_Latest_NewsDetailResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Latest_NewsDetail_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Latest_NewsDetail_Add_Submit(RequestDTO.Last_NewsDetailRequest model)
        {
            try
            {
                IR_Latest_NewDetail iR_Latest_NewDetail = new IR_Latest_NewDetail();
                iR_Latest_NewDetail.Title_TH = model.Title_TH;
                iR_Latest_NewDetail.Title_EN = model.Title_EN;
                if (model.NewDate is not null)
                {
                    iR_Latest_NewDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                }
                iR_Latest_NewDetail.Detail_TH = model.Detail_TH;
                iR_Latest_NewDetail.Detail_EN = model.Detail_EN;
                iR_Latest_NewDetail.Status = model.Status;
                iR_Latest_NewDetail.created_at = DateTime.Now;
                iR_Latest_NewDetail.updated_at = DateTime.Now;
                _context.IR_Latest_NewDetail.Add(iR_Latest_NewDetail);
                await _context.SaveChangesAsync();

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Latest_NewsDetail_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLatest_NewsDetail(int? Id)
        {
            try
            {
                var DB = await _context.IR_Latest_NewDetail.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Latest_NewsDetail_EditSubmit(RequestDTO.IR_NewDetailRequest model)
        {
            try
            {
                var IR_Latest_NewDetail = await _context.IR_Latest_NewDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (IR_Latest_NewDetail is not null)
                {
                    IR_Latest_NewDetail.Title_TH = model.Title_TH;
                    IR_Latest_NewDetail.Title_EN = model.Title_EN;
                    if (model.NewDate is not null)
                    {
                        IR_Latest_NewDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                    }
                    IR_Latest_NewDetail.Detail_TH = model.Detail_TH;
                    IR_Latest_NewDetail.Detail_EN = model.Detail_EN;
                    IR_Latest_NewDetail.Status = model.Status;
                    IR_Latest_NewDetail.updated_at = DateTime.Now;
                    _context.Entry(IR_Latest_NewDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Latest_NewsDetail_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Latest_NewDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_Latest_NewDetail.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Latest_NewsDetail_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Latest_NewDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Mass_Media_Index() 
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> DataTable_Mass_Media()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_MassMediaResponse>();
                var IR_Stock_Market = await _context.IR_MassMedia.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Stock_Market)
                {
                    list.Add(new ResponseDTO.IR_MassMediaResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        SubTitle_TH = item.SubTitle_TH == null ? "" : item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN == null ? "" : item.SubTitle_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue) ||
                           x.SubTitle_EN.Contains(searchValue) ||
                           x.SubTitle_TH.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Mass_Media_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Mass_Media_Add_Submit(RequestDTO.Mass_MediaRequest model)
        {
            try
            {
                IR_MassMedia IR_MassMedia = new IR_MassMedia();
                IR_MassMedia.Title_EN = model.Title_EN;
                IR_MassMedia.Title_TH = model.Title_TH;
                IR_MassMedia.SubTitle_EN = model.SubTitle_EN;
                IR_MassMedia.SubTitle_TH = model.SubTitle_TH;
                IR_MassMedia.Status = model.Status;
                IR_MassMedia.updated_at = DateTime.Now;
                IR_MassMedia.created_at = DateTime.Now;
                _context.IR_MassMedia.Add(IR_MassMedia);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Mass_Media_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetMass_Media(int? Id)
        {
            try
            {
                var DB = await _context.IR_MassMedia.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Mass_Media_Edit_Submit(RequestDTO.Mass_MediaRequest model)
        {
            try
            {
                var IR_MassMedia = _context.IR_MassMedia.FirstOrDefault(x => x.Id == model.Id);
                if (IR_MassMedia is not null)
                {
                    IR_MassMedia.Title_EN = model.Title_EN;
                    IR_MassMedia.Title_TH = model.Title_TH;
                    IR_MassMedia.SubTitle_EN = model.SubTitle_EN;
                    IR_MassMedia.SubTitle_TH = model.SubTitle_TH;
                    IR_MassMedia.Status = model.Status;
                    IR_MassMedia.updated_at = DateTime.Now;
                    _context.Entry(IR_MassMedia).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Mass_Media_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_MassMedia.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_MassMedia.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Mass_Media_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_MassMedia.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DataTable_Mass_MediaDetail()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_Latest_NewsDetailResponse>();
                var IR_NewDetail = await _context.IR_MassMediaDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_NewDetail)
                {
                    list.Add(new ResponseDTO.IR_Latest_NewsDetailResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Mass_MediaDetail_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> Mass_MediaDetail_Add_Submit(RequestDTO.IR_Mass_MediaRequest model)
        {
            IR_MassMediaDetail IR_MassMediaDetail = new IR_MassMediaDetail();
            try
            {
                foreach (var formFile in model.uploaded_Image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        IR_MassMediaDetail.Image = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                IR_MassMediaDetail.Title_TH = model.Title_TH;
                IR_MassMediaDetail.Title_EN = model.Title_EN;
                if (model.NewDate is not null)
                {
                    IR_MassMediaDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                }
                IR_MassMediaDetail.Detail_TH = model.Detail_TH;
                IR_MassMediaDetail.Detail_EN = model.Detail_EN;
                IR_MassMediaDetail.Question_TH = model.Question_TH;
                IR_MassMediaDetail.Question_EN = model.Question_EN;
                IR_MassMediaDetail.ContactUs_Name1_TH = model.ContactUs_Name1_TH;
                IR_MassMediaDetail.ContactUs_Name1_EN = model.ContactUs_Name1_EN;
                IR_MassMediaDetail.ContactUs_Name2_TH = model.ContactUs_Name2_TH;
                IR_MassMediaDetail.ContactUs_Name2_EN = model.ContactUs_Name2_EN;
                IR_MassMediaDetail.ContactUs_Tel = model.ContactUs_Tel;
                IR_MassMediaDetail.ContactUs_Tel2 = model.ContactUs_Tel2;
                IR_MassMediaDetail.ContactUs_Mail1 = model.ContactUs_Mail1;
                IR_MassMediaDetail.ContactUs_Mail2 = model.ContactUs_Mail2;
                IR_MassMediaDetail.Status = model.Status;
                IR_MassMediaDetail.created_at = DateTime.Now;
                IR_MassMediaDetail.updated_at = DateTime.Now;
                _context.IR_MassMediaDetail.Add(IR_MassMediaDetail);
                await _context.SaveChangesAsync();

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                if (IR_MassMediaDetail.Image is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + IR_MassMediaDetail.Image);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Mass_MediaDetail_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetMass_MediaDetail(int? Id)
        {
            try
            {
                var DB = await _context.IR_MassMediaDetail.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> Mass_MediaDetail_EditSubmit(RequestDTO.IR_Mass_MediaRequest model)
        {
            try
            {
                var IR_MassMediaDetail = await _context.IR_MassMediaDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (IR_MassMediaDetail is not null)
                {
                    foreach (var formFile in model.uploaded_Image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + IR_MassMediaDetail.Image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            IR_MassMediaDetail.Image = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                    IR_MassMediaDetail.Title_TH = model.Title_TH;
                    IR_MassMediaDetail.Title_EN = model.Title_EN;
                    if (model.NewDate is not null)
                    {
                        IR_MassMediaDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                    }
                    IR_MassMediaDetail.Detail_TH = model.Detail_TH;
                    IR_MassMediaDetail.Detail_EN = model.Detail_EN;
                    IR_MassMediaDetail.Question_TH = model.Question_TH;
                    IR_MassMediaDetail.Question_EN = model.Question_EN;
                    IR_MassMediaDetail.ContactUs_Name1_TH = model.ContactUs_Name1_TH;
                    IR_MassMediaDetail.ContactUs_Name1_EN = model.ContactUs_Name1_EN;
                    IR_MassMediaDetail.ContactUs_Name2_TH = model.ContactUs_Name2_TH;
                    IR_MassMediaDetail.ContactUs_Name2_EN = model.ContactUs_Name2_EN;
                    IR_MassMediaDetail.ContactUs_Tel = model.ContactUs_Tel;
                    IR_MassMediaDetail.ContactUs_Tel2 = model.ContactUs_Tel2;
                    IR_MassMediaDetail.ContactUs_Mail1 = model.ContactUs_Mail1;
                    IR_MassMediaDetail.ContactUs_Mail2 = model.ContactUs_Mail2;
                    IR_MassMediaDetail.Status = model.Status;
                    IR_MassMediaDetail.updated_at = DateTime.Now;
                    _context.Entry(IR_MassMediaDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Mass_MediaDetail_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_MassMediaDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + DB.Image);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    _context.IR_MassMediaDetail.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Mass_MediaDetail_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_MassMediaDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Print_Media_Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> DataTable_Print_Media()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_Print_MediaResponse>();
                var IR_Print_Media = await _context.IR_Print_Media.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Print_Media)
                {
                    list.Add(new ResponseDTO.IR_Print_MediaResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        SubTitle_TH = item.SubTitle_TH == null ? "" : item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN == null ? "" : item.SubTitle_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue) ||
                           x.SubTitle_EN.Contains(searchValue) ||
                           x.SubTitle_TH.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Print_Media_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Print_Media_Add_Submit(RequestDTO.Print_MediaRequest model)
        {
            try
            {
                IR_Print_Media Print_Media = new IR_Print_Media();
                Print_Media.Title_EN = model.Title_EN;
                Print_Media.Title_TH = model.Title_TH;
                Print_Media.SubTitle_EN = model.SubTitle_EN;
                Print_Media.SubTitle_TH = model.SubTitle_TH;
                Print_Media.Status = model.Status;
                Print_Media.updated_at = DateTime.Now;
                Print_Media.created_at = DateTime.Now;
                _context.IR_Print_Media.Add(Print_Media);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Print_Media_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPrint_Media(int? Id)
        {
            try
            {
                var DB = await _context.IR_Print_Media.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Print_Media_Edit_Submit(RequestDTO.Print_MediaRequest model)
        {
            try
            {
                var IR_Print_Media = _context.IR_Print_Media.FirstOrDefault(x => x.Id == model.Id);
                if (IR_Print_Media is not null)
                {
                    IR_Print_Media.Title_EN = model.Title_EN;
                    IR_Print_Media.Title_TH = model.Title_TH;
                    IR_Print_Media.SubTitle_EN = model.SubTitle_EN;
                    IR_Print_Media.SubTitle_TH = model.SubTitle_TH;
                    IR_Print_Media.Status = model.Status;
                    IR_Print_Media.updated_at = DateTime.Now;
                    _context.Entry(IR_Print_Media).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Print_Media_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Print_Media.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_Print_Media.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Print_Media_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Print_Media.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DataTable_Print_MediaDetail()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_Print_MediaDetailResponse>();
                var IR_MassMediaDetail = await _context.IR_Print_MediaDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_MassMediaDetail)
                {
                    list.Add(new ResponseDTO.IR_Print_MediaDetailResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Print_MediaDetail_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> Print_MediaDetail_Add_Submit(RequestDTO.IR_Print_MedialDetailRequest model)
        {
            IR_Print_MediaDetail IR_Print_MediaDetail = new IR_Print_MediaDetail();
            try
            {
                foreach (var formFile in model.uploaded_Image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        IR_Print_MediaDetail.Image_Newssource = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in model.uploaded_fileTH)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        IR_Print_MediaDetail.FileNameTH = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in model.uploaded_fileEN)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        IR_Print_MediaDetail.FileNameEN = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                IR_Print_MediaDetail.Title_TH = model.Title_TH;
                IR_Print_MediaDetail.Title_EN = model.Title_EN;
                if (model.NewDate is not null)
                {
                    IR_Print_MediaDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                }

                IR_Print_MediaDetail.Status = model.Status;
                IR_Print_MediaDetail.created_at = DateTime.Now;
                IR_Print_MediaDetail.updated_at = DateTime.Now;
                _context.IR_Print_MediaDetail.Add(IR_Print_MediaDetail);
                await _context.SaveChangesAsync();

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                if (IR_Print_MediaDetail.Image_Newssource is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + IR_Print_MediaDetail.Image_Newssource);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }

                if (IR_Print_MediaDetail.FileNameTH is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + IR_Print_MediaDetail.FileNameTH);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }

                if (IR_Print_MediaDetail.FileNameEN is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + IR_Print_MediaDetail.FileNameEN);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Print_MediaDetail_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetPrint_MediaDetail(int? Id)
        {
            try
            {
                var DB = await _context.IR_Print_MediaDetail.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> Print_MediaDetail_EditSubmit(RequestDTO.IR_Print_MedialDetailRequest model)
        {
            try
            {
                var IR_Print_MediaDetail = await _context.IR_Print_MediaDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (IR_Print_MediaDetail is not null)
                {
                    foreach (var formFile in model.uploaded_Image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + IR_Print_MediaDetail.Image_Newssource);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            IR_Print_MediaDetail.Image_Newssource = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }

                    foreach (var formFile in model.uploaded_fileTH)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + IR_Print_MediaDetail.FileNameTH);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            IR_Print_MediaDetail.FileNameTH = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }

                    foreach (var formFile in model.uploaded_fileEN)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + IR_Print_MediaDetail.FileNameEN);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            IR_Print_MediaDetail.FileNameEN = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                    IR_Print_MediaDetail.Title_TH = model.Title_TH;
                    IR_Print_MediaDetail.Title_EN = model.Title_EN;
                    if (model.NewDate is not null)
                    {
                        IR_Print_MediaDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                    }
                    IR_Print_MediaDetail.Status = model.Status;
                    IR_Print_MediaDetail.updated_at = DateTime.Now;
                    _context.Entry(IR_Print_MediaDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Print_MediaDetail_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Print_MediaDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_NewRoom/" + DB.Image_Newssource);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    var old_filePath2 = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + DB.FileNameTH);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }

                    var old_filePath3 = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + DB.FileNameEN);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }
                    _context.IR_Print_MediaDetail.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Print_MediaDetail_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Print_MediaDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult InvestorCalendar_Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> DataTable_InvestorCalendar()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_InvestorCalendarResponse>();
                var IR_Print_Media = await _context.IR_InvestorCalendar.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Print_Media)
                {
                    list.Add(new ResponseDTO.IR_InvestorCalendarResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        SubTitle_TH = item.SubTitle_TH == null ? "" : item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN == null ? "" : item.SubTitle_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue) ||
                           x.SubTitle_EN.Contains(searchValue) ||
                           x.SubTitle_TH.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult InvestorCalendar_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InvestorCalendar_Add_Submit(RequestDTO.InvestorCalendarRequest model)
        {
            try
            {
                IR_InvestorCalendar IR_InvestorCalendar = new IR_InvestorCalendar();
                IR_InvestorCalendar.Title_EN = model.Title_EN;
                IR_InvestorCalendar.Title_TH = model.Title_TH;
                IR_InvestorCalendar.SubTitle_EN = model.SubTitle_EN;
                IR_InvestorCalendar.SubTitle_TH = model.SubTitle_TH;
                IR_InvestorCalendar.Status = model.Status;
                IR_InvestorCalendar.updated_at = DateTime.Now;
                IR_InvestorCalendar.created_at = DateTime.Now;
                _context.IR_InvestorCalendar.Add(IR_InvestorCalendar);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult InvestorCalendar_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInvestorCalendar(int? Id)
        {
            try
            {
                var DB = await _context.IR_InvestorCalendar.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> InvestorCalendar_Edit_Submit(RequestDTO.InvestorCalendarRequest model)
        {
            try
            {
                var IR_InvestorCalendar = _context.IR_InvestorCalendar.FirstOrDefault(x => x.Id == model.Id);
                if (IR_InvestorCalendar is not null)
                {
                    IR_InvestorCalendar.Title_EN = model.Title_EN;
                    IR_InvestorCalendar.Title_TH = model.Title_TH;
                    IR_InvestorCalendar.SubTitle_EN = model.SubTitle_EN;
                    IR_InvestorCalendar.SubTitle_TH = model.SubTitle_TH;
                    IR_InvestorCalendar.Status = model.Status;
                    IR_InvestorCalendar.updated_at = DateTime.Now;
                    _context.Entry(IR_InvestorCalendar).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> InvestorCalendar_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_InvestorCalendar.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_InvestorCalendar.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InvestorCalendar_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_InvestorCalendar.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DataTable_InvestorCalendarDetail()
        {
            try
            {
                string? draw = Request.Form["draw"];
                string? start = Request.Form["start"];
                string? length = Request.Form["length"];
                string? sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
                string? sortColumnDirection = Request.Form["order[0][dir]"];
                string? searchValue = Request.Form["search[value]"];
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int? recordsTotal = 0;
                var list = new List<ResponseDTO.IR_InvestorCalendarDetailResponse>();
                var IR_MassMediaDetail = await _context.IR_InvestorCalendarDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_MassMediaDetail)
                {
                    list.Add(new ResponseDTO.IR_InvestorCalendarDetailResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Activity_TH == null ? "" : item.Activity_TH,
                        Title_EN = item.Activity_EN == null ? "" : item.Activity_EN,
                        Status = item.Status
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x =>
                           x.Title_TH.Contains(searchValue) ||
                           x.Title_EN.Contains(searchValue)
                           ).ToList();
                }

                recordsTotal = list.Count;
                list = list.Skip(skip).Take(pageSize).ToList();

                var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = list };
                return Ok(jsonData);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult InvestorCalendarDetail_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> InvestorCalendarDetail_Add_Submit(RequestDTO.InvestorCalendarDetailRequest model)
        {
            IR_InvestorCalendarDetail IR_InvestorCalendarDetail = new IR_InvestorCalendarDetail();
            try
            {
                foreach (var formFile in model.uploaded_fileTH)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        IR_InvestorCalendarDetail.FileNameTH = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                foreach (var formFile in model.uploaded_fileEN)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        IR_InvestorCalendarDetail.FileNameEN = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                IR_InvestorCalendarDetail.Activity_TH = model.Activity_TH;
                IR_InvestorCalendarDetail.Activity_EN = model.Activity_EN;
                IR_InvestorCalendarDetail.Position_EN = model.Position_EN;
                IR_InvestorCalendarDetail.Position_TH = model.Position_TH;
                if (model.NewDate is not null)
                {
                    IR_InvestorCalendarDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                }

                IR_InvestorCalendarDetail.Status = model.Status;
                IR_InvestorCalendarDetail.created_at = DateTime.Now;
                IR_InvestorCalendarDetail.updated_at = DateTime.Now;
                _context.IR_InvestorCalendarDetail.Add(IR_InvestorCalendarDetail);
                await _context.SaveChangesAsync();

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                if (IR_InvestorCalendarDetail.FileNameTH is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + IR_InvestorCalendarDetail.FileNameTH);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }

                if (IR_InvestorCalendarDetail.FileNameEN is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + IR_InvestorCalendarDetail.FileNameEN);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult InvestorCalendarDetail_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetInvestorCalendarDetail(int? Id)
        {
            try
            {
                var DB = await _context.IR_InvestorCalendarDetail.FirstOrDefaultAsync(x => x.Id == Id);
                if (DB is not null)
                {
                    return Ok(DB);
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> InvestorCalendarDetail_EditSubmit(RequestDTO.InvestorCalendarDetailRequest model)
        {
            try
            {
                var IR_InvestorCalendarDetail = await _context.IR_InvestorCalendarDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (IR_InvestorCalendarDetail is not null)
                {
                    foreach (var formFile in model.uploaded_fileTH)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + IR_InvestorCalendarDetail.FileNameTH);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            IR_InvestorCalendarDetail.FileNameTH = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }

                    foreach (var formFile in model.uploaded_fileEN)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + IR_InvestorCalendarDetail.FileNameEN);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            IR_InvestorCalendarDetail.FileNameEN = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                    IR_InvestorCalendarDetail.Activity_TH = model.Activity_TH;
                    IR_InvestorCalendarDetail.Activity_EN = model.Activity_EN;
                    IR_InvestorCalendarDetail.Position_TH = model.Position_TH;
                    IR_InvestorCalendarDetail.Position_EN = model.Position_EN;
                    if (model.NewDate is not null)
                    {
                        IR_InvestorCalendarDetail.NewDate = Convert.ToDateTime(model.NewDate, new CultureInfo("en-US"));
                    }
                    IR_InvestorCalendarDetail.Status = model.Status;
                    IR_InvestorCalendarDetail.updated_at = DateTime.Now;
                    _context.Entry(IR_InvestorCalendarDetail).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }

                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> InvestorCalendarDetail_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_InvestorCalendarDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    var old_filePath2 = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + DB.FileNameTH);
                    if (System.IO.File.Exists(old_filePath2) == true)
                    {
                        System.IO.File.Delete(old_filePath2);
                    }

                    var old_filePath3 = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + DB.FileNameEN);
                    if (System.IO.File.Exists(old_filePath3) == true)
                    {
                        System.IO.File.Delete(old_filePath3);
                    }
                    _context.IR_InvestorCalendarDetail.Remove(DB);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("ไม่มีข้อมูล");
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InvestorCalendarDetail_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_InvestorCalendarDetail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    if (DB.Status == 1)
                    {
                        DB.Status = 0;
                    }
                    else
                    {
                        DB.Status = 1;
                    }
                    _context.Entry(DB).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }
    }
}
