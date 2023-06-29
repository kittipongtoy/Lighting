namespace Lighting.Areas.Identity.GeneraIProperty
{
	public enum IsActive
	{
		Yes = 1,
		No = 0,
	}

	public enum IsEnabled
	{
		Yes = 1,
		No = 0,
	}

	public interface IProperty
	{
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }
	}
}
