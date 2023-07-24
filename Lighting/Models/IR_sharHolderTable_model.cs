namespace Lighting.Models
{
    public class IR_sharHolderTable_model
    {
        public class receive_mail_propose_agendas_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? name { get; set; }
            public string? email { get; set; }
            public string? phone { get; set; }
            public string? wantProposeTitle { get; set; }
            public string? details { get; set; }
            public string? typeOfPropose { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class ShareHolder_DataDetails_table
        {
            public int count_row { get; set; }
            public int Id { get; set; }
            public string? nameTH { get; set; }
            public string? nameENG { get; set; }
            public string? amount { get; set; }
            public string? percentPerAmount { get; set; }
            public DateTime? CreateDate { get; set; }
            public DateTime? UpdateDate { get; set; }
        }
        public class ImportInfo_ShareHolderData_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? image_name { get; set; }
            public string? image_name_ENG { get; set; }
            public int? use_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_GeneralMeetingData_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public DateTime? year { get; set; }
            public int? use_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_FormData_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? year { get; set; }
            public string? confrimDate { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_dividenData_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? title { get; set; }
            public string? dateOfBoard { get; set; }
            public string? dateMaking { get; set; }
            public string? paymentDate { get; set; }
            public string? dividenTypeTitleTH { get; set; }
            public string? dividenTypeTitleENG { get; set; }
            public string? amount { get; set; }
            public string? earningDayTitleTH { get; set; }
            public string? earningDayTitleENG { get; set; }
            public int? use_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_annualReportData_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? year { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? upload_image { get; set; }
            public string? upload_image_ENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public int? use_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_Report_MeetingData_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? year { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_ReportMeetingDataDetails_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public int? active_status { get; set; }
            public int? reportMeeting_id { get; set; }
            public string? year { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class SH_IR_propose_agendaData_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_propose_agenda_mailTitles_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? nameTitleTH { get; set; }
            public string? nameTitleENG { get; set; }
            public string? nameTitlePlaceholderTH { get; set; }
            public string? nameTitlePlaceholderSNG { get; set; }
            public string? emailTitleTH { get; set; }
            public string? emailTitleENG { get; set; }
            public string? emailTitlePlaceholderTH { get; set; }
            public string? emailTitlePlaceholderENG { get; set; }
            public string? phoneTH { get; set; }
            public string? phoneENG { get; set; }
            public string? phoneTitlePlaceholder { get; set; }
            public string? proposeTitleTH { get; set; }
            public string? proposeTitleENG { get; set; }
            public string? wantProposeTitleTH { get; set; }
            public string? wantProposeTitleENG { get; set; }
            public string? wantProposePlaceholderTitleTH { get; set; }
            public string? wantProposePlaceholderTitleENG { get; set; }
            public string? detailsTitleTH { get; set; }
            public string? detailsTitleENG { get; set; }
            public string? detailsPlaceholderTitleTH { get; set; }
            public string? detailsPlaceholderTitleENG { get; set; }
            public string? detailsTH { get; set; }
            public string? detailsENG { get; set; }
            public string? remarkTH { get; set; }
            public string? remarkENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class type_of_agenda_Propose_table
        { 
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class annual_ReportData
        {
            public int id { get; set; }
            public DateTime? year { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? upload_image { get; set; }
            public string? upload_image_ENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public int? use_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }


    }
}
