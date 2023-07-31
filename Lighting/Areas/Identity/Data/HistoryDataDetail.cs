using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class HistoryDataDetail : IProperty
    {
        [Key]
        public int Id { get; set; }
        public int? TypeData { get; set; }
        public string? ImageTH { get; set; }
        public string? ImageEN { get; set; }
        public string? FileVideoTH { get; set; }
        public string? FileVideoEN { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
