using System.ComponentModel.DataAnnotations;

namespace Lighting.Models.InputFilterModels.Download
{ 
    public class Input_DownloadVM
    {
        public int DownloadType_id { get; set; }
        public string Name_EN { get; set; } 
        public string Name_TH { get; set; }
        public string? upload_image { get; set; }
        public string? upload_image_ENG { get; set; }
        public string? file_name { get; set; }
        public string? file_name_ENG { get; set; }
        public int? use_status { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile Image_EN { get; set; }
        public IFormFile File { get; set; }
        public IFormFile File_EN { get; set; }
        public string? L_AND_BIM_Link { get; set; }
    }
    public class Output_DownloadVM
    {
        public int id { get; set; }
        public string? DownloadType { get; set; }
        public string? Name_EN { get; set; }
        public string? Name_TH { get; set; } 
        public string? upload_image { get; set; }
        public string? upload_image_ENG { get; set; }
        public string? file_name { get; set; }
        public string? file_name_ENG { get; set; }
        public string? L_AND_BIM_Link { get; set; }
        public int? use_status { get; set; }
    }
}
