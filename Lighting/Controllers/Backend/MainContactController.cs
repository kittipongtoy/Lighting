using Lighting.Areas.Identity.Data;
using Lighting.Models.InputFilterModels.MainContact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MainContact = Lighting.Models.InputFilterModels.MainContact.MainContact;

namespace Lighting.Controllers.Backend
{
    public class MainContactController : Controller
    {
        private readonly LightingContext _db;
        private readonly IWebHostEnvironment _env;
        public MainContactController(IWebHostEnvironment env, LightingContext db)
        {

            _env = env;
            _db = db;

        }
        public IActionResult Manage_Page()
        {
            var contact = _db.MainContacts.FirstOrDefault();
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> Save([FromForm] MainContact input)
        {
            try
            {
                var path = Path.Combine("upload_image", "MainContact");
                var mainContact = await _db.MainContacts.FirstOrDefaultAsync();
                if (mainContact != null)
                {
                    if (input.Img_File != null)
                    {
                        if (mainContact.Img_File != null)
                        {
                            var oldFile = Path.Combine(_env.WebRootPath, mainContact.Img_File);
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, input.Img_File.FileName), FileMode.Create))
                        {
                            await input.Img_File.CopyToAsync(stream);
                        }
                    }

                    mainContact.EMail1 = input.EMail1;
                    mainContact.EMail2 = input.EMail2;
                    mainContact.GoogleMapLink = input.GoogleMapLink;
                    mainContact.Location_EN = input.Location_EN;
                    mainContact.Location_TH = input.Location_TH;
                    mainContact.TitleName_EN = input.TitleName_EN;
                    mainContact.TitleName_TH = input.TitleName_TH;
                    mainContact.MoreInfo = input.MoreInfo;
                    mainContact.OfficePhone = input.OfficePhone;
                    mainContact.PhoneNumber = input.PhoneNumber;
                    mainContact.Img_File = input.Img_File == null ? mainContact.Img_File : Path.Combine(path, input.Img_File.FileName);
                    mainContact.TitleEMail1 = input.TitleEMail1;
                    mainContact.TitleEMail2 = input.TitleEMail2;
                    mainContact.Title_EN = input.Title_EN;
                    mainContact.Title_TH = input.Title_TH;

                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
                else
                {
                    if (input.Img_File != null)
                    {
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, input.Img_File.FileName), FileMode.Create))
                        {
                            await input.Img_File.CopyToAsync(stream);
                        }
                    }

                    await _db.MainContacts.AddAsync(new Areas.Identity.Data.MainContact
                    {
                        EMail1 = input.EMail1,
                        EMail2 = input.EMail2,
                        GoogleMapLink = input.GoogleMapLink,
                        Location_EN = input.Location_EN,
                        Location_TH = input.Location_TH,
                        TitleName_EN = input.TitleName_EN,
                        TitleName_TH = input.TitleName_TH,
                        MoreInfo = input.MoreInfo,
                        OfficePhone = input.OfficePhone,
                        PhoneNumber = input.PhoneNumber,
                        Img_File = input.Img_File == null ? null : Path.Combine(path, input.Img_File.FileName),
                        TitleEMail1 = input.TitleEMail1,
                        TitleEMail2 = input.TitleEMail2,
                         Title_EN = input.Title_EN,
                          Title_TH = input.Title_TH,
                    });
                    await _db.SaveChangesAsync();
                    return Json(new { status = "success", message = "บันทึกข้อมูลเรียบร้อย" });
                }
            }catch(Exception ex)
            {
                return Json(new { status = "error", message = "ไม่พบข้อมูล" ,inner=ex.Message});
            }

        }
    }
}
