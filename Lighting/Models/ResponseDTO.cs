﻿using Lighting.Areas.Identity.Data;

namespace Lighting.Models
{
    public class ResponseDTO
    {
        public class DownloadResponse
        {
            public int? Index { get; set; }
            public int id { get; set; }
            public int? DownloadType_id { get; set; }
            public string? Name_EN { get; set; }
            public string? Name_TH { get; set; }
            public string? upload_image { get; set; }
            public string? upload_image_ENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public string? L_AND_BIM_Link { get; set; }
            public int? use_status { get; set; }
            public int? ShowItem { get; set; }
        }

        public class ProjectRefResponse
        {
            public int? Index { get; set; }
            public int Id { get; set; }
            //public int CategoryId { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Profile_Image { get; set; }
            public string? Folder_Path { get; set; }
            public string? Location_TH { get; set; }
            public string? Location_EN { get; set; }
            public string? Client { get; set; }
            public string? Design_Solution { get; set; }
            public string? Photo_Credit { get; set; }
            public string? Content_TH { get; set; }
            public string? Content_EN { get; set; }
            public string? Pdf_TH { get; set; }
            public string? Pdf_ENG { get; set; }
            public int? ShowItem { get; set; }
            public int ProjectRef_CategoryId { get; set; }
        }

        public class Product_CategoryResponse
        {
            public int? Index { get; set; }
            public int Id { get; set; }

            //category
            public int Product_CategoryId { get; set; }
            //sub category
            public int Product_ModelId { get; set; }

            public string? Folder_Path { get; set; }
            public string? Model { get; set; }
            public string? Type_TH { get; set; }
            public string? Type_EN { get; set; }
            public string? Preview_Image { get; set; }
            public string? Preview_Image_Index { get; set; }
            public string? SUB_IMG { get; set; }
            public string? CUTSHEET { get; set; }
            public string? IESFILE { get; set; }
            public string? CATALOGUE { get; set; }
            public string? RFA { get; set; }
            public string? MORE_INFORMATION { get; set; }

            public string? Application { get; set; }

            public string? Technical_Drawing { get; set; }
            public string? Technical_Drawing_Img { get; set; }
            //spect
            public string? IP_Rating { get; set; }
            public string? Dimension { get; set; }
            public string? Power { get; set; }
            public List<Product_Spect>? ProductSpect { get; set; } = new List<Product_Spect>();
            public string? LIGHT_DISTRIBUTION { get; set; }
            public int? ShowItem { get; set; }
        }

        public class IR_HIGHLIGHTDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public int SetType { get; set; }
            public string? Background { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_HIGHLIGHTResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_HightlightDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public int SetType { get; set; }
            public string? Background { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_ReportResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public int SetType { get; set; }
            public string? Background { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class HistoryDataDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public int? TypeData { get; set; }
            public string? ImageTH { get; set; }
            public string? ImageEN { get; set; }
            public string? FileVideoTH { get; set; }
            public string? FileVideoEN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Summary_Financial_HighlightsDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Icon { get; set; }
            public decimal? Total { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Summary_Financial_HighlightsResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_LIGHTING_EQUIPMENTResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Image { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public string? RegisterTH { get; set; }
            public string? RegisterEN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Button_Below_BannerResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Icon { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_IndexBannerResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? ImageBanner { get; set; }
            public int? Status { get; set; }
        }

		public class HistoryDetailResponse
		{
			public int? Index { get; set; }
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
		}

        public class Organization_ChartResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class HistoryResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_QuoteResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_QuoteDetailResponse
        {
            public int? Index { get; set; }
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

        public class IR_Stock_ChartResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_ChartDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Link_IR_Stock_Chart { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_LinkResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_LinkDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Link_IR_Stock_Link { get; set; }
            public int? Status { get; set; }
        }

        public class IR_InvestorCalendarResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Print_MediaResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_MassMediaResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Stock_MarketResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_InvestorCalendarDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Print_MediaDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Latest_NewsDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Latest_NewsResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_NewDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public DateTime? NewDate { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_IR_Analyst_ChaptertResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? FileName_TH { get; set; }
            public string? FileName_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_AnalystResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public int? Status { get; set; }
            public string? FileName_TH { get; set; }
            public string? FileName_EN { get; set; }
        }

        public class AuthorizationResponse
		{
            public int? Index { get; set; }
            public string? Id { get; set; }
			public string? EmployeeCode { get; set; }
			public int EmployeeCodeInt { get; set; } = 0;
			public string? Firstname { get; set; }
			public string? Lastname { get; set; }
			public string? Address { get; set; }
			public string? ProfilePath { get; set; }
			public string? ReceptionistFile { get; set; }
			public string? ApplicationFile { get; set; }
			public string? GuarantorIdentificationCardFile { get; set; }
		}

        public class IR_ContactResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public string? Image { get; set; }
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

		public class IR_ComplaintsResponse
		{
			public int? Index { get; set; }
			public int? Id { get; set; }
			public string? Title_TH { get; set; }
			public string? Title_EN { get; set; }
			public string? SubTitle_TH { get; set; }
			public string? SubTitle_EN { get; set; }
			public string? TypeContactUS_TH { get; set; }
			public string? TypeContactUS_EN { get; set; }
			public string? Input_TypeContactUS_TH { get; set; }
			public string? Input_TypeContactUS_EN { get; set; }
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

		public class IR_faqResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_faqDetailResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? Detail_TH { get; set; }
            public string? Detail_EN { get; set; }
            public int? Status { get; set; }
        }


        public class IR_Request_InquiryResponse
        {
            public int? Index { get; set; }
            public int? Id { get; set; }
            public string? Title_TH { get; set; }
            public string? Title_EN { get; set; }
            public string? SubTitle_TH { get; set; }
            public string? SubTitle_EN { get; set; }
            public string? TitleText_Input_Name_TH { get; set; }
            public string? TitleText_Input_Name_EN { get; set; }
            public string? TitleText_Input_Tel { get; set; }
            public string? Text_Input_Email { get; set; }
            public string? Text_Input_Note_TH { get; set; }
            public string? Text_Input_Note_EN { get; set; }
            public string? Policy_TH { get; set; }
            public string? Policy_EN { get; set; }
            public string? Note_TH { get; set; }
            public string? Note_EN { get; set; }
            public string? Button_Submit_TH { get; set; }
            public string? Button_Submit_EN { get; set; }
            public int? Status { get; set; }
        }

        public class IR_Email_AlertsResponse
		{
			public int? Index { get; set; }
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

        public class IR_Cancel_EmailResponse
        {
            public int? Index { get; set; }
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
    }
}
