using Lighting.Areas.Identity.GeneraIProperty;
using Microsoft.AspNetCore.Identity;

namespace Lighting.Areas.Identity.Data
{
	public class LightingUser : IdentityUser, IProperty
    {
        public LightingUser() : base() { }

		public string EmployeeCode { get; set; } = string.Empty;
		public int EmployeeCodeInt { get; set; } = 0;
		public string? Firstname { get; set; }
		public string? Lastname { get; set; }
		public string? Address { get; set; }
		public string? ProfilePath { get; set; }
		public IsActive? Isactive { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }

		public string? ReceptionistFile { get; set; }
		public string? ApplicationFile { get; set; }
		public string? GuarantorIdentificationCardFile { get; set; }

	}
}
