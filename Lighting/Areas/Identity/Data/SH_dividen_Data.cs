using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_dividen_Data : IProperty
    {
        [Key] 
        public int id { get; set; }
        public string? title { get; set; } 
        public DateTime? dateOfBoard { get; set; }
        public DateTime? dateMaking { get; set; }
        public DateTime? paymentDate { get; set; }
        public string? dividenTypeTitleTH { get; set; }
        public string? dividenTypeTitleENG { get; set; }
        public string? amount { get; set; }
        public string? earningDayTitleTH { get; set; }
        public string? earningDayTitleENG { get; set; }
        public int? use_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
