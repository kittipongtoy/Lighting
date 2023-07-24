using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class receive_agenda_mail_accounts : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? account { get; set; } 
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
