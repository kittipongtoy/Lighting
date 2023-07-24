namespace Lighting.Models
{
    public class IR_Important_Financial_model
    {
        public class SH_IR_financial_highlight_DataDetailstable
        { 
            public int count_row { get; set; }
            public int id { get; set; }
            public string? year { get; set; }
            public string? amount { get; set; }
            public int fH_Data_id { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class ResponserAnnualReport
        {
            public int id { get; set; }
            public Nullable<System.DateTime> year { get; set; }
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
        public class ResponserDFStatement
        {
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public Nullable<System.DateTime> inputDate { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class SH_IR_MDA_Data_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? detailsTitleTH { get; set; }
            public string? detailsTitleENG { get; set; }
            public string? image_name { get; set; }
            public string? image_name_ENG { get; set; } 
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_MDA_DataDetails_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? title { get; set; }
            public string? year { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class SH_IR_financial_position_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_financial_postition_DataDetail_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? amount { get; set; }
            public string? percent { get; set; }
            public int? financialPosition_id { get; set; }
            public DateTime? created_at { get; set; } 
            public DateTime? updated_at { get; set; }
        
        }

        public class SH_IR_Profit_Lose_dataTable
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? amount { get; set; }
            public string? percentProfit { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class SH_IR_Profit_Lose_others_dataTable
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? amount { get; set; }
            public string? percentProfit { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_cashFlow_statements_dataTable
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? amount { get; set; }
            public string? percentProfit { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_download_finanicalStatement_dataTable
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public string? inputDate { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class SH_IR_financial_highlight_Data_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? profitTitleTH { get; set; }
            public string? profitTitleENG { get; set; }
            public int? active_status { get; set; }
            public string? amount1 { get; set; }
            public string? amount2 { get; set; }
            public string? amount3 { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_financial_highlight_Details_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? titleTH { get; set; }
            public string? titleENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class SH_IR_financial_highlight_DataDetails_table
        { 
            public int count_row { get; set; }
            public int id { get; set; }
            public string? profitTitleTH { get; set; }
            public string? profitTitleENG { get; set; }
            public int? financial_hilight_id { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class SH_IR_financial_highlight_DetailsData_Items_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? year { get; set; }
            public string? amount { get; set; }
            public int? fH_Details_id { get; set; }
            public int? fH_DetailsData_id { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

    }
}
