using System.ComponentModel.DataAnnotations;
namespace Lighting.Areas.Identity.Data
{
    public class Product_Spect
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Value { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
