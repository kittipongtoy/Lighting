using System.ComponentModel.DataAnnotations;
using Lighting.Areas.Identity.Data;

namespace Lighting.Models.InputFilterModels.ProjectRef
{
    public class Input_CategoryVM
    {
        [Required]
        public string Name_EN { get; set; }
        [Required]
        public string Name_TH { get; set; }
        public IFormFile Image_File { get; set; }
    }

    public class Output_CategoryVM
    {
        public int Id { get; set; }
        public string Name_EN { get; set; }
        public string Name_TH { get; set; }
        public string Image_Path { get; set; }
    }

    public class Input_ProjectRefVM
    {
        [Required]
        public int CategoryId { get; set; }
        public IFormFile Profile_Image { get; set; }
        public List<IFormFile> Image_List { get; set; }
        public string? Title_TH { get; set; }
        public string? Title_EN { get; set; }
        public string? Location_TH { get; set; }
        public string? Location_EN { get; set; }
        public string? Client { get; set; }
        public string? Design_Solution { get; set; }
        public string? Photo_Credit {get; set; }
        public string? Content_TH { get; set; }
        public string? Content_EN { get; set; }
        //public IFormFile File_Download { get; set; }
        public List<int>? ProductId { get; set; }
    }

    public class Output_ProjectRefVM
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Title_TH { get; set; }
        public string? Title_EN { get; set; }
        public string Profile_Image { get; set; }
        public List<string> Image_List { get; set; }
        public string? Location_TH { get; set; }
        public string? Location_EN { get; set; }
        public string? Client { get; set; }
        public string? Design_Solution { get; set; }
        public string? Photo_Credit { get; set; }
        public string? Content_TH { get; set; }
        public string? Content_EN { get; set; }
        //public string? File_Download { get; set; }

    }
    public class Output_ProjectRef_PreviewVM
    {
        public int Id { get; set; }
        public string Title_TH { get; set; }
        public string Title_EN { get; set; }
        public string PreView_Image { get; set; }
    }
}
