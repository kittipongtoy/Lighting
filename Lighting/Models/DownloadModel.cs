namespace Lighting.Models
{
    public class DownloadModel
    {
        public class DownloadData_table
        {
            public int count_row { get; set; }
            public int id { get; set; }
            public int DownloadType_id { get; set; }
            public string DownloadType { get; set; }
            public string Name_EN { get; set; }
            public string Name_TH { get; set; }
            public string? upload_image { get; set; }
            public string? upload_image_ENG { get; set; }
            public string? file_name { get; set; }
            public string? file_name_ENG { get; set; }
            public string? L_AND_BIM_Link { get; set; }
            public int? use_status { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }
        public class DownloadType_table
        { 
            public int count_row { get; set; }
            public int id { get; set; }
            public string downloadType_name_TH { get; set; }
            public string downloadType_name_ENG { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }

        }

    }
}
