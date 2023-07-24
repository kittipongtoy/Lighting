using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class ProjectRef_Product
    {
        [Key]
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? ProjectId { get; set; }
    }
}
