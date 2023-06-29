namespace Lighting.Models
{
    public class IR_Presentation_Infor_model
    {
        public class SH_IR_Presentation_DocDataDetails_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public string? document_date { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        
        }

        public class SH_IR_presentation_webcastDetails_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? activity_date { get; set; }
            public string? linkVideo { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }

        }





    }
}
