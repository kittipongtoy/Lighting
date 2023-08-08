using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lighting.Controllers.Backend
{
    [Authorize]
    public class ManageContactController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly string _rootPath;
        public ManageContactController(LightingContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
            _rootPath = _env.WebRootPath;
        }

        //public async Task<ActionResult> Index()
        //{
        //    var contact = await _db.Contacts.AsNoTracking().Select(contact => new Output_ContactVM
        //    {
        //        Id = contact.Id,
        //        CellPhone = contact.CellPhone,
        //        ContactType = contact.ContactType,
        //        Email = contact.Email,
        //        GoogleMaps_Url = contact.GoogleMaps_Url,
        //        ImagePath = contact.ImagePath,
        //        Location_EN = contact.Location_EN,
        //        Location_TH = contact.Location_TH,
        //        OfficePhone = contact.OfficePhone,
        //        PlaceName_EN = contact.PlaceName_EN,
        //        PlaceName_TH = contact.PlaceName_TH,
        //        TelePhone = contact.TelePhone,
        //        YouTube_Url = contact.YouTube_Url,
        //    }).ToListAsync();

        //    if (contact != null)
        //    {
        //        return View(contact);
        //    }

        //    var empty_contact = new List<Output_ContactVM>();
        //    return View(empty_contact);
        //}

        public async Task<IActionResult> Edit_Page(int id)
        {
            var contact = await _db.Contacts.AsNoTracking().Where(contact => contact.Id == id).FirstOrDefaultAsync();

            if (contact != null)
            {
                var output_model = new Output_ContactVM
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
                    YouTube_Url_EN = contact.YouTube_Url_EN,
                    YouTube_Url_TH = contact.YouTube_Url_TH,
                    Sub_Factory_Name_EN = contact.Sub_Factory_Name_EN,
                    Sub_Factory_Name_TH = contact.Sub_Factory_Name_TH
                };
                return View(output_model);
            }
            return RedirectToAction("Manage_Contact_Page");
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] Input_ContactVM input_Contact, [FromQuery] int id)
        {

            if (ModelState.IsValid)
            {

                var new_file_name = Guid.NewGuid().ToString().Substring(0, 5);
                var save_path = Path.Combine("upload_image", "contact", new_file_name + ".jpg");
                var save_file = Path.Combine(_rootPath, save_path);
                var contact = await _db.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);
                if (contact == null) { return Json(new { status = "error", message = "ไม่พบข้อมูล" }); }
                try
                {
                    if (input_Contact.Image != null) //if new image
                    {
                        #region delete old file
                        if (contact.ImagePath != null)
                        {
                            var path_old_file = Path.Combine(_rootPath, contact.ImagePath);

                            if (System.IO.File.Exists(path_old_file))
                                System.IO.File.Delete(path_old_file);
                        }
                        #endregion 

                        using (var file_stream = new FileStream(save_file, FileMode.Create))
                        {
                            await input_Contact.Image.CopyToAsync(file_stream);
                        }
                    }

                    contact.ContactType = input_Contact.ContactType;
                    contact.Sub_Factory_Name_EN = input_Contact.Sub_Factory_Name_EN;
                    contact.Sub_Factory_Name_TH = input_Contact.Sub_Factory_Name_TH;
                    contact.PlaceName_EN = input_Contact.PlaceName_EN;
                    contact.PlaceName_TH = input_Contact.PlaceName_TH;
                    contact.Location_TH = input_Contact.Location_TH;
                    contact.Location_EN = input_Contact.Location_EN;
                    contact.CellPhone = input_Contact.CellPhone;
                    contact.TelePhone = input_Contact.TelePhone;
                    contact.OfficePhone = input_Contact.OfficePhone;
                    contact.Email = input_Contact.Email;
                    contact.GoogleMaps_Url = input_Contact.GoogleMaps_Url;
                    contact.YouTube_Url_TH = input_Contact.YouTube_Url_TH;
                    contact.YouTube_Url_EN = input_Contact.YouTube_Url_EN;
                    contact.ImagePath = input_Contact.Image != null ? save_path.Replace("\\", "/") : contact.ImagePath;

                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    if (System.IO.File.Exists(save_file))
                    {
                        System.IO.File.Delete(save_file);
                    }
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }

            return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }

        public async Task<IActionResult> Manage_Contact_Page()
        {
            var contacts = await _db.Contacts
                .AsNoTracking()
                .OrderByDescending(contact => contact.Id)
                .Select(contact => new Output_ContactVM
                {
                    Id = contact.Id,
                    CellPhone = contact.CellPhone,
                    TelePhone = contact.TelePhone,
                    OfficePhone = contact.OfficePhone,
                    ContactType = contact.ContactType,
                    Email = contact.Email,
                    GoogleMaps_Url = contact.GoogleMaps_Url,
                    ImagePath = contact.ImagePath,
                    Location_EN = contact.Location_EN,
                    Location_TH = contact.Location_TH,
                    PlaceName_EN = contact.PlaceName_EN,
                    PlaceName_TH = contact.PlaceName_TH,
                    YouTube_Url_EN = contact.YouTube_Url_EN,
                    YouTube_Url_TH = contact.YouTube_Url_TH,
                    Sub_Factory_Name_TH = contact.Sub_Factory_Name_TH,
                    Sub_Factory_Name_EN = contact.Sub_Factory_Name_EN
                })
                .ToListAsync();

            return View(contacts);
        }

        public async Task<IActionResult> DeleteById(int id)
        {
            var contact = await _db.Contacts.FirstOrDefaultAsync(contact => contact.Id == id);
            if (contact != null)
            {
                try
                {
                    if (contact.ImagePath != null)
                    {
                        var path = Path.Combine(_rootPath, contact.ImagePath.Replace("/", "\\"));
                        if (System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }
                    }
                    _db.Contacts.Remove(contact);
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }
            return Json(new { status = "error", message = "ไม่พบข้อมูล" });
        }

        public ActionResult Add_Contact_Page()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add_Contact([FromForm] Input_ContactVM input_Contact)
        {

            if (ModelState.IsValid)
            {

                var new_file_name = Guid.NewGuid().ToString().Substring(0, 5);
                var save_path = Path.Combine("upload_image", "contact", new_file_name + ".jpg");
                var save_file = Path.Combine(_rootPath, save_path);
                try
                {
                    if (input_Contact.Image != null)
                    {
                        using (var file_stream = new FileStream(save_file, FileMode.Create))
                        {
                            await input_Contact.Image.CopyToAsync(file_stream);
                        }
                    }

                    _db.Contacts.Add(new Contact
                    {
                        ContactType = input_Contact.ContactType,
                        Sub_Factory_Name_EN = input_Contact.Sub_Factory_Name_EN,
                        Sub_Factory_Name_TH = input_Contact.Sub_Factory_Name_TH,
                        PlaceName_EN = input_Contact.PlaceName_EN,
                        PlaceName_TH = input_Contact.PlaceName_TH,
                        Location_TH = input_Contact.Location_TH,
                        Location_EN = input_Contact.Location_EN,
                        CellPhone = input_Contact.CellPhone,
                        TelePhone = input_Contact.TelePhone,
                        OfficePhone = input_Contact.OfficePhone,
                        Email = input_Contact.Email,
                        GoogleMaps_Url = input_Contact.GoogleMaps_Url,
                        YouTube_Url_EN = input_Contact.YouTube_Url_TH,
                        YouTube_Url_TH = input_Contact.YouTube_Url_TH,
                        ImagePath = input_Contact.Image != null ? save_path.Replace("\\", "/") : null,

                    });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                catch (Exception ex)
                {
                    if (System.IO.File.Exists(save_file))
                    {
                        System.IO.File.Delete(save_file);
                    }
                    return Json(new { status = "error", message = ex.Message, inner = ex.InnerException });
                }
            }

            return Json(new { status = "error", message = "กรุณากรอกทุกอย่างให้ครบถ้วน" });
        }

    }
}
