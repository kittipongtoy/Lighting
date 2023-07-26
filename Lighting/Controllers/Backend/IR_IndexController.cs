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

        public IActionResult Banner_Button()
        {
            return View();
        }

		public IActionResult TableBanner_Button()
		{
			return View();
		}

		public IActionResult Banner_Button_Add()
		{
			return View();
		}

		public IActionResult Banner_Button_Add_Submit()
		{
			return View();
		}

        public IActionResult Banner_Button_Edit()
        {
            return View();
        }

        public IActionResult GetBanner_Button_Edit()
        {
            return View();
        }

        public IActionResult Banner_Button_Edit_Submit()
        {
            return View();
        }

        public IActionResult Banner_Button_Delete()
        {
            return View();
        }

        public IActionResult Banner_Button_Change()
        {
            return View();
        }

	}
}
