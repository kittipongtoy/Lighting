using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_annual_ReportData : IProperty
    {
        [Key]
        public int id { get; set; }
        public DateTime? year { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? upload_image { get; set; }
        public string? upload_image_ENG { get; set; }
        public string? file_name { get; set; }
        public string? file_name_ENG { get; set; }
        public int? use_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
