using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_generalMeeting : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? detailsTitleTH { get; set; }
        public string? detailsTitleENG { get; set; }
        public string? image_name { get; set; }
        public string? image_name_ENG { get; set; }
        public string? link { get; set; }
        public string? meetingTitleTH { get; set; }
        public string? meetingTitleENG { get; set; }
        public string? downloadTitleTH { get; set; }
        public string? downloadTitleENG { get; set; } 
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
