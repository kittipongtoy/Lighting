using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class DownloadTypes : IProperty
    {
        public int id { get; set; }
        public string? DownloadType_name_TH { get; set; }
        public string? DownloadType_name_ENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
