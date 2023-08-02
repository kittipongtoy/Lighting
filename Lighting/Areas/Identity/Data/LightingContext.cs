﻿using Lighting.Extension;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lighting.Areas.Identity.Data
{
    public class LightingContext : IdentityDbContext<LightingUser, Role, string>
    {  
        public LightingContext(DbContextOptions<LightingContext> options)
            : base(options)
        {
        }

        public LightingContext()
        {
        }
        #region smart solution
        //public DbSet<Smart_Solution_Category> Smart_Solution_Categorys { get; set; }
        public DbSet<Smart_Solution_Link> Smart_Solution_Links { get; set; }
        public DbSet<Smart_Solution> Smart_Solutions { get; set; }
        #endregion
        #region product
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Model> Product_Models { get; set; }
        public DbSet<Product_Category> Product_Categorys { get; set; }
        #endregion

        #region Project Ref
        public DbSet<ProjectRef_Product> ProjectRef_Products { get; set; }
        public DbSet<Category_Project> Category_Projects { get; set; }
        public DbSet<ProjectRef> ProjectRefs { get; set; }
        #endregion
        public DbSet<RF_Philosophy_Vision_Mission> RF_Philosophy_Vision_Mission { get; set; }
        public DbSet<RF_Philosophy_Vision_Mission_Details> RF_Philosophy_Vision_Mission_Details { get; set; }
        public DbSet<RF_Innovation_Center_Images> RF_Innovation_Center_Images { get; set; }
        public DbSet<RF_Innovation_Centers> RF_Innovation_Centers { get; set; }
        public DbSet<RF_Manufacturing_Images> RF_Manufacturing_Images { get; set; }
        public DbSet<RF_Warehouse_Logistics_Images> RF_Warehouse_Logistics_Images { get; set; }
        public DbSet<RF_Oversea_Offices_Images> RF_Oversea_Offices_Images { get; set; }
        public DbSet<RF_Solid_States_Images> RF_Solid_States_Images { get; set; }
        public DbSet<RF_Assembly_Services_Images> RF_Assembly_Services_Images { get; set; }
        public DbSet<RF_Solution_Centers_Images> RF_Solution_Centers_Images { get; set; }
        public DbSet<RF_Manufacturing> RF_Manufacturing { get; set; }
        public DbSet<RF_Warehouse_Logistics> RF_Warehouse_Logistics { get; set; }
        public DbSet<RF_Oversea_Offices> RF_Oversea_Offices { get; set; }
        public DbSet<RF_Solid_States> RF_Solid_States { get; set; }
        public DbSet<RF_Assembly_Services> RF_Assembly_Services { get; set; }
        public DbSet<RF_Solution_Centers> RF_Solution_Centers { get; set; } 
        public DbSet<cookies_policy> cookies_policy { get; set; }
        public DbSet<privacy_PolicyTitles> privacy_PolicyTitles { get; set; }
        public DbSet<privacy_Policys> privacy_Policys { get; set; }
        public DbSet<Download> Downloads { get; set; }
        public DbSet<ApplyJob> ApplyJobs { get; set; }
        #region contact
        public DbSet<Contact> Contacts { get; set; }
        #endregion
        #region news
        public DbSet<News> News { get; set; }
        #endregion
        public DbSet<Author_secretary_File> Author_secretary_File { get; set; }
        public DbSet<Board_of_Directors> Board_of_Directors { get; set; }
        public DbSet<Company_Overview> Company_Overview { get; set; }
        public DbSet<Companyprofile> Companyprofile { get; set; }
        public DbSet<CorporateGovernance> CorporateGovernance { get; set; }
        public DbSet<CorporateGovernance_Cate> CorporateGovernance_Cate { get; set; }
        public DbSet<CorporateGovernance_File> CorporateGovernance_File { get; set; }
        public DbSet<M_chairman> M_chairman { get; set; }
        public DbSet<M_message_chairman> M_message_chairman { get; set; }
        public DbSet<O_Anti_fraud> O_Anti_fraud { get; set; }
        public DbSet<O_Anti_fraud_File> O_Anti_fraud_File { get; set; }
        public DbSet<O_Author_audit_committee> O_Author_audit_committee { get; set; }
        public DbSet<O_Author_audit_committee_File> O_Author_audit_committee_File { get; set; }
        public DbSet<O_Author_board_director> O_Author_board_director { get; set; }
        public DbSet<O_Author_board_director_File> O_Author_board_director_File { get; set; }
        public DbSet<O_Author_cg> O_Author_cg { get; set; }
        public DbSet<O_Author_cg_File> O_Author_cg_File { get; set; }
        public DbSet<O_Author_chairman> O_Author_chairman { get; set; }
        public DbSet<O_Author_chairman_File> O_Author_chairman_File { get; set; }
        public DbSet<O_Author_chairman_executive> O_Author_chairman_executive { get; set; }
        public DbSet<O_Author_chairman_executive_File> O_Author_chairman_executive_File { get; set; }
        public DbSet<O_Author_executive_board> O_Author_executive_board { get; set; }
        public DbSet<O_Author_executive_board_File> O_Author_executive_board_File { get; set; }
        public DbSet<O_Author_secretary> O_Author_secretary { get; set; }
        public DbSet<O_Author_secretary_File> O_Author_secretary_File { get; set; }
        public DbSet<O_CRS_policy> O_CRS_policy { get; set; }
        public DbSet<O_CRS_policy_File> O_CRS_policy_File { get; set; }
        public DbSet<O_Channel_clue> O_Channel_clue { get; set; }
        public DbSet<O_Channel_clue_File> O_Channel_clue_File { get; set; }
        public DbSet<O_Gift_entertainment> O_Gift_entertainment { get; set; }
        public DbSet<O_Gift_entertainment_File> O_Gift_entertainment_File { get; set; }
        public DbSet<O_business_ethics> O_business_ethics { get; set; }
        public DbSet<O_business_ethics_File> O_business_ethics_File { get; set; }
        public DbSet<O_business_ethics_details> O_business_ethics_details { get; set; }
        public DbSet<OrganizationalStructure> OrganizationalStructure { get; set; }
        public DbSet<P_philosophy> P_philosophy { get; set; }
        public DbSet<Sustainability_Report> Sustainability_Report { get; set; }
        public DbSet<ImportInfo_ShareHolderData> ImportInfo_ShareHolderData { get; set; }
        public DbSet<Import_Info_ShareHolder> Import_Info_ShareHolder { get; set; }
        public DbSet<SH_generalMeeting_Data> SH_generalMeeting_Data { get; set; }
        public DbSet<SH_generalMeeting> SH_generalMeeting { get; set; }
        public DbSet<SH_dividen_Data> SH_dividen_Data { get; set; }
        public DbSet<SH_dividen> SH_dividen { get; set; }
        public DbSet<ShareHolder> ShareHolder { get; set; }
        public DbSet<ShareHolder_DataDetails> ShareHolder_DataDetails { get; set; }
        public DbSet<SH_annual_Report> SH_annual_Report { get; set; }
        public DbSet<SH_annual_ReportData> SH_annual_ReportData { get; set; }
        public DbSet<SH_IR_Form> SH_IR_Form { get; set; }
        public DbSet<SH_IR_FormData> SH_IR_FormData { get; set; }
        public DbSet<SH_IR_Report_Meeting> SH_IR_Report_Meeting { get; set; }
        public DbSet<SH_IR_Report_MeetingData> SH_IR_Report_MeetingData { get; set; }
        public DbSet<SH_IR_Report_Meeting_DataDetails> SH_IR_Report_Meeting_DataDetails { get; set; }
        public DbSet<SH_IR_propose_agenda> SH_IR_propose_agenda { get; set; }
        public DbSet<SH_IR_propose_agenda_receive_mails> SH_IR_propose_agenda_receive_mails { get; set; }
        public DbSet<SH_IR_propose_agenda_mailTitles> SH_IR_propose_agenda_mailTitles { get; set; }
        public DbSet<receive_mail_propose_agendas> receive_mail_propose_agendas { get; set; }
        public DbSet<receive_agenda_mail_accounts> receive_agenda_mail_accounts { get; set; }
        public DbSet<SH_IR_propose_agenda_DataDetails> SH_IR_propose_agenda_DataDetails { get; set; } 
        public DbSet<type_of_agenda_Propose> type_of_agenda_Propose { get; set; }
        public DbSet<SH_IR_presentation_doc> SH_IR_presentation_doc { get; set; }
        public DbSet<SH_IR_presentation_doc_Data> SH_IR_presentation_doc_Data { get; set; }
        public DbSet<SH_IR_presentation_webcast> SH_IR_presentation_webcast { get; set; }
        public DbSet<SH_IR_presentation_webcast_Data> SH_IR_presentation_webcast_Data { get; set; }
        public DbSet<SH_IR_MDA> SH_IR_MDA { get; set; }
        public DbSet<SH_IR_MDA_Data> SH_IR_MDA_Data { get; set; }
        public DbSet<SH_IR_MDA_DataDetails> SH_IR_MDA_DataDetails { get; set; }
        public DbSet<SH_IR_financial_highlight> SH_IR_financial_highlight { get; set; }
        public DbSet<SH_IR_financial_highlight_Data> SH_IR_financial_highlight_Data { get; set; }
        public DbSet<SH_IR_financial_highlight_DataDetails> SH_IR_financial_highlight_DataDetails { get; set; }
        public DbSet<SH_IR_important_financial> SH_IR_important_financial { get; set; }
        public DbSet<SH_IR_financial_position> SH_IR_financial_position { get; set; }
        public DbSet<SH_IR_financial_position_DataDetails> SH_IR_financial_position_DataDetails { get; set; }
        public DbSet<SH_IR_financial_highlight_DetailsData_Items> SH_IR_financial_highlight_DetailsData_Items { get; set; }
        public DbSet<SH_IR_Profit_Lose> SH_IR_Profit_Lose { get; set; }
        public DbSet<SH_IR_Profit_Lose_others> SH_IR_Profit_Lose_others { get; set; }
        public DbSet<SH_IR_cashFlow_statements> SH_IR_cashFlow_statements { get; set; }
        public DbSet<SH_IR_download_financial_statements> SH_IR_download_financial_statements { get; set; }
        public DbSet<SH_IR_prospectus> SH_IR_prospectus { get; set; }
        public DbSet<SH_IR_financial_highlight_Details> SH_IR_financial_highlight_Details { get;set;}
        public DbSet<SH_IR_financial_highlight_DetailsData> SH_IR_financial_highlight_DetailsData { get; set; }
        public DbSet<IR_Analyst> IR_Analysts { get; set; } 
        public DbSet<IR_Analyst_Chapter> IR_Analyst_Chapter { get; set; }
        public DbSet<IR_Contact> IR_Contact { get; set; }
        public DbSet<IR_Stock_Market> IR_Stock_Market { get; set; }
        public DbSet<IR_NewDetail> IR_NewDetail { get; set; }
        public DbSet<IR_Latest_New> IR_Latest_News { get; set; }
        public DbSet<IR_Latest_NewDetail> IR_Latest_NewDetail { get; set; }
        public DbSet<IR_MassMedia> IR_MassMedia { get; set; }
        public DbSet<IR_MassMediaDetail> IR_MassMediaDetail { get; set; }
        public DbSet<IR_Print_Media> IR_Print_Media { get; set; }
        public DbSet<IR_Print_MediaDetail> IR_Print_MediaDetail { get; set; }
        public DbSet<IR_InvestorCalendar> IR_InvestorCalendar { get; set; }
        public DbSet<IR_Complaints> IR_Complaints { get; set; }
		public DbSet<IR_Email_Alerts> IR_Email_Alerts { get; set; }
		public DbSet<IR_faq> IR_faq { get; set; }
		public DbSet<IR_faq_Detail> IR_faq_Detail { get; set; }
		public DbSet<IR_Request_Inquiry> IR_Request_Inquiry { get; set; }
        public DbSet<IR_InvestorCalendarDetail> IR_InvestorCalendarDetail { get; set; }
        public DbSet<IR_Cancel_Email> IR_Cancel_Email { get; set; }
        public DbSet<IR_Stock_Chart> IR_Stock_Chart { get; set; }
        public DbSet<IR_Stock_ChartDetail> IR_Stock_ChartDetails { get; set; }
        public DbSet<IR_Stock_LinkDetail> IR_Stock_LinkDetail { get; set; }
        public DbSet<IR_Stock_Quote> IR_Stock_Quote { get; set; }
        public DbSet<IR_Stock_QuoteDetail> IR_Stock_QuoteDetail { get; set; }


        public DbSet<IR_Banner> IR_Banner { get; set; }
        public DbSet<Awards> Awards { get; set; }
        public DbSet<AwardsDetail> AwardsDetail { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<HistoryDataDetail> HistoryDataDetail { get; set; }
        public DbSet<HistoryDetail> HistoryDetail { get; set; }
        public DbSet<IR_Button_Below_Banner> IR_Button_Below_Banner { get; set; }
        public DbSet<IR_Investor_Relations> IR_Investor_Relations { get; set; }
        public DbSet<IR_Investor_RelationsDetail> IR_Investor_RelationsDetail { get; set; }
        public DbSet<IR_LIGHTING_EQUIPMENT> IR_LIGHTING_EQUIPMENT { get; set; }
        public DbSet<IR_Summary_Financial_Highlights> IR_Summary_Financial_Highlight { get; set; }
        public DbSet<IR_Summary_Financial_HighlightsDetail> IR_Summary_Financial_HighlightsDetail { get; set; }
        public DbSet<IR_Report> IR_Report { get; set; }
        public DbSet<Organization_Chart> Organization_Chart { get; set; }
        public DbSet<Organization_ChartDetail> Organization_ChartDetail { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            Builder.Seed();
        }
    }
}