using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class ProjectRef
    {
        [Key]
        public int Id { get; set; }
        //public int CategoryId { get; set; }
        public string Title_TH { get; set; }
        public string Title_EN { get; set; }
        public string Profile_Image { get; set; }
        public string? Folder_Path { get; set; }
        public string? Location_TH { get; set; }
        public string? Location_EN { get; set; }
        public string? Client { get; set; }
        public string? Design_Solution { get; set; }
        public string? Photo_Credit { get; set; }
        public string? Content_TH { get; set; }
        public string? Content_EN { get; set; }
        public string? File_Download { get; set; }

        public int ProjectRef_CategoryId { get; set; }
        public Category_Project? ProjectRef_Category { get; set; }
    }
}
