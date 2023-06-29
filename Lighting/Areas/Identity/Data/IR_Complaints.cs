using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
	public class IR_Complaints : IProperty
	{
		[Key]
		public int Id { get; set; }
		public string? Title_TH { get; set; }
		public string? Title_EN { get; set; }
		public string? SubTitle_TH { get; set; }
		public string? SubTitle_EN { get; set; }
		public string? TypeContactUS_TH { get; set; }
		public string? TypeContactUS_EN { get; set; }	
		public string? Detail_TH { get; set; }
		public string? Detail_EN { get; set; }
		public string? Input_Detail_TH { get; set; }
		public string? Input_Detail_EN { get; set; }
		public string? Title_File_TH { get; set; }
		public string? Title_File_EN { get; set; }
		public string? Title_Description_TH { get; set; }
		public string? Title_Description_EN { get; set; }
		public string? Button_Submit_Title_UploadFile_TH { get; set; }
		public string? Button_Submit_Title_UploadFile_EN { get; set; }
        public string? Title_TypeContact_TH { get; set; }
        public string? Title_TypeContact_EN { get; set; }
        public string? Title_Contact_Name_TH { get; set; }
		public string? Title_Contact_Name_EN { get; set; }
		public string? Title_Contact_Email_TH { get; set; }
		public string? Title_Contact_Email_EN { get; set; }
		public string? Title_Contact_Tel_TH { get; set; }
		public string? Title_Contact_Tel_EN { get; set; }
		public string? Title_Contact_Other_TH { get; set; }
		public string? Title_Contact_Other_EN { get; set; }
		public string? Title_Contact_Note_TH { get; set; }
		public string? Title_Contact_Note_EN { get; set; }
		public string? Button_Submit_TH { get; set; }
		public string? Button_Submit_EN { get; set; }
		public int? Status { get; set; }
		public DateTime? created_at { get; set; }
		public DateTime? updated_at { get; set; }
	}
}
