using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
	public class M_chairman :IProperty
    {
        [Key]
        public int id { get; set; }
        public string? name_th { get; set; }
        public string? name_en { get; set; }
        public string? rank_th { get; set; }
        public string? rank_en { get; set; }
        public string? image_name_TH { get; set; }
        public string? image_name_EN { get; set; }
        public int? use_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}