using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Lighting.Controllers.Backend
{
    public class Resource_FacilityController : Controller
    {
        private readonly LightingContext _context;
		private readonly ILogger<IR_ContactController> _logger;
		private IWebHostEnvironment _hostEnvironment;

		public Resource_FacilityController(ILogger<IR_ContactController> logger, LightingContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
        }

        public IActionResult History()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TableHistory()
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
                var list = new List<ResponseDTO.HistoryResponse>();
                var History = await _context.History.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.HistoryResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        Title_EN = item.Title_EN,
                        Title_TH = item.Title_TH,
                        Status = item.Status,
                        SubTitle_EN = item.SubTitle_EN,
                        SubTitle_TH = item.SubTitle_TH
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Title_EN.Contains(searchValue)
                    || x.Title_EN.Contains(searchValue)
                    || x.Title_TH.Contains(searchValue)
                    || x.SubTitle_EN.Contains(searchValue)
                    || x.SubTitle_TH.Contains(searchValue)
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

        public IActionResult History_Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> History_Add_Submit(RequestDTO.HistoryRequest model)
        {
            try
            {
                History history = new History();
                history.Title_TH = model.Title_TH;
                history.Title_EN = model.Title_EN;
                history.SubTitle_EN = model.SubTitle_EN;
                history.SubTitle_TH = model.SubTitle_TH;
                history.Status = model.Status;
                history.created_at = DateTime.Now;
                history.updated_at = DateTime.Now;
                _context.History.Add(history);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult History_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory_Edit(int? Id)
        {
            try
            {
                var DB = await _context.History.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> History_Edit_Submit(RequestDTO.HistoryRequest model)
        {
            try
            {
                var DB = await _context.History.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_EN = model.SubTitle_EN;
                    DB.SubTitle_TH = model.SubTitle_TH;
                    DB.Status = model.Status;
                    _context.Entry(DB).State = EntityState.Modified;
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
        public async Task<IActionResult> History_Delete(int? Id)
        {
            try
            {
                try
                {
                    var DB = _context.History.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        _context.History.Remove(DB);
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
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> History_Change(int? Id)
        {
            try
            {
                var DB = _context.History.FirstOrDefault(x => x.Id == Id);
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
        public async Task<IActionResult> TableHistoryDetail()
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
                var list = new List<ResponseDTO.HistoryDetailResponse>();
                var History = await _context.HistoryDetail.ToListAsync();
                int? runitem = 1;
                foreach (var item in History)
                {
                    list.Add(new ResponseDTO.HistoryDetailResponse
					{
                        Index = runitem,
                        Id = item.Id,
                        Title_EN = item.Title_EN,
                        Title_TH = item.Title_TH,
                        Status = item.Status,
                        Detail_EN = item.Detail_TH,
                        Detail_TH = item.Detail_TH,
                        FileCompany_EN = item.FileCompany_EN,
                        FileCompany_TH = item.FileCompany_TH,
                        ImageEN = item.ImageEN,
                        ImageTH = item.ImageTH
                    });
                    runitem++;
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    var dd = list.AsQueryable();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(x => x.Title_EN.Contains(searchValue)
                    || x.Title_EN.Contains(searchValue)
                    || x.Title_TH.Contains(searchValue)
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

        public IActionResult HistoryDetail_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HistoryDetail_Add_Submit(RequestDTO.HistoryDetailRequest model)
        {
            try
            {
                HistoryDetail historyDetail = new HistoryDetail();
				historyDetail.Title_TH = model.Title_TH;
				historyDetail.Title_EN = model.Title_EN;
				historyDetail.Detail_TH = model.Detail_TH;
				historyDetail.Detail_EN = model.Detail_EN;

				foreach (var formFile in model.uploaded_ImageTH)
				{
					if (formFile.Length > 0)
					{
						var datestr = DateTime.Now.Ticks.ToString();
						var extension = Path.GetExtension(formFile.FileName);
						historyDetail.ImageTH  = datestr + extension;
						var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
						using (var stream = System.IO.File.Create(filePath))
						{
							formFile.CopyTo(stream);
						}
					}
				}

				foreach (var formFile in model.uploaded_ImageEN)
				{
					if (formFile.Length > 0)
					{
						var datestr = DateTime.Now.Ticks.ToString();
						var extension = Path.GetExtension(formFile.FileName);
						historyDetail.ImageEN = datestr + extension;
						var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
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
						historyDetail.FileCompany_EN = datestr + extension;
						var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
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
						historyDetail.FileCompany_TH = datestr + extension;
						var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
						using (var stream = System.IO.File.Create(filePath))
						{
							formFile.CopyTo(stream);
						}
					}
				}

				historyDetail.Status = model.Status;
				historyDetail.created_at = DateTime.Now;
				historyDetail.updated_at = DateTime.Now;
                _context.HistoryDetail.Add(historyDetail);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult HistoryDetail_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetHistoryDetail_Edit(int? Id)
        {
            try
            {
                var DB = await _context.HistoryDetail.FirstOrDefaultAsync(x => x.Id == Id);
                return Ok(DB);
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> HistoryDetail_Edit_Submit(RequestDTO.HistoryDetailRequest model)
        {
            try
            {
                var DB = await _context.HistoryDetail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
					foreach (var formFile in model.uploaded_ImageTH)
					{
						if (formFile.Length > 0)
						{
							var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/Resource_Facility/" + DB.ImageTH);
							if (System.IO.File.Exists(old_filePath) == true)
							{
								System.IO.File.Delete(old_filePath);
							}

							var datestr = DateTime.Now.Ticks.ToString();
							var extension = Path.GetExtension(formFile.FileName);
							DB.ImageTH = datestr + extension;
							var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
							using (var stream = System.IO.File.Create(filePath))
							{
								formFile.CopyTo(stream);
							}
						}
					}

					foreach (var formFile in model.uploaded_ImageEN)
					{
						if (formFile.Length > 0)
						{
							var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/Resource_Facility/" + DB.ImageEN);
							if (System.IO.File.Exists(old_filePath) == true)
							{
								System.IO.File.Delete(old_filePath);
							}

							var datestr = DateTime.Now.Ticks.ToString();
							var extension = Path.GetExtension(formFile.FileName);
							DB.ImageEN = datestr + extension;
							var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/Resource_Facility/" + datestr + extension);
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
							var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileCompany_EN);
							if (System.IO.File.Exists(old_filePath) == true)
							{
								System.IO.File.Delete(old_filePath);
							}

							var datestr = DateTime.Now.Ticks.ToString();
							var extension = Path.GetExtension(formFile.FileName);
							DB.FileCompany_EN = datestr + extension;
							var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
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
							var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/Resource_Facility/" + DB.FileCompany_TH);
							if (System.IO.File.Exists(old_filePath) == true)
							{
								System.IO.File.Delete(old_filePath);
							}

							var datestr = DateTime.Now.Ticks.ToString();
							var extension = Path.GetExtension(formFile.FileName);
							DB.FileCompany_TH = datestr + extension;
							var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_file/Resource_Facility/" + datestr + extension);
							using (var stream = System.IO.File.Create(filePath))
							{
								formFile.CopyTo(stream);
							}
						}
					}


					DB.Title_TH = model.Title_TH;
					DB.Title_EN = model.Title_EN;
					DB.Detail_TH = model.Detail_TH;
					DB.Detail_EN = model.Detail_EN;
					DB.Status = model.Status;
					DB.updated_at = DateTime.Now;
                    DB.Status = model.Status;
                    _context.Entry(DB).State = EntityState.Modified;
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
        public async Task<IActionResult> HistoryDetail_Delete(int? Id)
        {
            try
            {
                try
                {
                    var DB = _context.HistoryDetail.FirstOrDefault(x => x.Id == Id);
                    if (DB is not null)
                    {
                        _context.HistoryDetail.Remove(DB);
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
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> HistoryDetail_Change(int? Id)
        {
            try
            {
                var DB = _context.HistoryDetail.FirstOrDefault(x => x.Id == Id);
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






        public IActionResult OUR_PHILOSOPHY_VISION_MISSION()
        {
            return View();
        }



        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Add()
        {
            return View();
        }

        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Add_Submit()
        {
            return View();
        }

        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Edit()
        {
            return View();
        }

        public IActionResult GetOUR_PHILOSOPHY_VISION_MISSION_Edit()
        {
            return View();
        }

        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Edit_Submit()
        {
            return View();
        }

        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Delete()
        {
            return View();
        }

        public IActionResult OUR_PHILOSOPHY_VISION_MISSION_Change()
        {
            return View();
        }

        public IActionResult ORGANIZATION_CHART()
        {
            return View();
        }

        public IActionResult ORGANIZATION_CHART_Add()
        {
            return View();
        }

        public IActionResult ORGANIZATION_CHART_Add_Submit()
        {
            return View();
        }

        public IActionResult ORGANIZATION_CHART_Edit()
        {
            return View();
        }

        public IActionResult GetORGANIZATION_CHART_Edit()
        {
            return View();
        }

        public IActionResult ORGANIZATION_CHART_Edit_Submit()
        {
            return View();
        }

        public IActionResult ORGANIZATION_CHART_Delete()
        {
            return View();
        }

        public IActionResult ORGANIZATION_CHART_Change()
        {
            return View();
        }

        public IActionResult AWARDS()
        {
            return View();
        }

        public IActionResult AWARDS_Add()
        {
            return View();
        }

        public IActionResult AWARDS_Add_Submit()
        {
            return View();
        }

        public IActionResult AWARDS_Edit()
        {
            return View();
        }

        public IActionResult GetAWARDS_Edit()
        {
            return View();
        }

        public IActionResult AWARDS_Edit_Submit()
        {
            return View();
        }

        public IActionResult AWARDS_Delete()
        {
            return View();
        }

        public IActionResult AWARDS_Change()
        {
            return View();
        }
    }
}
