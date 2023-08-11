using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Contact;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Frontend
{
    public class ContactController : Controller
    {
        private readonly LightingContext _db;

        public ContactController(LightingContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> MainContactJson()
        {
            var lang = Request.Cookies["lang"];
            if (lang == "EN")
            {
                return Json(await _db.MainContacts.Select(main => new
                {
                    companyName = main.TitleName_EN,
                    EMail1 = main.EMail1,
                    location = main.Location_EN,
                    officePhone = main.OfficePhone,
                    googleMapLink = main.GoogleMapLink,
                }).FirstOrDefaultAsync());
            }
            else
            {
                return Json(await _db.MainContacts.Select(main => new
                {
                    companyName = main.TitleName_TH,
                    EMail1 = main.EMail1,
                    location = main.Location_TH,
                    officePhone = main.OfficePhone,
                    googleMapLink = main.GoogleMapLink,
                }).FirstOrDefaultAsync());
            }

        }
        public async Task<ActionResult> Contact()
        {
            var contact = await _db.Contacts
                .AsNoTracking()
                .OrderByDescending(contact => contact.Id)
                .Select(contact => new Output_ContactVM
                {
                    Id = contact.Id,
                    CellPhone = contact.CellPhone,
                    ContactType = contact.ContactType,
                    Email = contact.Email,
                    GoogleMaps_Url = contact.GoogleMaps_Url,
                    ImagePath = contact.ImagePath,
                    ImagePathEN = contact.ImagePathEN,
                    Location_EN = contact.Location_EN,
                    Location_TH = contact.Location_TH,
                    OfficePhone = contact.OfficePhone,
                    PlaceName_EN = contact.PlaceName_EN,
                    PlaceName_TH = contact.PlaceName_TH,
                    TelePhone = contact.TelePhone,
                     YouTube_Url_EN = contact.YouTube_Url_EN,
                      YouTube_Url_TH = contact.YouTube_Url_TH,
                    Sub_Factory_Name_EN = contact.Sub_Factory_Name_EN,
                    Sub_Factory_Name_TH = contact.Sub_Factory_Name_TH
                }).ToListAsync();

            var main_contact = await _db.MainContacts.FirstOrDefaultAsync();
            ViewData["mainContact"] = main_contact;

            if (contact != null)
            {
                return View(contact);
            }

            var empty_contact = new List<Output_ContactVM>();
            return View(empty_contact);
        }
    }
}
