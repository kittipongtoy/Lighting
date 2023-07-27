using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class HistoryDetail : IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? Title_TH { get; set; }
        public string? Title_EN { get; set; }
        public string? ImageTH { get; set; }
        public string? ImageEN { get; set; }
        public string? Detail_TH { get; set; }
        public string? Detail_EN { get; set; }
        public string? FileCompany_TH { get; set; }
        public string? FileCompany_EN { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
