using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class IR_IndexController : Controller
    {
        public IActionResult Banner()
        {
            return View();
        }

        public IActionResult TableBanner()
        {
            return View();
        }

        public IActionResult Banner_Add()
        {
            return View();
        }

        public IActionResult Banner_Add_Submit()
        {
            return View();
        }

        public IActionResult Banner_Edit()
        {
            return View();
        }

        public IActionResult GetBanner_Edit()
        {
            return View();
        }

        public IActionResult Banner_Edit_Submit()
        {
            return View();
        }

        public IActionResult Banner_Delete()
        {
            return View();
        }

        public IActionResult Banner_Change()
        {
            return View();
        }

        public IActionResult Button_Below_Banner()
        {
            return View();
        }

		public IActionResult TableButton_Below_Banner()
		{
			return View();
		}

		public IActionResult Button_Below_Banner_Add()
		{
			return View();
		}

		public IActionResult Button_Below_Banner_Add_Submit()
		{
			return View();
		}

        public IActionResult Button_Below_Banner_Edit()
        {
            return View();
        }

        public IActionResult GetButton_Below_Banner_Edit()
        {
            return View();
        }

        public IActionResult Button_Below_Banner_Edit_Submit()
        {
            return View();
        }

        public IActionResult Button_Below_Banner_Delete()
        {
            return View();
        }

        public IActionResult Button_Below_Banner_Change()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT_Aadd()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT_Edit()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT_Delete()
        {
            return View();
        }

        public IActionResult LIGHTING_EQUIPMENT_Change()
        {
            return View();
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
