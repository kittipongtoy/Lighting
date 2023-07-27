using Lighting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Lighting.Controllers.Backend
{
	[Authorize]
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

		[HttpPost]
		public async Task<IActionResult> Authorization_Add_Submit(RequestDTO.AuthorizationRequest model)
		{
			try
			{
				LightingUser lightingUser = new LightingUser();
                var passwordHasher = new PasswordHasher<LightingUser>();
                lightingUser.Firstname = model.Firstname;
				lightingUser.Lastname = model.Lastname;
				lightingUser.UserName = model.UserName;				
				lightingUser.Email = model.Email;
				lightingUser.EmailConfirmed = false;
				var CoutDB = await _context.Users.ToListAsync();
                lightingUser.EmployeeCode = lightingUser.UserName == null ? "" : lightingUser.UserName;
				lightingUser.EmployeeCodeInt = CoutDB.Count() + 1;
				lightingUser.NormalizedUserName = model.UserName;
				lightingUser.NormalizedEmail = "";
                lightingUser.PasswordHash = passwordHasher.HashPassword(lightingUser, model.password);
				_context.Users.Add(lightingUser);
				await _context.SaveChangesAsync();
                return new JsonResult(new { status = "success", messageArray = "success" });
            }
			catch (Exception error)
			{
                throw new Exception(error?.InnerException?.ToString() ?? "error " + error?.Message);
            }
		}

        public IActionResult Authorization_Edit(string? Id)
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAuthorization(string? Id)
		{
			try
			{
				var GetDB = await _context.Users.Where(x=>x.Id == Id).FirstOrDefaultAsync();
				if (GetDB is not null)
				{
                    return Ok(GetDB);
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
		public async Task<IActionResult> Authorization_Edit_Submit(RequestDTO.AuthorizationRequest model)
		{
			try
			{
				var GetDB = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (GetDB is not null)
                {
                    var passwordHasher = new PasswordHasher<LightingUser>();
					GetDB.Firstname = model.Firstname;
					GetDB.Lastname = model.Lastname;
                    GetDB.UserName = model.UserName;
					GetDB.Email = model.Email;
					GetDB.PasswordHash = passwordHasher.HashPassword(GetDB, model.password);
					_context.Entry(GetDB).State = EntityState.Modified;
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
		public async Task<IActionResult> Authorization_Delete(string? Id) 
		{
			try
			{
				var GetDB = _context.Users.FirstOrDefault(x => x.Id == Id);
				if (GetDB is not null)
				{
					_context.Users.Remove(GetDB);
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
	}
}
