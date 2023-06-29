using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_MDA : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? detailsTitleTH { get; set; }
        public string? detailsTitleENG { get; set; }
        public string? dataTitleTH { get; set; }
        public string? dataTitleENG { get; set; }
        public string? nameTitleTH { get; set; }
        public string? nameTitleENG { get; set; }
        public string? downloadTitleTH { get; set; }
        public string? downloadTitleENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
