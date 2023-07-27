using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class privacy_PolicyTitles : IProperty  
    {
        [Key]
        public int id { get; set; }  
        public string? headTitleTH { get; set; }
        public string? headTitleENG { get; set; }
        public string? privacy_TitleTH { get; set; }
        public string? privacy_TitleENG { get; set; }
        public string? privacy_NoticeTitleTH { get; set; }
        public string? privacy_NoticeTitleENG { get; set; }
        public string? cctv_privacyTitleTH { get; set; }
        public string? cctv_privacyTitleENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
