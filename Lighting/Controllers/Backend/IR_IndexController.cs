using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using static Lighting.Models.RequestDTO;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class IR_IndexController : Controller
    {
        private readonly LightingContext _context;
        private readonly ILogger<IR_IndexController> _logger;
        private IWebHostEnvironment _hostEnvironment;

        public IR_IndexController(ILogger<IR_IndexController> logger, LightingContext lightingContext, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _context = lightingContext;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Banner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TableBanner()
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
                var list = new List<ResponseDTO.IR_IndexBannerResponse>();
                var History = await _context.IR_Banner.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.IR_IndexBannerResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Status = item.Status,
                        ImageBanner = item.ImageBanner
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.ImageBanner.Contains(searchValue)).ToList();
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

        public IActionResult Banner_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> Banner_Add_Submit(RequestDTO.IR_BannerRequest model)
        {
            try
            {
                IR_Banner iR_Banner = new IR_Banner();
                foreach (var formFile in model.uploaded_Image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_Banner.ImageBanner = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }

                        var CheckSizeimg = System.Drawing.Image.FromFile(filePath);
                        if (CheckSizeimg.Width > 1920 && CheckSizeimg.Height > 567)
                        {
                            return new JsonResult(new { status = "errorImage", messageArray = "errorImage" });
                        }
                    }
                }
                iR_Banner.Status = model.Status;
                iR_Banner.updated_at = DateTime.Now;
                iR_Banner.created_at = DateTime.Now;
                _context.IR_Banner.Add(iR_Banner);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Banner_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetBanner(int? Id)
        {
            try
            {
                var DB = await _context.IR_Banner.FirstOrDefaultAsync(x => x.Id == Id);
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
        public async Task<IActionResult> Banner_Edit_Submit(RequestDTO.IR_BannerRequest model)
        {
            try
            {
                var IR_Banner = await _context.IR_Banner.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (IR_Banner is not null)
                {
                    foreach (var formFile in model.uploaded_Image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + IR_Banner.ImageBanner);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            IR_Banner.ImageBanner = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }

                            var CheckSizeimg = System.Drawing.Image.FromFile(old_filePath);
                            if (CheckSizeimg.Width > 1920 && CheckSizeimg.Height > 567)
                            {
                                return new JsonResult(new { status = "errorImage", messageArray = "errorImage" });
                            }
                        }
                    }
                    IR_Banner.Status = model.Status;
                    IR_Banner.updated_at = DateTime.Now;
                    _context.Entry(IR_Banner).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new JsonResult(new { status = "success", messageArray = "success" });
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

        [HttpDelete]
        public async Task<IActionResult> Banner_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Banner.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + DB.ImageBanner);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    _context.IR_Banner.Remove(DB);
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
        public async Task<IActionResult> Banner_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Banner.FirstOrDefault(x => x.Id == Id);
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

        public IActionResult Button_Below_Banner()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> TableButton_Below_Banner()
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
                var list = new List<ResponseDTO.IR_Button_Below_BannerResponse>();
                var History = await _context.IR_Button_Below_Banner.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.IR_Button_Below_BannerResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Status = item.Status,
                        Icon = item.Icon,
                        Title_EN = item.Title_EN,
                        Title_TH = item.Title_TH
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Title_TH.Contains(searchValue)
                    || x.Title_EN.Contains(searchValue)).ToList();
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

		public IActionResult Button_Below_Banner_Add()
		{
			return View();
		}

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> Button_Below_Banner_Add_Submit(RequestDTO.IR_Button_Below_BannerRequest model)
		{
            try
            {
                IR_Button_Below_Banner iR_Button_Below_Banner = new IR_Button_Below_Banner();
                foreach (var formFile in model.uploaded_Image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_Button_Below_Banner.Icon = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                iR_Button_Below_Banner.Title_TH = model.Title_TH;
                iR_Button_Below_Banner.Title_EN = model.Title_EN;
                iR_Button_Below_Banner.Status = model.Status;
                iR_Button_Below_Banner.updated_at = DateTime.Now;
                iR_Button_Below_Banner.created_at = DateTime.Now;
                _context.IR_Button_Below_Banner.Add(iR_Button_Below_Banner);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult Button_Below_Banner_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetButton_Below_Banner_Edit(int? Id)
        {
            try
            {
                var DB = await _context.IR_Button_Below_Banner.FirstOrDefaultAsync(x => x.Id == Id);
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
        public async Task<IActionResult> Button_Below_Banner_Edit_Submit(RequestDTO.IR_Button_Below_BannerRequest model)
        {
            try
            {
                var IR_Button_Below_Banner = await _context.IR_Button_Below_Banner.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (IR_Button_Below_Banner is not null)
                {
                    foreach (var formFile in model.uploaded_Image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + IR_Button_Below_Banner.Icon);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            IR_Button_Below_Banner.Icon = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                    IR_Button_Below_Banner.Title_TH = model.Title_TH;
                    IR_Button_Below_Banner.Title_EN = model.Title_EN;
                    IR_Button_Below_Banner.Status = model.Status;
                    IR_Button_Below_Banner.Status = model.Status;
                    IR_Button_Below_Banner.updated_at = DateTime.Now;
                    _context.Entry(IR_Button_Below_Banner).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return new JsonResult(new { status = "success", messageArray = "success" });
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

        [HttpDelete]
        public async Task<IActionResult> Button_Below_Banner_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Button_Below_Banner.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + DB.Icon);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    _context.IR_Button_Below_Banner.Remove(DB);
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
        public async Task<IActionResult> Button_Below_Banner_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_Button_Below_Banner.FirstOrDefault(x => x.Id == Id);
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

        public IActionResult LIGHTING_EQUIPMENT()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TableLIGHTING_EQUIPMENT()
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
                var list = new List<ResponseDTO.IR_LIGHTING_EQUIPMENTResponse>();
                var History = await _context.IR_LIGHTING_EQUIPMENT.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.IR_LIGHTING_EQUIPMENTResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Status = item.Status,
                        Title_EN = item.Title_EN,
                        Title_TH = item.Title_TH,
                        SubTitle_TH = item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN,
                        RegisterTH = item.RegisterTH,
                        RegisterEN = item.RegisterEN,
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Title_TH.Contains(searchValue)
                    || x.Title_EN.Contains(searchValue)
                    || x.SubTitle_TH.Contains(searchValue)
                    || x.SubTitle_EN.Contains(searchValue)
                    || x.RegisterTH.Contains(searchValue)
                    || x.RegisterEN.Contains(searchValue)).ToList();
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

        public IActionResult LIGHTING_EQUIPMENT_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> LIGHTING_EQUIPMENT_Aadd_Submit(RequestDTO.IR_LIGHTING_EQUIPMENTRequest model)
        {
            try
            {
                IR_LIGHTING_EQUIPMENT iR_LIGHTING_EQUIPMENT = new IR_LIGHTING_EQUIPMENT();
                foreach (var formFile in model.uploaded_Image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_LIGHTING_EQUIPMENT.Image = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
                iR_LIGHTING_EQUIPMENT.Title_TH = model.Title_TH;
                iR_LIGHTING_EQUIPMENT.Title_EN = model.Title_EN;
                iR_LIGHTING_EQUIPMENT.SubTitle_EN = model.SubTitle_EN;
                iR_LIGHTING_EQUIPMENT.SubTitle_TH = model.SubTitle_TH;
                iR_LIGHTING_EQUIPMENT.RegisterTH = model.RegisterTH;
                iR_LIGHTING_EQUIPMENT.RegisterEN = model.RegisterEN;
                iR_LIGHTING_EQUIPMENT.Status = model.Status;
                iR_LIGHTING_EQUIPMENT.updated_at = DateTime.Now;
                iR_LIGHTING_EQUIPMENT.created_at = DateTime.Now;
                _context.IR_LIGHTING_EQUIPMENT.Add(iR_LIGHTING_EQUIPMENT);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult LIGHTING_EQUIPMENT_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetLIGHTING_EQUIPMENT_Edit(int? Id)
        {
            return View();
        }

        [HttpPut]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> LIGHTING_EQUIPMENT_Edit_Submit(RequestDTO.IR_LIGHTING_EQUIPMENTRequest model)
        {
            try
            {
                var iR_LIGHTING_EQUIPMENT = _context.IR_LIGHTING_EQUIPMENT.FirstOrDefault(x => x.Id == model.Id);
                if (iR_LIGHTING_EQUIPMENT is not null)
                {
                    foreach (var formFile in model.uploaded_Image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + iR_LIGHTING_EQUIPMENT.Image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            iR_LIGHTING_EQUIPMENT.Image = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }
                    iR_LIGHTING_EQUIPMENT.Title_TH = model.Title_TH;
                    iR_LIGHTING_EQUIPMENT.Title_EN = model.Title_EN;
                    iR_LIGHTING_EQUIPMENT.SubTitle_EN = model.SubTitle_EN;
                    iR_LIGHTING_EQUIPMENT.SubTitle_TH = model.SubTitle_TH;
                    iR_LIGHTING_EQUIPMENT.RegisterTH = model.RegisterTH;
                    iR_LIGHTING_EQUIPMENT.RegisterEN = model.RegisterEN;
                    iR_LIGHTING_EQUIPMENT.Status = model.Status;
                    iR_LIGHTING_EQUIPMENT.updated_at = DateTime.Now;
                    iR_LIGHTING_EQUIPMENT.created_at = DateTime.Now;
                    _context.Entry(iR_LIGHTING_EQUIPMENT).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(new { status = "success", messageArray = "success" });
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

        [HttpDelete]
        public async Task<IActionResult> LIGHTING_EQUIPMENT_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_LIGHTING_EQUIPMENT.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Index/" + DB.Image);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }

                    _context.IR_LIGHTING_EQUIPMENT.Remove(DB);
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
        public async Task<IActionResult> LIGHTING_EQUIPMENT_Change(int? Id)
        {
            try
            {
                var DB = _context.IR_LIGHTING_EQUIPMENT.FirstOrDefault(x => x.Id == Id);
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

        public IActionResult Summary_Financial_Highlights()
        {
            return View();
        }

        public IActionResult Summary_Financial_Highlights_Add()
        {
            return View();
        }

        public IActionResult Summary_Financial_Highlights_Edit()
        {
            return View();
        }

        public IActionResult Summary_Financial_Highlights_Delete()
        {
            return View();
        }

        public IActionResult Summary๘Financial_Highlights_Change()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Report_Add()
        {
            return View();
        }

        public IActionResult Report_Add_Submit()
        {
            return View();
        }

        public IActionResult Report_Edit()
        {
            return View();
        }

        public IActionResult Get_Report_Edit()
        {
            return View();
        }

        public IActionResult Report_Edit_Submit()
        {
            return View();
        }

		public IActionResult Report_Delete() 
        {
            return View();
        }

        public IActionResult Report_Change()
        {
            return View();
        }

		public IActionResult HIGHLIGHT()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Add()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Add_Submit()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Edit()
        {
            return View();
        }

        public IActionResult GetHIGHLIGHT_Edit()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Edit_Submit()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Delete()
        {
            return View();
        }

        public IActionResult HIGHLIGHT_Change()
        {
            return View();
        }
    }
}
