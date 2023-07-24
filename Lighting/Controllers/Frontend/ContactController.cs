using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Contact;
using Microsoft.AspNetCore.Mvc;
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
                Location_EN = contact.Location_EN,
                Location_TH = contact.Location_TH,
                OfficePhone = contact.OfficePhone,
                PlaceName_EN = contact.PlaceName_EN,
                PlaceName_TH = contact.PlaceName_TH,
                TelePhone = contact.TelePhone,
                YouTube_Url = contact.YouTube_Url,
            }).ToListAsync();

            if (contact != null)
            {
                return View(contact);
            }

            var empty_contact = new List<Output_ContactVM>();
            return View(empty_contact);
        }
    }
}
