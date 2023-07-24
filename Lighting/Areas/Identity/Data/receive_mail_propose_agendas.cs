using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class receive_mail_propose_agendas : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? wantProposeTitle { get; set; }
        public string? details { get; set; } 
        public string? typeOfPropose { get; set; } 
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
