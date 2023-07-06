using System.ComponentModel.DataAnnotations;

namespace Lighting.Models.InputFilterModels.Contact
{

    public class Input_ContactVM
    {
        [Required]
        public string ContactType { get; set; } 
        [Required]
        public string PlaceName_TH { get; set; }
        [Required]
        public string PlaceName_EN { get; set; }
        [Required]
        public string Location_TH { get; set; }
        [Required]
        public string Location_EN { get; set;}

        public string? CellPhone { get; set; }
        public string? TelePhone { get; set; }
        public string? OfficePhone { get; set; }

        public IFormFile? Image { get; set; }
        public string? Email { get; set; }
        public string? GoogleMaps_Url { get; set; }
        public string? YouTube_Url { get; set; }
    }
    public class Output_ContactVM
    {
        public int Id { get; set; }
        public string ContactType { get; set; }
 
        public string PlaceName_TH { get; set; }

        public string PlaceName_EN { get; set; }

        public string Location_TH { get; set; }

        public string Location_EN { get; set; }

        public string? CellPhone { get; set; }
        public string? TelePhone { get; set; }
        public string? OfficePhone { get; set; }

        public string? ImagePath { get; set; }
        public string? Email { get; set; }
        public string? GoogleMaps_Url { get; set; }
        public string? YouTube_Url { get; set; }
    }
}
