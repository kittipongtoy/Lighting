namespace Lighting.Models
{
    public class RequestDTO
    {
        public class HistoryDataDetailRequest
        {
            public int? Id { get; set; }
            public int? TypeData { get; set; }
            public string? ImageTH { get; set; }
            public string? ImageEN { get; set; }
            public string? FileVideoTH { get; set; }
            public string? FileVideoEN { get; set; }
            public int? Status { get; set; }
            public List<IFormFile> uploaded_ImageTH { get; set; }
            public List<IFormFile> uploaded_ImageEN { get; set; }
            public List<IFormFile> uploaded_fileTH { get; set; }
            public List<IFormFile> uploaded_fileEN { get; set; }
        }

        public class IR_Summary_Financial_HighlightsRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_LIGHTING_EQUIPMENTRequest
        {
            public int? Id { get; set; }
            public string? Image { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public string? RegisterTH { get; set; }
            public string? RegisterEN { get; set; }
            public int? Status { get; set; }
            public List<IFormFile> uploaded_Image { get; set; }
        }

        public class IR_Button_Below_BannerRequest
        {
            public int Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public int? Status { get; set; }
            public List<IFormFile> uploaded_Image { get; set; }
        }

        public class IR_BannerRequest
        {
            public int? Id { get; set; }
            public int? Status { get; set; }
            public List<IFormFile> uploaded_Image { get; set; }
        }

        public class HistoryDetailRequest
        {
			public int? Id { get; set; }
			public string? Title_TH { get; set; }
			public string? Title_EN { get; set; }
			public string? ImageTH { get; set; }
			public string? ImageEN { get; set; }
			public string? Detail_TH { get; set; }
			public string? Detail_EN { get; set; }
			public string? FileCompany_TH { get; set; }
			public string? FileCompany_EN { get; set; }
			public int? Status { get; set; }
			public List<IFormFile> uploaded_fileTH { get; set; }
			public List<IFormFile> uploaded_fileEN { get; set; }
			public List<IFormFile> uploaded_ImageTH { get; set; }
			public List<IFormFile> uploaded_ImageEN { get; set; }
		}

        public class ORGANIZATION_CHARTRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }


        public class HistoryRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_ChartRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_ChartDetailRequest
        {
            public int? Id { get; set; }
            public string? Link_IR_Stock_Chart { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_LinkRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_LinkDetailRequest
        {
            public int? Id { get; set; }
            public string? Link_IR_Stock_Link { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_QuoteRequest
        {
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_QuoteDetailRequest
        {
            public int? Id { get; set; }
            public string? STOCK_PRICE_TH { get; set; }
            public string? STOCK_PRICE_EN { get; set; }
            public string? Link_STOCK_PRICE { get; set; }
            public string? SET_INDEX_TH { get; set; }
            public string? SET_INDEX_EN { get; set; }
            public string? Link_SET_INDEX_TH { get; set; }
            public string? Link_SET_INDEX_EN { get; set; }
            public int? Status { get; set; }
        }

        public class AuthorizationRequest
        { 
            public string? Id { get; set; }
            public string? Firstname { get; set; }
            public string? Lastname { get; set; }
            public string? UserName { get; set; }
            public string? password { get; set; }
            public string? Email { get; set; }
        }

        public class IR_Analyst_ChapterRequest
        {
            public int Id { get; set; }
            public string? FileName_TH { get; set; }
            public string? FileName_EN { get; set; }
            public int? Status { get; set; }
            public List<IFormFile> uploaded_fileTH { get; set; }
            public List<IFormFile> uploaded_fileEN { get; set; }
        }

        public class IR_AnalystRequest
        {
            public int? Id { get; set; }
            public string? FileName_TH { get; set; }
            public string? FileName_EN { get; set; }
            public int? Status { get; set; }
            public List<IFormFile> uploaded_fileTH { get; set; }
            public List<IFormFile> uploaded_fileEN { get; set; }
        }

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
            public List<IFormFile> uploaded_image { get; set; }
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
            public List<IFormFile> uploaded_Image { get; set; }
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
            public List<IFormFile> uploaded_Image { get; set; }
            public List<IFormFile> uploaded_fileTH { get; set; }
            public List<IFormFile> uploaded_fileEN { get; set; }
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
            public List<IFormFile> uploaded_fileTH { get; set; }
            public List<IFormFile> uploaded_fileEN { get; set; }
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
            public List<IFormFile> uploaded_fileTH { get; set; }
            public List<IFormFile> uploaded_fileEN { get; set; }
        }
    }
}
