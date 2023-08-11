using Lighting.Areas.Identity.Data;

namespace Lighting.Models
{
    public class model_input
    { 
        public DownloadTypes? DownloadTypes { get; set; }
        public int? count_row_DownloadHeads { get; set; }
        public DownloadHeads? fod_DownloadHeads { get; set; }
        public Download? Output_DownloadVM { get; set; }
        public IR_Contact? IR_Contact { get; set; }
        public IR_InvestorCalendarDetail? IR_InvestorCalendarDetail { get; set; }
        public IR_MassMediaDetail? IR_MassMediaDetail { get; set; }
        public IR_Print_MediaDetail? IR_Print_MediaDetail { get; set; }
        public IR_NewDetail? IR_NewDetail { get; set; }
        public IR_Analyst? IR_Analyst { get; set; }
        public IR_Analyst_Chapter? IR_Analyst_Chapter { get; set; }

        public class page_resource_facility_content
        {
            public int id { get; set; }
            public string? upload_image { get; set; }
            public string? upload_image_ENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class page_resource_facility_title
        {
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? detailsTitleTH { get; set; }
            public string? detailsTitleENG { get; set; }
            public string? link { get; set; }
            public string? linkENG { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public List<page_resource_facility_content>? list_page_resource_facility_content { get; set; }
        public page_resource_facility_title? fod_page_resource_facility_title { get; set; }
        public int? count_list_page_resource_facility_content { get; set; }
        public int? count_fod_page_resource_facility_title { get; set; }

        public int? count_cookies_policy { get; set; }
        public cookies_policy? fod_cookies_policy { get; set; }
        public privacy_PolicyTitles? fod_privacy_PolicyTitles { get; set; }
        public int? count_privacy_PolicyTitles { get; set; }
        public privacy_Policys? fod_privacy_Policys { get; set; }
        public int? count_receive_agenda_mail_accounts { get; set; }
        public receive_agenda_mail_accounts? receive_agenda_mail_accounts { get; set; }
        public class IR_csr_policy_file
        {
            public int id { get; set; }
            public string? image_name { get; set; }
            public string? image_name_ENG { get; set; }
            public string? title_file_th { get; set; }
            public string? title_file_en { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public string? file_type { get; set; }
            public int? use_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }

        }
        public class IR_csr_policy_content
        {
            public int id { get; set; }
            public string? title_TH { get; set; }
            public string? title_ENG { get; set; }
            public string? detailsTitleTH { get; set; }
            public string? detailsTitleENG { get; set; }
            public string? titleDetails_TH { get; set; }
            public string? titleDetails_ENG { get; set; }
            public string? detail_th { get; set; }
            public string? detail_en { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }

        }
        public List<IR_csr_policy_file>? list_IR_csr_policy_file_file { get; set; }
        public IR_csr_policy_content? fod_IR_csr_policy_content { get; set; }
        public int? count_list_IR_csr_policy_file_file { get; set; }
        public int? count_fod_IR_csr_policy_content { get; set; }
        public class page_corporate_governance_file
        {
            public int id { get; set; }
            public string? image_name { get; set; }
            public string? image_name_ENG { get; set; }
            public string? title_file_th { get; set; }
            public string? title_file_en { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public string? file_type { get; set; }
            public int? use_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class page_corporate_governance_content
        {
            public int id { get; set; }
            public string? title_TH { get; set; }
            public string? title_ENG { get; set; }
            public string? detailsTitleTH { get; set; }
            public string? detailsTitleENG { get; set; }
            public string? titleDetails_TH { get; set; }
            public string? titleDetails_ENG { get; set; }
            public string? detail_th { get; set; }
            public string? detail_en { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public List<page_corporate_governance_file>? list_page_corporate_governance_file { get; set; }
        public page_corporate_governance_content? fod_page_corporate_governance_content { get; set; }
        public int? count_list_page_corporate_governance_file { get; set; }
        public int? count_fod_page_corporate_governance_content { get; set; }
        public List<M_chairman>? list_chairman { get; set; }
        public List<P_philosophy>? list_philosophy { get; set; }
        public List<OrganizationalStructure>? list_OrganizationalStructure { get; set; }
        public List<Company_Overview>? list_companyOverview { get; set; }
        public List<Board_of_Directors>? list_Board_of_Directors { get; set; }
        public List<Board_of_Directors>? list_Board { get; set; }
        public List<Board_of_Directors>? list_Manage { get; set; }
        public List<Companyprofile>? list_Companyprofile { get; set; }
        public List<CorporateGovernance_File>? list_CorporateGovernance_File { get; set; }
        public List<CorporateGovernance_Cate>? list_CorporateGovernance_Cate { get; set; }
        public List<O_business_ethics_File>? list_O_business_ethics_File { get; set; }
        public List<O_CRS_policy_File>? list_O_CRS_policy_File { get; set; }
        public List<O_Anti_fraud_File>? list_O_Anti_fraud_File { get; set; }
        public List<O_Author_secretary_File>? list_O_Author_secretary_File { get; set; }
        public List<O_Author_executive_board_File>? list_O_Author_executive_board_File { get; set; }
        public List<O_Author_cg_File>? list_O_Author_cg_File { get; set; }
        public List<O_Author_audit_committee_File>? list_O_Author_audit_committee_File { get; set; }
        public List<O_Author_board_director_File>? list_O_Author_board_director_File { get; set; }
        public List<O_Author_chairman_executive_File>? list_O_Author_chairman_executive_File { get; set; }
        public List<O_Author_chairman_File>? list_O_Author_chairman_File { get; set; }
        public List<O_Channel_clue_File>? list_O_Channel_clue_File { get; set; }
        public List<O_Gift_entertainment_File>? list_O_Gift_entertainment_File { get; set; }
        public M_message_chairman? fod_message_chairman { get; set; }
        public Companyprofile? fod_Companyprofile { get; set; }
        public M_chairman? fod_chairman { get; set; }
        public Board_of_Directors? fod_Board_of_Directors { get; set; }
        public CorporateGovernance? fod_CorporateGovernance { get; set; }
        public CorporateGovernance_File? fod_CorporateGovernance_File { get; set; }
        public CorporateGovernance_Cate? fod_CorporateGovernance_Cate { get; set; }
        public O_business_ethics? fod_O_business_ethics { get; set; }
        public O_business_ethics_File? fod_O_business_ethics_File { get; set; }
        public O_business_ethics_details? fod_O_business_ethics_Details { get; set; }
        public O_CRS_policy? fod_O_CRS_policy { get; set; }
        public O_CRS_policy_File? fod_O_CRS_policy_File { get; set; }
        public O_Author_board_director? fod_O_Author_board_director { get; set; }
        public O_Author_board_director_File? fod_O_Author_board_director_File { get; set; }
        public O_Anti_fraud? fod_O_Anti_fraud { get; set; }
        public O_Anti_fraud_File? fod_O_Anti_fraud_File { get; set; }
        public O_Author_secretary? fod_O_Author_secretary { get; set; }
        public O_Author_secretary_File? fod_O_Author_secretary_File { get; set; }
        public O_Author_executive_board? fod_O_Author_executive_board { get; set; }
        public O_Author_executive_board_File? fod_O_Author_executive_board_File { get; set; }
        public O_Author_cg? fod_O_Author_cg { get; set; }
        public O_Author_cg_File? fod_O_Author_cg_File { get; set; }
        public O_Author_audit_committee? fod_O_Author_audit_committee { get; set; }
        public O_Author_audit_committee_File? fod_O_Author_audit_committee_File { get; set; }
        public O_Author_chairman_executive? fod_O_Author_chairman_executive { get; set; }
        public O_Author_chairman_executive_File? fod_O_Author_chairman_executive_File { get; set; }
        public O_Author_chairman? fod_O_Author_chairman { get; set; }
        public O_Author_chairman_File? fod_O_Author_chairman_File { get; set; }
        public O_Channel_clue? fod_O_Channel_clue { get; set; }
        public O_Channel_clue_File? fod_O_Channel_clue_File { get; set; }
        public O_Gift_entertainment? fod_O_Gift_entertainment { get; set; }
        public O_Gift_entertainment_File? fod_O_Gift_entertainment_File { get; set; }
        public Sustainability_Report? fod_Sustainability_Report { get; set; }
        public ShareHolder? fod_ShareHolder { get; set; }
        public ShareHolder_DataDetails? ShareHolder_Details { get; set; }
        public int? count_row_ShareHolder { get; set; }
        public int? count_row_chairman { get; set; }
        public int? count_row_CorporateGovernance { get; set; }
        public int? count_row_O_business_ethics { get; set; }
        public int? count_row_Sustainability_Report { get; set; }
        public int? count_row_O_CRS_policy { get; set; }
        public int? count_row_O_Anti_fraud { get; set; }
        public int? count_row_O_Author_secretary { get; set; }
        public int? count_row_O_Author_executive_board { get; set; }
        public int? count_row_O_Author_cg { get; set; }
        public int? count_row_O_Author_audit_committee { get; set; }
        public int? count_row_O_Author_board_director { get; set; }
        public int? count_row_O_Author_chairman_executive { get; set; }
        public int? count_row_O_Author_chairman { get; set; }
        public int? count_row_O_Channel_clue { get; set; }
        public int? count_row_O_Gift_entertainment { get; set; }
        public int? count_list_chairman { get; set; }
        public int? count_list_philosophy { get; set; }
        public int? count_list_OrganizationalStructure { get; set; }
        public int? count_list_Companyprofile { get; set; }
        public int? count_list_companyOverview { get; set; }
        public int? count_list_Board_of_Directors { get; set; }
        public int? count_list_Board { get; set; }
        public int? count_list_Manage { get; set; }
        public int? count_list_CorporateGovernance_File { get; set; }
        public int? count_list_CorporateGovernance_Cate { get; set; }
        public int? count_list_O_business_ethics_File { get; set; }
        public int? count_list_O_CRS_policy_File { get; set; }
        public int? count_list_O_Anti_fraud_File { get; set; }
        public int? count_list_O_Author_secretary_File { get; set; }
        public int? count_list_O_Author_executive_board_File { get; set; }
        public int? count_list_O_Author_cg_File { get; set; }
        public int? count_list_O_Author_audit_committee_File { get; set; }
        public int? count_list_O_Author_board_director_File { get; set; }
        public int? count_list_O_Author_chairman_executive_File { get; set; }
        public int? count_list_O_Author_chairman_File { get; set; }
        public int? count_list_O_Channel_clue_File { get; set; }
        public int? count_list_O_Gift_entertainment_File { get; set; }
        public string? path_file { get; set; }
        public string? path_image { get; set; }
        public string? title_th { get; set; }
        public string? title_en { get; set; }

        //shareholder 
        //public ShareHolder? fod_ShareHolder { get; set; }
        //public int? count_row_ShareHolder { get; set; }
        //public ShareHolder_DataDetails? ShareHolder_Details { get; set; }
        public Import_Info_ShareHolder? fod_Import_InfoShareHolder { get; set; }
        public int? count_row_Import_InfoShareHolder { get; set; }
        public ImportInfo_ShareHolderData? ImportInfo_ShareHolderData { get; set; }
        public SH_generalMeeting? fod_generalMeeting { get; set; }
        public int? count_row_generalMeeting { get; set; }
        public SH_generalMeeting_Data? SH_generalMeeting_Data { get; set; }
        public SH_dividen? fod_SH_dividen { get; set; }
        public int? count_row_SH_dividen { get; set; }
        public SH_dividen_Data? SH_dividen_Data { get; set; }
        public SH_IR_Form? fod_SH_IR_Form { get; set; }
        public int? count_row_SH_IR_Form { get; set; }
        public SH_IR_FormData? SH_IR_FormData { get; set; }
        public SH_annual_Report? fod_SH_annual_Report { get; set; }
        public int? count_row_SH_annual_Report { get; set; }
        public SH_annual_ReportData? SH_annual_ReportData { get; set; }
        public SH_IR_Report_Meeting? fod_SH_IR_Report_Meeting { get; set; }
        public int? count_row_SH_IR_Report_Meeting { get; set; }
        public SH_IR_Report_MeetingData? SH_IR_Report_MeetingData { get; set; }
        public int? count_row_SH_IR_Report_MeetingData { get; set; }
        public SH_IR_Report_Meeting_DataDetails? SH_IR_Report_Meeting_DataDetails { get; set; }
        public SH_IR_propose_agenda? fod_SH_IR_propose_agenda { get; set; }
        public int? count_row_SH_IR_propose_agenda { get; set; }
        public SH_IR_propose_agenda_DataDetails? SH_IR_propose_agenda_DataDetails { get; set; }
        public type_of_agenda_Propose? type_of_agenda_Propose { get; set; }
        public SH_IR_propose_agenda_mailTitles? SH_IR_propose_agenda_mailTitles { get; set; }
        public SH_IR_presentation_doc? fod_SH_IR_presentation_doc { get; set; }
        public int? count_row_SH_IR_presentation_doc { get; set; }
        public SH_IR_presentation_doc_Data? SH_IR_presentation_doc_Data { get; set; }
        public SH_IR_presentation_webcast? fod_SH_IR_presentation_webcast { get; set; }
        public int? count_row_SH_IR_presentation_webcast { get; set; }
        public SH_IR_presentation_webcast_Data? SH_IR_presentation_webcast_Data { get; set; }
        public SH_IR_MDA? fod_SH_IR_MDA { get; set; }
        public int? count_row_SH_IR_MDA { get; set; }
        public SH_IR_MDA_Data? SH_IR_MDA_Data { get; set; }
        public SH_IR_MDA_DataDetails? SH_IR_MDA_DataDetails { get; set; }
        public SH_IR_important_financial? fod_SH_IR_important_financial { get; set; }
        public int? count_row_SH_IR_important_financial { get; set; }
        public SH_IR_financial_position? SH_IR_financial_position { get; set; }
        public SH_IR_financial_position_DataDetails? SH_IR_financial_position_DataDetails { get; set; }
        public SH_IR_Profit_Lose? SH_IR_Profit_Lose { get; set; }
        public SH_IR_Profit_Lose_others? SH_IR_Profit_Lose_others { get; set; }
        public SH_IR_cashFlow_statements? SH_IR_cashFlow_statements { get; set; }
        public SH_IR_download_financial_statements? SH_IR_Download_Financial_Statements { get; set; }
        public SH_IR_prospectus? SH_IR_prospectus { get; set; }
        public SH_IR_prospectus? fod_SH_IR_prospectus { get; set; }
        public int? count_row_SH_IR_prospectus { get; set; }
        public SH_IR_financial_highlight? SH_IR_financial_highlight { get; set; }
        public SH_IR_financial_highlight? fod_SH_IR_financial_highlight { get; set; }
        public int? count_row_SH_IR_financial_highlight { get; set; }
        public SH_IR_financial_highlight_Data? SH_IR_financial_highlight_Data { get; set; }
        public SH_IR_financial_highlight_Data? fod_SH_IR_financial_highlight_Data { get; set; }
        public int? count_row_SH_IR_financial_highlight_Data { get; set; }
        public SH_IR_financial_highlight_Details? SH_IR_financial_highlight_Details { get; set; }
        public SH_IR_financial_highlight_Details? fod_SH_IR_financial_highlight_Details { get; set; }
        public int? count_row_SH_IR_financial_highlight_Details { get; set; }
        public SH_IR_financial_highlight_DetailsData? SH_IR_financial_highlight_DetailsData { get; set; }
        public int? count_row_SH_IR_financial_highlight_DetailsData { get; set; }
        public SH_IR_financial_highlight_DetailsData? fod_SH_IR_financial_highlight_DetailsData { get; set; }





    }
}
