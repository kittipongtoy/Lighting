using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class MainContact
    {
        [Key]
        public int Id { get; set; }
        public string? Title_EN { get; set; }
        public string? TitleName_EN { get; set; }
        public string? Location_EN { get; set; }
        public string? Title_TH { get; set; }
        public string? TitleName_TH { get; set; }
        public string? Location_TH { get; set; }
        public string? PhoneNumber { get; set; }
        public string? OfficePhone { get; set; }
        public string? TitleEMail1 { get; set; }
        public string? EMail1 { get; set; }
        public string? TitleEMail2 { get; set; }
        public string? EMail2 { get; set; }
        public string? GoogleMapLink { get; set; }
        public string? MoreInfo { get; set; }
        public string? Img_File { get; set; }
        public string? Img_FileEN { get; set; }
    }
}
