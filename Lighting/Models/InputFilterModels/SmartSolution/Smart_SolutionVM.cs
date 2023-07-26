using System.ComponentModel.DataAnnotations;
using Lighting.Areas.Identity.Data;

namespace Lighting.Models.InputFilterModels.SmartSolution
{
    public class Input_Smart_Solution_CategoryVM
    {
        [Required]
        public string CategoryName_EN { get; set; }
        [Required]
        public string CategoryName_TH { get; set; }
        public IFormFile PreviewImg { get; set; }
    }

    public class Input_Smart_SolutionVM
    {
        public string? TitleName_TH { get; set; }
        public string? TitleName_EN { get; set; }
        public IFormFile? PreviewImg { get;  set; }
        public IFormFile? DetailImg { get; set; }
        public string? Explanation_TH { get; set; }
        public string? Explanation_EN { get; set; }
        public List<string>? Links { get; set; }
        public List<IFormFile>? LinkFiles { get; set; }
        public string? Content_TH { get; set; }
        public string? Content_EN { get; set; }
    }
    public class Output_Smart_SolutionVM
    {
        public int Id { get; set; }
        public string? TitleName_TH { get; set; }
        public string? TitleName_EN { get; set; }
        public string? PreviewImg { get; set; }
        public string? DetailImg { get; set; }
        public string? Explanation_TH { get; set; }
        public string? Explanation_EN { get; set; }
        public List<Smart_Solution_Link>? Links { get; set; }
        public string? Content_TH { get; set; }
        public string? Content_EN { get; set; }
    }
}
