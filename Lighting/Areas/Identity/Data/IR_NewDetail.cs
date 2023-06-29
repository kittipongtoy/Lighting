using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class IR_NewDetail : IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? Title_TH { get; set; }
        public string? Title_EN { get; set; }
        public DateTime? NewDate { get; set; }
        public string? Detail_TH { get; set; }
        public string? Detail_EN { get; set; }
        public string? FileName_TH { get; set; }
        public string? FileName_EN { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
