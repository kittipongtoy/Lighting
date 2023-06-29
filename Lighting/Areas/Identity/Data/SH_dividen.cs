using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_dividen : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? detailsTitleTH { get; set; }
        public string? detailsTitleENG { get; set; }
        public string? detailsTH { get; set; }
        public string? detailsENG { get; set; }
        public string? securityTitleTH { get; set; }
        public string? securityTitleENG { get; set; }
        public string? dateOfBoardTitleTH { get; set; }
        public string? dateOfBoardTitleENG { get; set; }
        public string? dateMakingTitleTH { get; set; }
        public string? dateMakingTitleENG { get; set; }
        public string? paymentDateTitleTH { get; set; }
        public string? paymentDateTitleENG { get; set; }
        public string? dividenTypetitleTH { get; set; }
        public string? dividenTypetitleENG { get; set; }
        public string? amountTitleTH { get; set; }
        public string? amountTitleENG { get; set; }
        public string? earningDayTitleTH { get; set; }
        public string? earningDayTitleENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
