using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

		public IActionResult Table_IR_Stock_Quote()
		{
			return View();
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
