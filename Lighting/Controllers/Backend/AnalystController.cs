using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class AnalystController : Controller
	{
        private readonly LightingContext _context;

        public AnalystController(LightingContext context) 
        {
            _context = context;
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
        public IActionResult Analyst_Add_Submit(RequestDTO.IR_AnalystRequest model)
        {
            try
            {
                IR_Analyst iR_Analyst = new IR_Analyst();
                iR_Analyst.Status = model.Status;
                
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
            catch (Exception error)
            {
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
            return View();
        }

        public IActionResult Analyst_Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAnalyst_Edit()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Analyst_Edit_Submit()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Analyst_Delete()
        {
            return View();
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
                        FileName_EN = item.FileName_EN
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
        public IActionResult Analyst_Chapter_Add_Submit()
        {
            return View();
        }

        public IActionResult Analyst_Chapter_Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAnalyst_ChapterEdit()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Analyst_ChapterEdit_Submit()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Analyst_Chapter_Delete()
        {
            return View();
        }
    }
}
