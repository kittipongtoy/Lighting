using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations; 

namespace Lighting.Areas.Identity.Data
{
    public class privacy_Policys : IProperty
    {
        [Key]
        public int id { get; set; } 
        public DateTime? year { get; set; }
        public int? typeOfPolicy_id { get; set; }
        public string? typeOfPolicy { get; set; }
        public string? detailsTH { get; set; }
        public string? detailsENG { get; set; }
        public int? active_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
