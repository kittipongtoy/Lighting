using Microsoft.AspNetCore.Mvc;

namespace Lighting.Controllers.Frontend
{
    public class ProductController : Controller
    {
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Product_Category()
        {
            return View();
        }

        public IActionResult Product_Subcategory()
        {
            return View();
        }

        public IActionResult Product_Detail()
        {
            return View();
        }  
    }
}
