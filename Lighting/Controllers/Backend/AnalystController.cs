using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class AnalystController : Controller
	{
        private readonly LightingContext _context;
        private readonly ILogger<NewRoomController> _logger;
        private IWebHostEnvironment _hostEnvironment;

        public AnalystController(ILogger<NewRoomController> logger, LightingContext context, IWebHostEnvironment hostEnvironment) 
        {
            _logger = logger;
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Analyst()
		{
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> Table_Analyst()
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
                var list = new List<ResponseDTO.IR_AnalystResponse>();
                var IR_Contact = await _context.IR_Analysts.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_AnalystResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        FileName_TH = item.FileName_TH,
                        FileName_EN = item.FileName_EN,
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
                           x.FileName_TH.Contains(searchValue) ||
                           x.FileName_EN.Contains(searchValue)
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

        public IActionResult Analyst_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> Analyst_Add_Submit(RequestDTO.IR_AnalystRequest model)
        {
            try
            {
                IR_Analyst iR_Analyst = new IR_Analyst();
                foreach (var formFile in model.uploaded_fileTH)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_Analyst.FileName_TH = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + datestr + extension);
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
                        iR_Analyst.FileName_EN = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                iR_Analyst.Status = model.Status;
                iR_Analyst.created_at = DateTime.Now;
                iR_Analyst.updated_at = DateTime.Now;
                _context.IR_Analysts.Add(iR_Analyst);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Analyst_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalyst_Edit(int? Id)
        {
            try
            {
                var DB = await _context.IR_Analysts.FirstOrDefaultAsync(x => x.Id == Id);
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
        public async Task<IActionResult> Analyst_Edit_Submit(RequestDTO.IR_AnalystRequest model)
        {
            try
            {
                var iR_Analyst = await _context.IR_Analysts.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (iR_Analyst != null)
                {
                    foreach (var formFile in model.uploaded_fileTH)
                    {
                        if (formFile.Length > 0)
                        {
                            if (iR_Analyst?.FileName_TH is not null)
                            {
                                var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + iR_Analyst.FileName_TH);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            iR_Analyst.FileName_TH = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + datestr + extension);
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
                            if (iR_Analyst?.FileName_EN is not null)
                            {
                                var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + iR_Analyst.FileName_EN);
                                if (System.IO.File.Exists(old_filePath) == true)
                                {
                                    System.IO.File.Delete(old_filePath);
                                }
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            iR_Analyst.FileName_EN = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                    iR_Analyst.Status = model.Status;
                    iR_Analyst.updated_at = DateTime.Now;
                    _context.Entry(iR_Analyst).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return new JsonResult(new { status = "error", messageArray = "error" });
                }
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Analyst_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Analysts.FirstOrDefault(x => x.Id == Id);
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

                    _context.IR_Analysts.Remove(DB);
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
        public async Task<IActionResult> Analyst_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Analysts.FirstOrDefault(x => x.Id == Id);
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

        public IActionResult Analyst_Chapter()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Table_Analyst_Chapter()
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
                var list = new List<ResponseDTO.IR_IR_Analyst_ChaptertResponse>();
                var IR_Contact = await _context.IR_Analyst_Chapter.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_IR_Analyst_ChaptertResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        FileName_TH = item.FileName_TH,
                        FileName_EN = item.FileName_EN,
                        Status = item.Status,
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
                           x.FileName_TH.Contains(searchValue) ||
                           x.FileName_EN.Contains(searchValue)
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

        public IActionResult Analyst_Chapter_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> Analyst_Chapter_Add_Submit(RequestDTO.IR_Analyst_ChapterRequest model)
        {
            try
            {
                IR_Analyst_Chapter iR_Analyst_Chapter = new IR_Analyst_Chapter();
                foreach (var formFile in model.uploaded_fileTH)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_Analyst_Chapter.FileName_TH = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + datestr + extension);
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
                        iR_Analyst_Chapter.FileName_EN = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                iR_Analyst_Chapter.Status = model.Status;
                iR_Analyst_Chapter.created_at = DateTime.Now;
                iR_Analyst_Chapter.updated_at = DateTime.Now;
                _context.IR_Analyst_Chapter.Add(iR_Analyst_Chapter);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Analyst_Chapter_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalyst_ChapterEdit(int? Id)
        {
            try
            {
                var DB = await _context.IR_Analyst_Chapter.FirstOrDefaultAsync(x => x.Id == Id);
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
        public async Task<IActionResult> Analyst_ChapterEdit_Submit(RequestDTO.IR_Analyst_ChapterRequest model)
        {
            try
            {
                var iR_Analyst_Chapter = _context.IR_Analyst_Chapter.FirstOrDefault(x => x.Id == model.Id);
                foreach (var formFile in model.uploaded_fileTH)
                {
                    if (formFile.Length > 0)
                    {
                        var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + iR_Analyst_Chapter.FileName_TH);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }

                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_Analyst_Chapter.FileName_TH = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + datestr + extension);
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
                        var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_NewRoom/" + iR_Analyst_Chapter.FileName_EN);
                        if (System.IO.File.Exists(old_filePath) == true)
                        {
                            System.IO.File.Delete(old_filePath);
                        }

                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_Analyst_Chapter.FileName_EN = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/IR_Analyst/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                iR_Analyst_Chapter.Status = model.Status;
                iR_Analyst_Chapter.created_at = DateTime.Now;
                iR_Analyst_Chapter.updated_at = DateTime.Now;
                _context.Entry(iR_Analyst_Chapter).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Analyst_Chapter_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Analyst_Chapter.FirstOrDefault(x => x.Id == Id);
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

                    _context.IR_Analyst_Chapter.Remove(DB);
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
        public async Task<IActionResult> Analyst_ChapterChange(int? Id)
        {
            try
            {
                var DB = _context.IR_Analyst_Chapter.FirstOrDefault(x => x.Id == Id);
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
