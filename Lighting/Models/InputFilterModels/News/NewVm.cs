using Lighting.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Models.InputFilterModels.News
{
    public class Input_NewsVm
    {
        [Required]
        public string Title_EN { get; set; }
        [Required]
        public string Title_TH { get; set; }
        public IFormFile? TitleImage { get; set; }
        [Required]
        public string? Content_TH { get; set; }
        [Required]
        public string? Content_EN { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? CreateDate_TH { get; set; }
        public DateTime? CreateDate_EN { get; set; }
        public string? date_str { get; set; }
        public List<IFormFile>? ImgList { get; set; } = new List<IFormFile>();
    }
    public class Output_NewsVm
    {
        public int Id { get; set; }
        public string? Title_EN { get; set; }
        public string? Title_TH { get; set; }
        public string? TitleImage { get; set; }
        public string? ImagePath { get; set; }
        public string? Content_TH { get; set; }
        public string? Content_EN { get; set; }
        public DateTime? CreateDate_TH { get; set; }
        public DateTime? CreateDate_EN { get; set; }
        public string? date_str { get; set; }
        public List<string>? ImgList { get; set; } = new List<string>();
    }
}
