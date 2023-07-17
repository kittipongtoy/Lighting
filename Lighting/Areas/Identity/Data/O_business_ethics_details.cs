using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class O_business_ethics_details : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? title_TH { get; set; }
        public string? title_ENG { get; set; }
        public string? image_name { get; set; }
        public string? image_name_ENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
