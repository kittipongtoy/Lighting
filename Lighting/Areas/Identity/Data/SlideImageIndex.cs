using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SlideImageIndex : IProperty
    {
        [Key]
        public int id_slideimg_index { get; set; }
        public string? PathImg { get; set; }
        public bool isActive { get; set; } = true;
        public int? sort { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
