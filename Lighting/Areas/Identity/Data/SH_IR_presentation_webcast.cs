using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_presentation_webcast : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? detailsTitleTH { get; set; }
        public string? detailsTitleENG { get; set; }
        public string? activitytitleTH { get; set; }
        public string? activitytitleENG { get; set; }
        public string? webcastTitleTH { get; set; }
        public string? webcastTitleENG { get; set; }
        public string? downloadtitleTH { get; set; }
        public string? downloadtitleENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
