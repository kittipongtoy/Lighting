using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class IR_Stock_QuoteDetail:IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? STOCK_PRICE_TH { get; set; }
        public string? STOCK_PRICE_EN { get; set; }
        public string? Link_STOCK_PRICE { get; set; }
        public string? Link_STOCK_PRICE_EN { get; set; }
        public string? SET_INDEX_TH { get; set; }
        public string? SET_INDEX_EN { get; set; }
        public string? Link_SET_INDEX_TH { get; set; }
        public string? Link_SET_INDEX_EN { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
