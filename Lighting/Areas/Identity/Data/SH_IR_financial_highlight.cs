using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_financial_highlight : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? detailsTitleTH { get; set; }
        public string? detailsTitleENG { get; set; }
        public string? profitTitleTH { get; set; }
        public string? profitTitleENG { get; set; }
        public DateTime? date1Title { get; set; }
        public DateTime? date2Title { get; set; }
        public DateTime? date3Title { get; set; }
        public string? detailsTH { get; set; }
        public string? detailsENG { get; set; }
        public string? image_name { get; set; }
        public string? image_name_ENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
