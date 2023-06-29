using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class CorporateGovernance_Cate : IProperty
	{
        [Key]
        public int id { get; set; }
        public string? detail_th { get; set; }
        public string? detail_en { get; set; }
        public string? title_th { get; set; }
        public string? title_en { get; set; }
        public int? use_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}