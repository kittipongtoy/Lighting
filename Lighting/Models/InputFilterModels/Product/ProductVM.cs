using Lighting.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Models.InputFilterModels.Product
{
    public class Input_ProductVM
    {
        [Required]
        public int Product_CategoryId { get; set; }
        [Required]
        public int Product_ModelId { get; set; }
        public string? Model { get; set; }
        public string? Type_TH { get; set; }
        public string? Type_EN { get; set; }
        public IFormFile? Preview_Image { get; set; }
        public IFormFile? Preview_Image2 { get; set; }
        public IFormFile? SUB_IMG { get; set; }
        public IFormFile? CUTSHEET { get; set; }
        public IFormFile? IESFILE { get; set; }
        public IFormFile? CATALOGUE { get; set; }
        public IFormFile? RFA { get; set; }
        public string? MORE_INFORMATION { get; set; }

        public string? Application { get; set; }

        //public string? Technical_Drawing { get; set; }
        public List<IFormFile>? Technical_Drawing_Img { get; set; }

        public string? Power { get; set; }
        public string? IP_Rating { get; set; }
        public string? Dimension { get; set; }

        //public string? Housing { get; set; }
        //public string? Finishing { get; set; }
        //public string? Lens { get; set; }
        //public string? Gasket { get; set; }
        //public string? Mounting { get; set; }
        //public string? Source { get; set; }
        //public string? Lamp_Colour { get; set; }
        //public string? Luminaire_Output { get; set; }
        //public string? Beam_Angle { get; set; }
        //public string? Control_Gear { get; set; }
        //public string? Power_Supply { get; set; }
        //public string? Luminaire_Lifetime { get; set; }
        //public string? Equivalent { get; set; }

        public List<string>? Spect_Name { get; set; }
        public List<string>? Spect_Value { get; set; }
        public List<IFormFile>? LIGHT_DISTRIBUTION { get; set; }
    }

    public class Output_ProductVM
    {
        public int Id { get; set; }
        public int Product_CategoryId { get; set; }
        public int Product_ModelId { get; set; }
        public string Folder_Path { get; set; }
        public string? Model { get; set; }
        public string? Type_TH { get; set; }
        public string? Type_EN { get; set; }
        public string Preview_Imamge_Show { get; set; }
        public string Preview_Imamge { get; set; }
        public string? SUB_IMG { get; set; }
        public string? CUTSHEET { get; set; }
        public string? IESFILE { get; set; }
        public string? CATALOGUE { get; set; }
        public string? RFA { get; set; }
        public string? MORE_INFORMATION { get; set; }

        public string? Application { get; set; }

        //public string? Technical_Drawing { get; set; }
        public List<string>? Technical_Drawing_Img { get; set; }
        public string? Power { get; set; }
        public string? IP_Rating { get; set; }
        public string? Dimension { get; set; }

        //public string? Housing { get; set; }
        //public string? Finishing { get; set; }
        //public string? Lens { get; set; }
        //public string? Gasket { get; set; }
        //public string? Mounting { get; set; }
        //public string? Source { get; set; }
        //public string? Lamp_Colour { get; set; }
        //public string? Luminaire_Output { get; set; }
        //public string? Beam_Angle { get; set; }
        //public string? Control_Gear { get; set; }
        //public string? Power_Supply { get; set; }
        //public string? Luminaire_Lifetime { get; set; }
        //public string? Equivalent { get; set; }

        public List<Product_Spect> Product_Spects { get; set; }
        public List<string>? LIGHT_DISTRIBUTION { get; set; }
    }

    public class Input_ProductCategoryVM
    {
        public IFormFile? Image { get; set; }
        //public IFormFile? ImageShow { get; set; }
        public string Name_EN { get; set; }
        public string Name_TH { get; set; }
    }

    public class Output_ProductCategoryVM
    {
        public int Id { get; set; } 
        public string Name_EN { get; set; }
        public string Name_TH { get; set; }
        public string Image { get; set; }
        public string ImageShow { get; set; }
    }

    public class Input_ProductModelVM
    {
        [Required]
        public int Product_CategoryId { get; set; }
        public IFormFile? Image { get; set; }
        [Required]
        public string Name_EN { get; set; }
        [Required]
        public string Name_TH { get; set; }
    }

    public class Output_ProductModelVM
    {
        public int Id { get; set; }
        public int Product_CategoryId { get; set; }
        public string Image { get; set; }
        public string Name_EN { get; set; }
        public string Name_TH { get; set; }
    }
}
