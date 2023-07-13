using Lighting.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class IR_StockController : Controller
	{
		private readonly LightingContext _db;
        public IR_StockController(LightingContext db)
        {
            _db = db;
        }
        public IActionResult IR_Stock_Quote_Index()
		{
			return View();
		}

		public IActionResult IR_Stock_Chart_Index() 
		{
			return View();
		}

		public IActionResult IR_Stock_Link_Index()
		{
			return View();
		}
	}
}
