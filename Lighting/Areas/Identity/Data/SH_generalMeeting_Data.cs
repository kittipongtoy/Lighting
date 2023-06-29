using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_generalMeeting_Data : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? file_name { get; set; }
        public string? file_name_ENG { get; set; }
        public int? use_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
