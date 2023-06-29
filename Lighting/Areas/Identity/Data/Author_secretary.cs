using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
	public class Author_secretary : IProperty
	{
		[Key]
		public int id { get; set; }
		public string? detail_th { get; set; }
		public string? detail_en { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }
	}
}
