using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lighting.Areas.Identity.Data
{
    public class News
    {

        [Key]
        public int Id { get; set; }
        public string?  Title_EN {get; set; }
        public string? Title_TH { get; set; }
        public string? ImagePath { get; set; }
        public string? Content_TH { get; set; }
        public string? Content_EN { get; set; }
        public DateTime? CreateDate_TH { get; set; }
        public DateTime? CreateDate_EN { get; set; }

    }
}
