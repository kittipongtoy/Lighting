using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_propose_agenda_receive_mails : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? receiveMail { get; set; } 
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
