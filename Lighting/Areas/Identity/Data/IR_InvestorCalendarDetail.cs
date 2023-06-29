using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class IR_InvestorCalendarDetail : IProperty
    {
        [Key]
        public int Id { get; set; }
        public DateTime? NewDate { get; set; }
        public string? Activity_TH { get; set; }
        public string? Activity_EN { get; set; }
        public string? Position_TH { get; set; }
        public string? Position_EN { get; set; }
        public string? FileNameTH { get; set; }
        public string? FileNameEN { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
