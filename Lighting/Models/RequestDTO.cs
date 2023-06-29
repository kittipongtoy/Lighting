namespace Lighting.Models
{
    public class RequestDTO
    {
        public class IR_ComplaintsRequest
        {
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
		}

		public class IR_faqDetailRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_faqRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Request_InquiryRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public string? TitleText_Input_Name_TH { get; set; }
            public string? TitleText_Input_Name_EN { get; set; }
            public string? TitleText_Input_Tel { get; set; }
            public string? Text_Input_Email { get; set; }
            public string? Policy_TH { get; set; }
            public string? Policy_EN { get; set; }
            public string? Note_TH { get; set; }
            public string? Note_EN { get; set; }
            public string? Button_Submit_TH { get; set; }
            public string? Button_Submit_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Cancel_EmailRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public string? Text_TH { get; set; }
            public string? Text_EN { get; set; }
            public string? Input_Text_TH { get; set; }
            public string? Input_Text_EN { get; set; }
            public string? Button_Submit_TH { get; set; }
            public string? Button_Submit_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Email_AlertsRequest
        {
            public int? Id { get; set; }
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
        }

        public class IR_ContactRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public string? Name_TH { get; set; }
            public string? Name_EN { get; set; }
            public string? Position_TH { get; set; }
            public string? Position_EN { get; set; }
            public string? Address_TH { get; set; }
            public string? Address_EN { get; set; }
            public string? Tel { get; set; }
            public string? Tel2 { get; set; }
            public string? Email { get; set; }
            public int? Status { get; set; }
        }

        public class Stock_MarketRequest
        {
            public int Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class Latest_NewsRequest
        {
            public int Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class InvestorCalendarRequest
        {
            public int Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class Print_MediaRequest
        {
            public int Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }
        public class Mass_MediaRequest
        {
            public int Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class Last_NewsDetailRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Mass_MediaRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public string? Question_TH { get; set; }
            public string? Question_EN { get; set; }
            public string? ContactUs_Name1_TH { get; set; }
            public string? ContactUs_Name1_EN { get; set; }
            public string? ContactUs_Name2_TH { get; set; }
            public string? ContactUs_Name2_EN { get; set; }
            public string? ContactUs_Tel { get; set; }
            public string? ContactUs_Tel2 { get; set; }
            public string? ContactUs_Mail1 { get; set; }
            public string? ContactUs_Mail2 { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Print_MedialDetailRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class InvestorCalendarDetailRequest
        {
            public int? Id { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Activity_TH { get; set; }
            public string? Activity_EN { get; set; }
            public string? Position_TH { get; set; }
            public string? Position_EN { get; set; }
            public string? FileName { get; set; }
            public int? Status { get; set; }
        }

        public class IR_NewDetailRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }
    }
}
