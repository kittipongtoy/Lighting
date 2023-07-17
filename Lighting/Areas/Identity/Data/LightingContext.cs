using Lighting.Extension;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<SH_IR_propose_agenda_DataDetails> SH_IR_propose_agenda_DataDetails { get; set; }
        public DbSet<SH_IR_presentation_doc> SH_IR_presentation_doc { get; set; }
        public DbSet<SH_IR_presentation_doc_Data> SH_IR_presentation_doc_Data { get; set; }
        public DbSet<SH_IR_presentation_webcast> SH_IR_presentation_webcast { get; set; }
        public DbSet<SH_IR_presentation_webcast_Data> SH_IR_presentation_webcast_Data { get; set; }
        public DbSet<SH_IR_MDA> SH_IR_MDA { get; set; }
        public DbSet<SH_IR_MDA_Data> SH_IR_MDA_Data { get; set; }
        public DbSet<SH_IR_MDA_DataDetails> SH_IR_MDA_DataDetails { get; set; }
        public DbSet<SH_IR_financial_highlight> SH_IR_financial_highlight { get; set; }
        public DbSet<SH_IR_financial_highlight_Data> SH_IR_financial_highlight_Data { get; set; }
        public DbSet<SH_IR_important_financial> SH_IR_important_financial { get; set; }
        public DbSet<SH_IR_financial_position> SH_IR_financial_position { get; set; }
        public DbSet<SH_IR_financial_position_DataDetails> SH_IR_financial_position_DataDetails { get; set; }
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