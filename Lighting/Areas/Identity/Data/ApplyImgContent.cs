using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class ApplyImgContent
    {
        [Key]
        public int Id { get; set; }
        public string? Position_img { get; set; }
        public string? Benefit_img { get; set; }
        public string? Position_pdf { get; set; }
        public string? Benefit_pdf { get; set; }
    }
}
