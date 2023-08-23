using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Product_Category
    {
        [Key]
        public int Id { get; set; }
        public string Name_EN { get; set; }
        public string Name_TH { get; set; }
        public string Image { get; set; }
        public int? ShowItem { get; set; }
        public string? ShowImage { get; set; }
    }
}
