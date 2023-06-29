using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Import_Info_ShareHolder : IProperty
    {
        [Key]
        public int id { get; set; }
        public string titleTH { get; set; }
        public string titleENG { get; set; }
        public string detailsTitleTH { get; set; }
        public string detailsTitleENG { get; set; }  
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
