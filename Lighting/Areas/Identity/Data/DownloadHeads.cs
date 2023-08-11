using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class DownloadHeads : IProperty
    {
        public int id { get; set; } 
        public string title_TH { get; set; }
        public string Title_ENG { get; set; } 
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
