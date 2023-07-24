namespace Lighting.Models
{
    public class PrivacyModels
    {
        public class privacy_Policys_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public string? year { get; set; }
            public int? typeOfPolicy_id { get; set; }
            public string? typeOfPolicy { get; set; }
            public string? detailsTH { get; set; }
            public string? detailsENG { get; set; }
            public int? active_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

    }
}
