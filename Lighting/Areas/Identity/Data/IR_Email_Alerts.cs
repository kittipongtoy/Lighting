using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class IR_Email_Alerts : IProperty
    {
        [Key]
        public int Id { get; set; }
		public string? Title_TH { get; set; }
		public string? Title_EN { get; set; }
		public string? SubTitle_TH { get; set; }
		public string? SubTitle_EN { get; set; }
		public string? Text_Register_TH { get; set; }
		public string? Text_Register_EN { get; set; }
		public string? Text_Input_Email_TH { get; set; }
		public string? Text_Input_Email_EN { get; set; }
		public string? Policy_TH { get; set; }
		public string? Policy_EN { get; set; }
		public string? Note_TH { get; set; }
		public string? Note_EN { get; set; }
		public string? Button_Submit_TH { get; set; }
		public string? Button_Submit_EN { get; set; }
		public int? Status { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }
	}
}
