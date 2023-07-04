using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lighting.Models;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class IR_ContactController : Controller
	{
        private readonly LightingContext _context;
        private readonly ILogger<IR_ContactController> _logger;
        private IWebHostEnvironment _hostEnvironment;

        public IR_ContactController(ILogger<IR_ContactController> logger, LightingContext lightingContext, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _context = lightingContext;
            _hostEnvironment = hostEnvironment;
        }

		public IActionResult IR_Contact_Index()
		{
			return View();
		}

        [HttpPost]
		public async Task<IActionResult> DataTable_IRContact()
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
                var list = new List<ResponseDTO.IR_ContactResponse>();
                var IR_Contact = await _context.IR_Contact.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_ContactResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        SubTitle_TH = item.SubTitle_TH == null ? "" : item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN == null ? "" : item.SubTitle_EN,
                        Image = item.Image == null ? "" : item.Image,
                        Name_TH = item.Name_TH == null ? "" : item.Name_TH,
                        Name_EN = item.Name_EN == null ? "" : item.Name_EN,
                        Position_TH = item.Position_TH == null ? "" : item.Position_TH,
                        Position_EN = item.Position_EN == null ? "" : item.Position_EN,
                        Address_TH = item.Address_TH == null ? "" : item.Address_TH,
                        Address_EN = item.Address_EN == null ? "" : item.Address_EN,
                        Tel = item.Tel == null ? "" : item.Tel,
                        Tel2 = item.Tel2 == null ? "" : item.Tel2,
                        Email = item.Email == null ? "" : item.Email,
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
                           x.SubTitle_TH.Contains(searchValue) ||
                           x.SubTitle_EN.Contains(searchValue) ||
                           x.Name_TH.Contains(searchValue) ||
                           x.Name_EN.Contains(searchValue) ||
                           x.Position_TH.Contains(searchValue) ||
                           x.Position_EN.Contains(searchValue) ||
                           x.Address_TH.Contains(searchValue) ||
                           x.Address_EN.Contains(searchValue) ||
                           x.Tel.Contains(searchValue) ||
                           x.Tel2.Contains(searchValue) ||
                           x.Email.Contains(searchValue) 
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

        public IActionResult IR_Contact_Add()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(1024 * 1024 * 1024)]
        public async Task<IActionResult> IR_Contact_Add_Submit(RequestDTO.IR_ContactRequest model, List<IFormFile> uploaded_image) 
        {
            IR_Contact iR_Contact = new IR_Contact();
            try
            {
                foreach (var formFile in uploaded_image)
                {
                    if (formFile.Length > 0)
                    {
                        var datestr = DateTime.Now.Ticks.ToString();
                        var extension = Path.GetExtension(formFile.FileName);
                        iR_Contact.Image = datestr + extension;
                        var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Contact/" + datestr + extension);
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }

                iR_Contact.Title_TH = model.Title_TH;
                iR_Contact.Title_EN = model.Title_EN;
                iR_Contact.SubTitle_TH = model.SubTitle_TH;
                iR_Contact.SubTitle_EN = model.SubTitle_EN;
                iR_Contact.Name_TH = model.Name_TH;
                iR_Contact.Name_EN = model.Name_EN;
                iR_Contact.Position_TH = model.Position_TH;
                iR_Contact.Position_EN = model.Position_EN;
                iR_Contact.Address_EN = model.Address_EN;
                iR_Contact.Address_TH = model.Address_TH;
                iR_Contact.Tel = model.Tel;
                iR_Contact.Tel2 = model.Tel2;
                iR_Contact.Email = model.Email;
                iR_Contact.Status = model.Status;
                var Date = DateTime.Now;
                iR_Contact.updated_at = Date;
                iR_Contact.created_at = Date;
                _context.IR_Contact.Add(iR_Contact);
                await _context.SaveChangesAsync(); 
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                if (iR_Contact.Image is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Contact/" + iR_Contact.Image);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                }
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_Contact_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get_IR_Contact(int? Id)
        {
            try
            {
                var DB = await _context.IR_Contact.FirstOrDefaultAsync(x => x.Id == Id);
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
        public async Task<IActionResult> IR_Contact_Edit_Submit(RequestDTO.IR_ContactRequest model, List<IFormFile> uploaded_image)
        {
            try
            {
                var DB = await _context.IR_Contact.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    foreach (var formFile in uploaded_image)
                    {
                        if (formFile.Length > 0)
                        {
                            var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Contact/" + DB.Image);
                            if (System.IO.File.Exists(old_filePath) == true)
                            {
                                System.IO.File.Delete(old_filePath);
                            }

                            var datestr = DateTime.Now.Ticks.ToString();
                            var extension = Path.GetExtension(formFile.FileName);
                            DB.Image = datestr + extension;
                            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Contact/" + datestr + extension);
                            using (var stream = System.IO.File.Create(filePath))
                            {
                                formFile.CopyTo(stream);
                            }
                        }
                    }

                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_TH = model.SubTitle_TH;
                    DB.SubTitle_EN = model.SubTitle_EN;
                    DB.Name_TH = model.Name_TH;
                    DB.Name_EN = model.Name_EN;
                    DB.Position_TH = model.Position_TH;
                    DB.Position_EN = model.Position_EN;
                    DB.Address_EN = model.Address_EN;
                    DB.Address_TH = model.Address_TH;
                    DB.Tel = model.Tel;
                    DB.Tel2 = model.Tel2;
                    DB.Email = model.Email;
                    DB.Status = model.Status;
                    DB.updated_at = DateTime.Now;
                    _context.Entry(DB).State = EntityState.Modified;
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
        public async Task<IActionResult> IR_Contact_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Contact.FirstOrDefault(x=>x.Id == Id);
                if (DB is not null)
                {
                    var old_filePath = Path.Combine(_hostEnvironment.WebRootPath, "upload_image/IR_Contact/" + DB.Image);
                    if (System.IO.File.Exists(old_filePath) == true)
                    {
                        System.IO.File.Delete(old_filePath);
                    }
                    _context.IR_Contact.Remove(DB);
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
        public async Task<IActionResult> ChangeStatus_IR_Contact(int? Id)
        {
            try
            {
                var DB = _context.IR_Contact.FirstOrDefault(x => x.Id == Id);
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

        public IActionResult IR_Email_Alerts_Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> DataTable_IR_Email_Alerts()
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
				var list = new List<ResponseDTO.IR_Email_AlertsResponse>();
				var IR_Contact = await _context.IR_Email_Alerts.ToListAsync();
				int? runitem = 1;
				foreach (var item in IR_Contact)
				{
					list.Add(new ResponseDTO.IR_Email_AlertsResponse
					{
						Index = runitem,
						Id = Convert.ToInt32(item.Id),
						Title_TH = item.Title_TH == null ? "" : item.Title_TH,
						Title_EN = item.Title_EN == null ? "" : item.Title_EN,
						SubTitle_TH = item.SubTitle_TH == null ? "" : item.SubTitle_TH,
						SubTitle_EN = item.SubTitle_EN == null ? "" : item.SubTitle_EN,
						Text_Register_TH = item.Text_Register_TH == null ? "" : item.Text_Register_TH,
						Text_Register_EN = item.Text_Register_EN == null ? "" : item.Text_Register_EN,
						Text_Input_Email_TH = item.Text_Input_Email_TH == null ? "" : item.Text_Input_Email_TH,
						Text_Input_Email_EN = item.Text_Input_Email_EN == null ? "" : item.Text_Input_Email_EN,
						Policy_TH = item.Policy_TH == null ? "" : item.Policy_TH,
						Policy_EN = item.Policy_EN == null ? "" : item.Policy_EN,
						Note_TH = item.Note_TH == null ? "" : item.Note_TH,
						Note_EN = item.Note_EN == null ? "" : item.Note_EN,
						Button_Submit_TH = item.Button_Submit_TH == null ? "" : item.Button_Submit_TH,
						Button_Submit_EN = item.Button_Submit_EN == null ? "" : item.Button_Submit_EN,
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
						   x.SubTitle_TH.Contains(searchValue) ||
						   x.SubTitle_EN.Contains(searchValue) ||
						   x.Text_Register_TH.Contains(searchValue) ||
						   x.Text_Register_EN.Contains(searchValue) ||
						   x.Text_Input_Email_TH.Contains(searchValue) ||
						   x.Text_Input_Email_EN.Contains(searchValue) ||
						   x.Policy_TH.Contains(searchValue) ||
						   x.Policy_EN.Contains(searchValue) ||
						   x.Note_TH.Contains(searchValue) ||
						   x.Note_EN.Contains(searchValue) ||
						   x.Button_Submit_TH.Contains(searchValue) ||
						   x.Button_Submit_EN.Contains(searchValue)
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

		public IActionResult IR_Email_Alerts_Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> IR_Email_Alerts_Add_Submit(RequestDTO.IR_Email_AlertsRequest model)
		{
			IR_Email_Alerts IR_Email_Alerts = new IR_Email_Alerts();
			try
			{

                IR_Email_Alerts.Title_TH = model.Title_TH;
                IR_Email_Alerts.Title_EN = model.Title_EN;
                IR_Email_Alerts.SubTitle_TH = model.SubTitle_TH;
                IR_Email_Alerts.SubTitle_EN = model.SubTitle_EN;
                IR_Email_Alerts.Text_Register_TH = model.Text_Register_TH;
                IR_Email_Alerts.Text_Register_EN = model.Text_Register_EN;
                IR_Email_Alerts.Text_Input_Email_TH = model.Text_Input_Email_TH;
                IR_Email_Alerts.Text_Input_Email_EN = model.Text_Input_Email_EN;
                IR_Email_Alerts.Policy_TH = model.Policy_TH;
                IR_Email_Alerts.Policy_EN = model.Policy_EN;
                IR_Email_Alerts.Note_TH = model.Note_TH;
                IR_Email_Alerts.Note_EN = model.Note_EN;
                IR_Email_Alerts.Button_Submit_TH = model.Button_Submit_TH;
                IR_Email_Alerts.Button_Submit_EN = model.Button_Submit_EN;
                IR_Email_Alerts.Status = model.Status;
				var Date = DateTime.Now;
                IR_Email_Alerts.updated_at = Date;
                IR_Email_Alerts.created_at = Date;
				_context.IR_Email_Alerts.Add(IR_Email_Alerts);
				await _context.SaveChangesAsync();
				return new JsonResult(new { status = "success", messageArray = "success" });
			}
			catch (Exception error)
			{
				throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
			}
		}

		public IActionResult IR_Email_Alerts_Edit(int? Id)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Get_IR_Email_Alerts(int? Id)
		{
			try
			{
				var DB = await _context.IR_Email_Alerts.FirstOrDefaultAsync(x => x.Id == Id);
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
		public async Task<IActionResult> IR_Email_Alerts_Edit_Submit(RequestDTO.IR_Email_AlertsRequest model)
		{
			try
			{
				var DB = await _context.IR_Email_Alerts.FirstOrDefaultAsync(x => x.Id == model.Id);
				if (DB is not null)
				{
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_TH = model.SubTitle_TH;
                    DB.SubTitle_EN = model.SubTitle_EN;
                    DB.Text_Register_TH = model.Text_Register_TH;
                    DB.Text_Register_EN = model.Text_Register_EN;
                    DB.Text_Input_Email_TH = model.Text_Input_Email_TH;
                    DB.Text_Input_Email_EN = model.Text_Input_Email_EN;
                    DB.Policy_TH = model.Policy_TH;
                    DB.Policy_EN = model.Policy_EN;
                    DB.Note_TH = model.Note_TH;
                    DB.Note_EN = model.Note_EN;
                    DB.Button_Submit_TH = model.Button_Submit_TH;
                    DB.Button_Submit_EN = model.Button_Submit_EN;
                    DB.Status = model.Status;
                    var Date = DateTime.Now;
                    DB.updated_at = Date;
                    DB.updated_at = DateTime.Now;
					_context.Entry(DB).State = EntityState.Modified;
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
		public async Task<IActionResult> IR_Email_Alerts_Delete(int? Id)
		{
			try
			{
				var DB = _context.IR_Email_Alerts.FirstOrDefault(x => x.Id == Id);
				if (DB is not null)
				{
					_context.IR_Email_Alerts.Remove(DB);
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
		public async Task<IActionResult> ChangeStatus_IR_Email_Alerts(int? Id)
		{
			try
			{
				var DB = _context.IR_Email_Alerts.FirstOrDefault(x => x.Id == Id);
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

        public IActionResult Cancel_Email_Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> DataTable_Cancel_Email()
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
				var list = new List<ResponseDTO.IR_Cancel_EmailResponse>();
				var IR_Contact = await _context.IR_Cancel_Email.ToListAsync();
				int? runitem = 1;
				foreach (var item in IR_Contact)
				{
					list.Add(new ResponseDTO.IR_Cancel_EmailResponse
                    {
						Index = runitem,
						Id = Convert.ToInt32(item.Id),
						Title_TH = item.Title_TH == null ? "" : item.Title_TH,
						Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        Detail_TH = item.Detail_TH == null ? "" : item.Detail_TH,
                        Detail_EN = item.Detail_EN == null ? "" : item.Detail_EN,
                        Text_TH = item.Text_TH == null ? "" : item.Text_TH,
                        Text_EN = item.Text_EN == null ? "" : item.Text_EN,
                        Input_Text_TH = item.Input_Text_TH == null ? "" : item.Input_Text_TH,
                        Input_Text_EN = item.Input_Text_EN == null ? "" : item.Input_Text_EN,
                        Button_Submit_TH = item.Button_Submit_TH == null ? "" : item.Button_Submit_TH,
                        Button_Submit_EN = item.Button_Submit_EN == null ? "" : item.Button_Submit_EN,
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
						   x.Detail_TH.Contains(searchValue) ||
						   x.Detail_EN.Contains(searchValue) ||
						   x.Text_TH.Contains(searchValue) ||
						   x.Text_EN.Contains(searchValue) ||
						   x.Input_Text_TH.Contains(searchValue) ||
						   x.Input_Text_EN.Contains(searchValue) ||
						   x.Button_Submit_TH.Contains(searchValue) ||
						   x.Button_Submit_EN.Contains(searchValue)
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

		public IActionResult Cancel_Email_Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Cancel_Email_Add_Submit(RequestDTO.IR_Cancel_EmailRequest model)
		{
			IR_Cancel_Email IR_Cancel_Email = new IR_Cancel_Email();
			try
			{
                IR_Cancel_Email.Title_TH = model.Title_TH;
                IR_Cancel_Email.Title_EN = model.Title_EN;
                IR_Cancel_Email.Detail_TH = model.Detail_TH;
                IR_Cancel_Email.Detail_EN = model.Detail_EN;
                IR_Cancel_Email.Text_TH = model.Text_TH;
                IR_Cancel_Email.Text_EN = model.Text_EN;
                IR_Cancel_Email.Input_Text_TH = model.Input_Text_TH;
                IR_Cancel_Email.Input_Text_EN = model.Input_Text_EN;
                IR_Cancel_Email.Button_Submit_TH = model.Button_Submit_TH;
                IR_Cancel_Email.Button_Submit_EN = model.Button_Submit_EN;
                IR_Cancel_Email.Status = model.Status;
				var Date = DateTime.Now;
                IR_Cancel_Email.updated_at = Date;
                IR_Cancel_Email.created_at = Date;
				_context.IR_Cancel_Email.Add(IR_Cancel_Email);
				await _context.SaveChangesAsync();
				return new JsonResult(new { status = "success", messageArray = "success" });
			}
			catch (Exception error)
			{
				throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
			}
		}

		public IActionResult Cancel_Email_Edit(int? Id)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Get_Cancel_Email(int? Id)
		{
			try
			{
				var DB = await _context.IR_Cancel_Email.FirstOrDefaultAsync(x => x.Id == Id);
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
		public async Task<IActionResult> Cancel_Email_Edit_Submit(RequestDTO.IR_Cancel_EmailRequest model)
		{
			try
			{
				var DB = await _context.IR_Cancel_Email.FirstOrDefaultAsync(x => x.Id == model.Id);
				if (DB is not null)
				{
					DB.Title_TH = model.Title_TH;
					DB.Title_EN = model.Title_EN;
					DB.Detail_TH = model.Detail_TH;
					DB.Detail_EN = model.Detail_EN;
					DB.Text_TH = model.Text_TH;
					DB.Text_EN = model.Text_EN;
					DB.Input_Text_TH = model.Input_Text_TH;
					DB.Input_Text_EN = model.Input_Text_EN;
					DB.Button_Submit_TH = model.Button_Submit_TH;
					DB.Button_Submit_EN = model.Button_Submit_EN;
					DB.Status = model.Status;
					var Date = DateTime.Now;
					DB.updated_at = Date;
					_context.Entry(DB).State = EntityState.Modified;
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
		public async Task<IActionResult> Cancel_Email_Delete(int? Id)
		{
			try
			{
				var DB = _context.IR_Cancel_Email.FirstOrDefault(x => x.Id == Id);
				if (DB is not null)
				{
					_context.IR_Cancel_Email.Remove(DB);
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
		public async Task<IActionResult> ChangeStatus_Cancel_Email(int? Id)
		{
			try
			{
				var DB = _context.IR_Cancel_Email.FirstOrDefault(x => x.Id == Id);
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

		public IActionResult IR_Request_Inquiry_Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> DataTable_IR_Request_Inquiry()
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
                var list = new List<ResponseDTO.IR_Request_InquiryResponse>();
                var IR_Contact = await _context.IR_Request_Inquiry.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_Request_InquiryResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        SubTitle_TH = item.SubTitle_TH == null ? "" : item.SubTitle_TH,
                        SubTitle_EN = item.SubTitle_EN == null ? "" : item.SubTitle_EN,
                        TitleText_Input_Name_TH = item.TitleText_Input_Name_TH == null ? "" : item.TitleText_Input_Name_TH,
                        TitleText_Input_Name_EN = item.TitleText_Input_Name_EN == null ? "" : item.TitleText_Input_Name_EN,
                        TitleText_Input_Tel = item.TitleText_Input_Tel == null ? "" : item.TitleText_Input_Tel,
                        Text_Input_Email = item.Text_Input_Email == null ? "" : item.Text_Input_Email,
                        Policy_TH = item.Policy_TH == null ? "" : item.Policy_TH,
                        Policy_EN = item.Policy_EN == null ? "" : item.Policy_EN,
                        Note_TH = item.Note_TH == null ? "" : item.Note_TH,
                        Note_EN = item.Note_EN == null ? "" : item.Note_EN,
                        Button_Submit_TH = item.Button_Submit_TH == null ? "" : item.Button_Submit_TH,
                        Button_Submit_EN = item.Button_Submit_EN == null ? "" : item.Button_Submit_EN,
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
                           x.SubTitle_TH.Contains(searchValue) ||
                           x.SubTitle_EN.Contains(searchValue) ||
                           x.TitleText_Input_Name_TH.Contains(searchValue) ||
                           x.TitleText_Input_Name_EN.Contains(searchValue) ||
                           x.TitleText_Input_Tel.Contains(searchValue) ||
                           x.Text_Input_Email.Contains(searchValue) ||
                           x.Text_Input_Note_TH.Contains(searchValue) ||
                           x.Text_Input_Note_EN.Contains(searchValue) ||
                           x.Policy_TH.Contains(searchValue) ||
                           x.Policy_EN.Contains(searchValue) ||
                           x.Note_TH.Contains(searchValue) ||
                           x.Note_EN.Contains(searchValue) ||
                           x.Button_Submit_TH.Contains(searchValue) ||
                           x.Button_Submit_EN.Contains(searchValue)
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

        public IActionResult IR_Request_Inquiry_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IR_Request_Inquiry_AddSubmit(RequestDTO.IR_Request_InquiryRequest model)
        {
            IR_Request_Inquiry IR_Request_Inquiry = new IR_Request_Inquiry();
            try
            {
                IR_Request_Inquiry.Title_TH = model.Title_TH;
                IR_Request_Inquiry.Title_EN = model.Title_EN;
                IR_Request_Inquiry.SubTitle_TH = model.SubTitle_TH;
                IR_Request_Inquiry.SubTitle_EN = model.SubTitle_EN;
                IR_Request_Inquiry.TitleText_Input_Name_TH = model.TitleText_Input_Name_TH;
                IR_Request_Inquiry.TitleText_Input_Name_EN = model.TitleText_Input_Name_EN;
                IR_Request_Inquiry.TitleText_Input_Tel = model.TitleText_Input_Tel;
                IR_Request_Inquiry.Text_Input_Email = model.Text_Input_Email;
                IR_Request_Inquiry.Policy_TH = model.Policy_TH;
                IR_Request_Inquiry.Policy_EN = model.Policy_EN;
                IR_Request_Inquiry.Note_TH = model.Note_TH;
                IR_Request_Inquiry.Note_EN = model.Note_EN;
                IR_Request_Inquiry.Button_Submit_TH = model.Button_Submit_TH;
                IR_Request_Inquiry.Button_Submit_EN = model.Button_Submit_EN;
                IR_Request_Inquiry.Status = model.Status;
                var Date = DateTime.Now;
                IR_Request_Inquiry.updated_at = Date;
                IR_Request_Inquiry.created_at = Date;
                _context.IR_Request_Inquiry.Add(IR_Request_Inquiry);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_Request_Inquiry_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get_IR_Request_Inquiry(int? Id)
        {
            try
            {
                var DB = await _context.IR_Request_Inquiry.FirstOrDefaultAsync(x => x.Id == Id);
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
        public async Task<IActionResult> IR_Request_Inquiry_Edit_Submit(RequestDTO.IR_Request_InquiryRequest model)
        {
            try
            {
                var DB = await _context.IR_Request_Inquiry.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_TH = model.SubTitle_TH;
                    DB.SubTitle_EN = model.SubTitle_EN;
                    DB.TitleText_Input_Name_TH = model.TitleText_Input_Name_TH;
                    DB.TitleText_Input_Name_EN = model.TitleText_Input_Name_EN;
                    DB.TitleText_Input_Tel = model.TitleText_Input_Tel;
                    DB.Text_Input_Email = model.Text_Input_Email;
                    DB.Policy_TH = model.Policy_TH;
                    DB.Policy_EN = model.Policy_EN;
                    DB.Note_TH = model.Note_TH;
                    DB.Note_EN = model.Note_EN;
                    DB.Button_Submit_TH = model.Button_Submit_TH;
                    DB.Button_Submit_EN = model.Button_Submit_EN;
                    DB.Status = model.Status;
                    var Date = DateTime.Now;
                    DB.updated_at = Date;
                    _context.Entry(DB).State = EntityState.Modified;
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
        public async Task<IActionResult> IR_Request_Inquiry_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_Request_Inquiry.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_Request_Inquiry.Remove(DB);
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
        public async Task<IActionResult> ChangeStatus_IR_Request_Inquiry(int? Id)
        {
            try
            {
                var DB = _context.IR_Request_Inquiry.FirstOrDefault(x => x.Id == Id);
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

        public IActionResult IR_faq_Index()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> DataTable_IR_faq()
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
                var list = new List<ResponseDTO.IR_faqResponse>();
                var IR_Contact = await _context.IR_faq.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_faqResponse
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
                           x.SubTitle_TH.Contains(searchValue) ||
                           x.SubTitle_EN.Contains(searchValue) 
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

        public IActionResult IR_faq_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IR_faq_AddSubmit(RequestDTO.IR_faqRequest model)
        {
            IR_faq IR_faq = new IR_faq();
            try
            {
                IR_faq.Title_TH = model.Title_TH;
                IR_faq.Title_EN = model.Title_EN;
                IR_faq.SubTitle_TH = model.Detail_TH;
                IR_faq.SubTitle_EN = model.Detail_EN;
                IR_faq.Status = model.Status;
                var Date = DateTime.Now;
                IR_faq.updated_at = Date;
                IR_faq.created_at = Date;
                _context.IR_faq.Add(IR_faq);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_faq_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get_IR_faq(int? Id)
        {
            try
            {
                var DB = await _context.IR_faq.FirstOrDefaultAsync(x => x.Id == Id);
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
        public async Task<IActionResult> IR_faq_Edit_Submit(RequestDTO.IR_faqRequest model)
        {
            try
            {
                var DB = await _context.IR_faq.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_TH = model.Detail_TH;
                    DB.SubTitle_EN = model.Detail_EN;
                    DB.Status = model.Status;
                    var Date = DateTime.Now;
                    DB.updated_at = Date;
                    _context.Entry(DB).State = EntityState.Modified;
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
        public async Task<IActionResult> IR_faq_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_faq.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_faq.Remove(DB);
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
        public async Task<IActionResult> ChangeStatus_IR_faq(int? Id)
        {
            try
            {
                var DB = _context.IR_faq.FirstOrDefault(x => x.Id == Id);
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
        public async Task<IActionResult> DataTable_IR_faqDetail()
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
                var list = new List<ResponseDTO.IR_faqDetailResponse>();
                var IR_Contact = await _context.IR_faq_Detail.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.IR_faqDetailResponse
                    {
                        Index = runitem,
                        Id = Convert.ToInt32(item.Id),
                        Title_TH = item.Title_TH == null ? "" : item.Title_TH,
                        Title_EN = item.Title_EN == null ? "" : item.Title_EN,
                        Detail_EN = item.Detail_EN == null ? "" : item.Detail_EN,
                        Detail_TH = item.Detail_TH == null ? "" : item.Detail_TH,
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
                           x.Detail_EN.Contains(searchValue) ||
                           x.Detail_TH.Contains(searchValue) 
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

        public IActionResult IR_faqDetail_Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IR_faqDetail_AddSubmit(RequestDTO.IR_faqDetailRequest model)
        {
            IR_faq_Detail IR_faq_Detail = new IR_faq_Detail();
            try
            {
                IR_faq_Detail.Title_TH = model.Title_TH;
                IR_faq_Detail.Title_EN = model.Title_EN;
                IR_faq_Detail.Detail_TH = model.Detail_TH;
                IR_faq_Detail.Detail_EN = model.Detail_EN;
                IR_faq_Detail.Status = model.Status;
                var Date = DateTime.Now;
                IR_faq_Detail.updated_at = Date;
                IR_faq_Detail.created_at = Date;
                _context.IR_faq_Detail.Add(IR_faq_Detail);
                await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
        }

        public IActionResult IR_faqDetail_Edit(int? Id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Get_IR_faqDetail(int? Id)
        {
            try
            {
                var DB = await _context.IR_faq_Detail.FirstOrDefaultAsync(x => x.Id == Id);
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
        public async Task<IActionResult> IR_faqDetail_Edit_Submit(RequestDTO.IR_faqDetailRequest model)
        {
            try
            {
                var DB = await _context.IR_faq_Detail.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (DB is not null)
                {
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.Detail_TH = model.Detail_TH;
                    DB.Detail_EN = model.Detail_EN;
                    DB.Status = model.Status;
                    var Date = DateTime.Now;
                    DB.updated_at = Date;
                    _context.Entry(DB).State = EntityState.Modified;
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
        public async Task<IActionResult> IR_faqDetail_Delete(int? Id)
        {
            try
            {
                var DB = _context.IR_faq_Detail.FirstOrDefault(x => x.Id == Id);
                if (DB is not null)
                {
                    _context.IR_faq_Detail.Remove(DB);
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
        public async Task<IActionResult> ChangeStatus_IR_faqDetail(int? Id)
        {
            try
            {
                var DB = _context.IR_faq_Detail.FirstOrDefault(x => x.Id == Id);
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

        public IActionResult IR_Complaints_Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> DataTable_IR_Complaints()
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
				var list = new List<ResponseDTO.IR_ComplaintsResponse>();
				var IR_Contact = await _context.IR_Complaints.ToListAsync();
				int? runitem = 1;
				foreach (var item in IR_Contact)
				{
					list.Add(new ResponseDTO.IR_ComplaintsResponse
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
						   x.SubTitle_TH.Contains(searchValue) ||
						   x.SubTitle_EN.Contains(searchValue)
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

		public IActionResult IR_Complaints_Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> IR_Complaints_AddSubmit(RequestDTO.IR_ComplaintsRequest model)
		{
			IR_Complaints IR_Complaints = new IR_Complaints();
			try
			{
				IR_Complaints.Title_TH = model.Title_TH;
				IR_Complaints.Title_EN = model.Title_EN;
				IR_Complaints.SubTitle_TH = model.SubTitle_TH;
				IR_Complaints.SubTitle_EN = model.SubTitle_EN;
				IR_Complaints.TypeContactUS_TH = model.TypeContactUS_TH;
				IR_Complaints.TypeContactUS_EN = model.TypeContactUS_EN;
				IR_Complaints.Detail_TH = model.Detail_TH;
				IR_Complaints.Detail_EN = model.Detail_EN;
				IR_Complaints.Input_Detail_TH = model.Input_Detail_TH;
				IR_Complaints.Input_Detail_EN = model.Input_Detail_EN;
				IR_Complaints.Title_File_TH = model.Title_File_TH;
				IR_Complaints.Title_File_EN = model.Title_File_EN;
				IR_Complaints.Title_Description_TH = model.Title_Description_TH;
				IR_Complaints.Title_Description_EN = model.Title_Description_EN;
				IR_Complaints.Button_Submit_Title_UploadFile_TH = model.Button_Submit_Title_UploadFile_TH;
				IR_Complaints.Button_Submit_Title_UploadFile_EN = model.Button_Submit_Title_UploadFile_EN;
				IR_Complaints.Title_Contact_Name_TH = model.Title_Contact_Name_TH;
				IR_Complaints.Title_Contact_Name_EN = model.Title_Contact_Name_EN;
				IR_Complaints.Title_Contact_Email_TH = model.Title_Contact_Email_TH;
				IR_Complaints.Title_Contact_Email_EN = model.Title_Contact_Email_EN;
				IR_Complaints.Title_Contact_Tel_TH = model.Title_Contact_Tel_TH;
				IR_Complaints.Title_Contact_Tel_EN = model.Title_Contact_Tel_EN;
				IR_Complaints.Title_Contact_Other_TH = model.Title_Contact_Other_TH;
				IR_Complaints.Title_Contact_Other_EN = model.Title_Contact_Other_EN;
				IR_Complaints.Title_Contact_Note_TH = model.Title_Contact_Note_TH;
				IR_Complaints.Title_Contact_Note_EN = model.Title_Contact_Note_EN;
				IR_Complaints.Button_Submit_TH = model.Button_Submit_TH;
				IR_Complaints.Button_Submit_EN = model.Button_Submit_EN;
                IR_Complaints.Title_TypeContact_TH = model.Title_TypeContact_TH;
                IR_Complaints.Title_TypeContact_EN = model.Title_TypeContact_EN;
                IR_Complaints.Status = model.Status;
				var Date = DateTime.Now;
				IR_Complaints.updated_at = Date;
				IR_Complaints.created_at = Date;
				_context.IR_Complaints.Add(IR_Complaints);
				await _context.SaveChangesAsync();
				return new JsonResult(new { status = "success", messageArray = "success" });
			}
			catch (Exception error)
			{
				throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
			}
		}

		public IActionResult IR_Complaints_Edit(int? Id)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Get_IR_Complaints(int? Id)
		{
			try
			{
				var DB = await _context.IR_Complaints.FirstOrDefaultAsync(x => x.Id == Id);
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
		public async Task<IActionResult> IR_Complaints_Edit_Submit(RequestDTO.IR_ComplaintsRequest model)
		{
			try
			{
				var DB = await _context.IR_Complaints.FirstOrDefaultAsync(x => x.Id == model.Id);
				if (DB is not null)
				{
                    DB.Title_TH = model.Title_TH;
                    DB.Title_EN = model.Title_EN;
                    DB.SubTitle_TH = model.SubTitle_TH;
                    DB.SubTitle_EN = model.SubTitle_EN;
                    DB.TypeContactUS_TH = model.TypeContactUS_TH;
                    DB.TypeContactUS_EN = model.TypeContactUS_EN;
                    DB.Detail_TH = model.Detail_TH;
                    DB.Detail_EN = model.Detail_EN;
                    DB.Input_Detail_TH = model.Input_Detail_TH;
                    DB.Input_Detail_EN = model.Input_Detail_EN;
                    DB.Title_File_TH = model.Title_File_TH;
                    DB.Title_File_EN = model.Title_File_EN;
                    DB.Title_Description_TH = model.Title_Description_TH;
                    DB.Title_Description_EN = model.Title_Description_EN;
                    DB.Button_Submit_Title_UploadFile_TH = model.Button_Submit_Title_UploadFile_TH;
                    DB.Button_Submit_Title_UploadFile_EN = model.Button_Submit_Title_UploadFile_EN;
                    DB.Title_Contact_Name_TH = model.Title_Contact_Name_TH;
                    DB.Title_Contact_Name_EN = model.Title_Contact_Name_EN;
                    DB.Title_Contact_Email_TH = model.Title_Contact_Email_TH;
                    DB.Title_Contact_Email_EN = model.Title_Contact_Email_EN;
                    DB.Title_Contact_Tel_TH = model.Title_Contact_Tel_TH;
                    DB.Title_Contact_Tel_EN = model.Title_Contact_Tel_EN;
                    DB.Title_Contact_Other_TH = model.Title_Contact_Other_TH;
                    DB.Title_Contact_Other_EN = model.Title_Contact_Other_EN;
                    DB.Title_Contact_Note_TH = model.Title_Contact_Note_TH;
                    DB.Title_Contact_Note_EN = model.Title_Contact_Note_EN;
                    DB.Button_Submit_TH = model.Button_Submit_TH;
                    DB.Button_Submit_EN = model.Button_Submit_EN;
                    DB.Status = model.Status;
					var Date = DateTime.Now;
					DB.updated_at = Date;
					_context.Entry(DB).State = EntityState.Modified;
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
		public async Task<IActionResult> IR_Complaints_Delete(int? Id)
		{
			try
			{
				var DB = _context.IR_Complaints.FirstOrDefault(x => x.Id == Id);
				if (DB is not null)
				{
					_context.IR_Complaints.Remove(DB);
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
		public async Task<IActionResult> ChangeStatus_IR_Complaints(int? Id)
		{
			try
			{
				var DB = _context.IR_Complaints.FirstOrDefault(x => x.Id == Id);
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
