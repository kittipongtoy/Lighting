using System.ComponentModel.DataAnnotations;

namespace Lighting.Models.InputFilterModels.Download
{
    public class Input_DownloadVM
    {
        [Required]
        public string DownloadType { get; set; }
        [Required]
        public string Name_EN { get; set; }
        [Required]
        public string Name_TH { get; set; }
        public IFormFile Image { get; set; }
        public IFormFile File { get; set; }
        public string? L_AND_BIM_Link { get; set; }
    }
    public class Output_DownloadVM
    {
        public int Id { get; set; }
        public string? DownloadType { get; set; }
        public string? Name_EN { get; set; }
        public string? Name_TH { get; set; }
        public string Image { get; set; }
        public string File { get; set; }
        public string? L_AND_BIM_Link { get; set; }
    }
}
