using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class cookies_policy : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? headTitleTH { get; set; }
        public string? headTitleENG { get; set; }
        public string? detailsTH { get; set; }
        public string? detailsENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
