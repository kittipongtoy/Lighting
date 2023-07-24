using Lighting.Areas.Identity.Data;
using Lighting.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
	[Authorize]
	public class IR_StockController : Controller
	{
		private readonly LightingContext _context;
		public IR_StockController(LightingContext context)
		{
			_context = context;
		}

		public IActionResult IR_Stock_Quote_Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Table_IR_Stock_Quote()
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
                var list = new List<ResponseDTO.AuthorizationResponse>();
                var IR_Contact = await _context.Users.ToListAsync();
                int? runitem = 1;
                foreach (var item in IR_Contact)
                {
                    list.Add(new ResponseDTO.AuthorizationResponse
                    {
                        Index = runitem,
                        Id = item.Id,
                        EmployeeCode = item.EmployeeCode == null ? "" : item.EmployeeCode,
                        EmployeeCodeInt = item.EmployeeCodeInt == null ? 0 : item.EmployeeCodeInt,
                        Firstname = item.Firstname == null ? "" : item.Firstname,
                        Lastname = item.Lastname == null ? "" : item.Lastname,
                        Address = item.Address == null ? "" : item.Address,
                        ProfilePath = item.ProfilePath == null ? "" : item.ProfilePath,
                        ReceptionistFile = item.ReceptionistFile == null ? "" : item.ReceptionistFile,
                        ApplicationFile = item.ApplicationFile == null ? "" : item.ApplicationFile,
                        GuarantorIdentificationCardFile = item.GuarantorIdentificationCardFile == null ? "" : item.GuarantorIdentificationCardFile
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
                           x.EmployeeCode.Contains(searchValue) ||
                           x.Firstname.Contains(searchValue) ||
                           x.Lastname.Contains(searchValue) ||
                           x.Address.Contains(searchValue) ||
                           x.ProfilePath.Contains(searchValue) ||
                           x.ReceptionistFile.Contains(searchValue) ||
                           x.ApplicationFile.Contains(searchValue) ||
                           x.GuarantorIdentificationCardFile.Contains(searchValue)
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

		public IActionResult IR_Stock_Quote_Add()
		{
			return View();
		}

		public IActionResult IR_Stock_Quote_Add_Submit()
		{
			return View();
		}

		public IActionResult IR_Stock_Quote_Edit()
		{
			return View();
		}

		public IActionResult GetIR_Stock_Quote_Edit()
		{
			return View();
		}

		public IActionResult IR_Stock_Quote_Edit_Submit()
		{
			return View();
		}

		public IActionResult IR_Stock_Quote_Delete()
		{
			return View();
		}

		public IActionResult IR_Stock_Chart_Index()
		{
			return View();
		}

		public IActionResult Table_IR_Stock_Chart()
		{
			return View();
		}

		public IActionResult IR_Stock_Chart_Add()
		{
			return View();
		}

		public IActionResult IR_Stock_Chart_Add_Submit()
		{
			return View();
		}

		public IActionResult IR_Stock_Chart_Edit()
		{
			return View();
		}

		public IActionResult GetIR_Stock_Chart_Edit()
		{
			return View();
		}

		public IActionResult IR_Stock_Chart_Edit_Submit()
		{
			return View();
		}

		public IActionResult IR_Stock_Chart_Delete()
		{
			return View();
		}

        public IActionResult IR_Stock_Link_Index()
		{
			return View();
		}

		public IActionResult Table_IR_Stock_Link()
		{
			return View();
		}

		public IActionResult IR_Stock_Link_Add()
		{
            return View();
		}

		public IActionResult IR_Stock_Link_Edit()
		{
			return View();
		}

		public IActionResult IR_Stock_Link_Edit_Submit()
		{
			return View();
		}

		public IActionResult IR_Stock_Link_Delete()
		{
			return View();
		}
    }
}
