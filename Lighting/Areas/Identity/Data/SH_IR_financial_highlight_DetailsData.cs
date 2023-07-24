using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_financial_highlight_DetailsData : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? profitTitleTH { get; set; }
        public string? profitTitleENG { get; set; } 
        public int? financial_hilight_id { get; set; }
        public int? active_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
