using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_Form : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? detailsTitleTH { get; set; }
        public string? detailsTitleENG { get; set; }
        public string? nameTitleTH { get; set; }
        public string? nameTitleENG { get; set; }
        public string? yearTitleTH { get; set; }
        public string? yearTitleENG { get; set; }
        public string? dateConfrimTitleTH { get; set; }
        public string? dateConfrimTitleENG { get; set; }
        public string? detailsTH { get; set; }
        public string? detailsENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
