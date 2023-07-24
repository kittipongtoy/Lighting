using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_financial_highlight_DetailsData_Items : IProperty
    {
        [Key]
        public int id { get; set; }
        public DateTime? year { get; set; }
        public string? amount { get; set; }
        public int? fH_Details_id { get; set; }
        public int? fH_DetailsData_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
