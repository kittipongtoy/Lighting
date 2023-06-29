using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class IR_MassMediaDetail : IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Title_TH { get; set; }
        public string? Title_EN { get; set; }
        public DateTime? NewDate { get; set; }
        public string? Detail_TH { get; set; }
        public string? Detail_EN { get; set; }
        public string? Question_TH { get; set; }
        public string? Question_EN { get; set; }
        public string? ContactUs_Name1_TH { get; set; }
        public string? ContactUs_Name1_EN { get; set; }
        public string? ContactUs_Name2_TH { get; set; }
        public string? ContactUs_Name2_EN { get; set; }
        public string? ContactUs_Tel { get; set; }
        public string? ContactUs_Tel2 { get; set; }
        public string? ContactUs_Mail1 { get; set; }
        public string? ContactUs_Mail2 { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
