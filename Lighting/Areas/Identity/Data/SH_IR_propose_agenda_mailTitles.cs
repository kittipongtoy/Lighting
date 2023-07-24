using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_propose_agenda_mailTitles : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? titleTH { get; set; }
        public string? titleENG { get; set; }
        public string? nameTitleTH { get; set; }
        public string? nameTitleENG { get; set; }
        public string? nameTitlePlaceholderTH { get; set; }
        public string? nameTitlePlaceholderENG { get; set; }
        public string? emailTitleTH { get; set; }
        public string? emailTitleENG { get; set; }
        public string? emailTitlePlaceholderTH { get; set; }
        public string? emailTitlePlaceholderENG { get; set; }
        public string? phoneTH { get; set; }
        public string? phoneENG { get; set; }
        public string? phoneTitlePlaceholder { get; set; } 
        public string? proposeTitleTH { get; set; }
        public string? proposeTitleENG { get; set; }
        public string? wantProposeTitleTH { get; set; }
        public string? wantProposeTitleENG { get; set; }
        public string? wantProposePlaceholderTitleTH { get; set; }
        public string? wantProposePlaceholderTitleENG { get; set; }
        public string? detailsTitleTH { get; set; }
        public string? detailsTitleENG { get; set; }
        public string? detailsPlaceholderTitleTH { get; set; }
        public string? detailsPlaceholderTitleENG { get; set; } 
        public string? detailsTH { get; set; }
        public string? detailsENG { get; set; }
        public string? remarkTH { get; set; }
        public string? remarkENG { get; set; }
        public int? active_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
