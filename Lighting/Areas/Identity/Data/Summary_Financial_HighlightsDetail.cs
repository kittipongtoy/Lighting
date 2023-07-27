using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Summary_Financial_HighlightsDetail :IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? Icon { get; set; }
        public string? SummaryTotal { get; set; }
        public string? SummaryDetail { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
