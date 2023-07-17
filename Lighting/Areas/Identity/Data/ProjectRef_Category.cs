using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class ProjectRef_Category
    {
        [Key]
        public int Id { get; set; }
        public string Name_TH { get; set; }
        public string Name_EN { get; set; }
        public string Image_Path { get; set; }
    }
}
