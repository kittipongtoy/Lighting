using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
	public class O_Author_secretary_File : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? image_name { get; set; }
        public string? image_name_ENG { get; set; }
        public string? title_file_th { get; set; }
        public string? title_file_en { get; set; }
        public string? file_name { get; set; }
        public string? file_name_ENG { get; set; }
        public string? file_type { get; set; }
        public int? use_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}