using System.ComponentModel.DataAnnotations;

namespace Lighting.Models.InputFilterModels.ApplyJob
{
    public class Input_ApplyJobVM
    {
        [Required]
        public string PositionName_TH { get; set; }
        [Required]
        public string PositionName_EN { get; set; }
        public string? Date_TH { get; set; }

        public string? Date_EN { get; set; }
        public string? Quantity { get; set; }
        public string? WorkPlace_TH { get; set; }
        public string? WorkPlace_EN { get; set; }
        public string? Respondsibility_TH { get; set; }
        public string? Respondsibility_EN { get; set; }
        public string? Qualification_TH { get; set; }
        public string? Qualification_EN { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? PhoneNumber { get; set;}

    }
    public class Output_ApplyJobVM
    {
        public int Id { get; set; }
        public string? PositionName_TH { get; set; }
        public string? PositionName_EN { get; set; }
        public string? Date_TH { get; set; }
        public string? Date_EN { get; set; }
        public string? Quantity { get; set; }
        public string? WorkPlace_TH { get; set; }
        public string? WorkPlace_EN { get; set; }
        public string? Respondsibility_TH { get; set; }
        public string? Respondsibility_EN { get; set; }
        public string? Qualification_TH { get; set; }
        public string? Qualification_EN { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
