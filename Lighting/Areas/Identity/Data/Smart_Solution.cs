using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Smart_Solution
    {
        [Key]
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
