using Lighting.Areas.Identity.GeneraIProperty;
using Microsoft.AspNetCore.Identity;

namespace Lighting.Areas.Identity.Data
{
	public class Role : IdentityRole, IProperty
	{
		public Role() : base() { }
		
		public string? NameThai { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }
	}
}
