using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public partial class ShareHolder : IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? TitleTH { get; set; }
        public string? TitleENG { get; set; }
        public string? detailsTitleTH { get; set; }
        public string? detailsTitleENG { get; set; }
        public string? detailsTH { get; set; }
        public string? detailsENG { get; set; }
        public string? nameTitleTH { get; set; }
        public string? nameTitleENG { get; set; }
        public string? amountTitleTH { get; set; }
        public string? amountTitleENG { get; set; }
        public string? percentTitleTH { get; set; }
        public string? percentTitleENG { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}