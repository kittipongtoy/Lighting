using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_prospectus : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? Link { get; set; } 
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
