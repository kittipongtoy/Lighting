using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SettingIndex : IProperty
    {
        [Key]
        public int id_setting { get; set; }
        public string? titleTH1 { get; set; }
        public string? titleENG1 { get; set; }
        public string? titleTH2 { get; set; }
        public string? titleENG2 { get; set; }
        public string? titlesubTH2 { get; set; }
        public string? titlesubENG2 { get; set; }

        public string? DescriptTH2 { get; set; }
        public string? DescriptENG2 { get; set; }
        public string? titleTH3 { get; set; }
        public string? titleENG3 { get; set; }
        public string? DescriptTH3 { get; set; }
        public string? DescriptENG3 { get; set; }
        public string? titleTH4 { get; set; }
        public string? titleENG4 { get; set; }
        public string? titlesubTH4 { get; set; }
        public string? titlesubENG4 { get; set; }

        public string? PathImg { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
