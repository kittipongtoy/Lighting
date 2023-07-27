using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class RF_Oversea_Offices_Images : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? upload_image { get; set; }
        public string? upload_image_ENG { get; set; }
        public int active_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
