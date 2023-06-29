using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class IR_Contact : IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? Title_TH { get; set; }
        public string? Title_EN { get; set; }
        public string? SubTitle_TH { get; set; }
        public string? SubTitle_EN { get; set; }
        public string? Image { get; set; }
        public string? Name_TH { get; set; }
        public string? Name_EN { get; set; }
        public string? Position_TH { get; set; }
        public string? Position_EN { get; set; }
        public string? Address_TH { get; set; }
        public string? Address_EN { get; set; }
        public string? Tel { get; set; }
        public string? Tel2 { get; set; }
        public string? Email { get; set; }    
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
