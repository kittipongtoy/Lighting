using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
	public class Company_Overview : IProperty
	{
        [Key]
        public int id { get; set; }
        public string? image_name { get; set; }
        public int? use_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}