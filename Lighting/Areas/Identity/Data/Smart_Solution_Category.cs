using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Smart_Solution_Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName_TH { get; set; }
        public string CategoryName_EN { get; set; }
        public string PreviewImg { get; set; }
    }
}
