using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_Report_MeetingData : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public DateTime? year { get; set; }
        public int? active_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
