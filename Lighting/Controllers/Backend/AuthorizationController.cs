using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lighting.Areas.Identity.Data;

namespace Lighting.Controllers.Backend
{
	public class AuthorizationController : Controller
	{
		private readonly LightingContext _context;
		private readonly ILogger<AuthorizationController> _logger;
		private IWebHostEnvironment _hostEnvironment;

		public AuthorizationController(LightingContext context, ILogger<AuthorizationController> logger, IWebHostEnvironment hostEnvironment)
		{
			_context = context;
			_logger = logger;
			_hostEnvironment = hostEnvironment;
		}

		public IActionResult Authorization_Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> DataTable_Authorization() 
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

		public IActionResult Authorization_Add()
		{
			return View();
		}

		public IActionResult Authorization_Edit()
		{
			return View();
		}

		public IActionResult Authorization_Delete() 
		{
			return View();
		}
	}
}
