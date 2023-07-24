using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Product_Model
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name_EN { get; set; }
        public string Name_TH { get; set; }
        public int Product_CategoryId { get; set; }
    }
}
