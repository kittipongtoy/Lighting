using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Download : IProperty
    {
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
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
