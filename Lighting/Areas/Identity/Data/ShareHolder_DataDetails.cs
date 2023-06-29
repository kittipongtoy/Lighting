using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public partial class ShareHolder_DataDetails : IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? nameTH { get; set; }
        public string? nameENG { get; set; }
        public string? amount { get; set; }
        public string? percentPerAmount { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}