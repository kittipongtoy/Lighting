using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class IR_HightlightDetail : IProperty
    {
        [Key]
        public int Id { get; set; }
        public int SetType { get; set; }
        public string? Background { get; set; }
        public string? Title_TH { get; set; }
        public string? Title_EN { get; set; }
        public string? SubTitle_TH { get; set; }
        public string? SubTitle_EN { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
