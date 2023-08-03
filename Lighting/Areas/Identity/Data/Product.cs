using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        //category
        public int Product_CategoryId { get; set; }
        //sub category
        public int Product_ModelId { get; set; }

        public string Folder_Path { get; set; }
        public string? Model { get; set; }
        public string? Type_TH { get; set; }
        public string? Type_EN { get; set; }
        public string Preview_Image { get; set; }
        public string? SUB_IMG { get; set; }
        public string? CUTSHEET { get; set; }
        public string? IESFILE { get; set; }
        public string? CATALOGUE { get; set; }
        public string? RFA { get; set; }
        public string? MORE_INFORMATION { get; set; }

        public string? Application { get; set; }

        public string? Technical_Drawing { get; set; }
        public string? Technical_Drawing_Img { get; set; }
        //spect
        public string? IP_Rating { get; set; }
        public string? Dimension { get; set; }
        public string? Power { get; set; }
        public List<Product_Spect>? ProductSpect {get; set;} = new List<Product_Spect>();
        //public string? Housing { get; set;}
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
        public string? LIGHT_DISTRIBUTION { get; set; }
    }
}
