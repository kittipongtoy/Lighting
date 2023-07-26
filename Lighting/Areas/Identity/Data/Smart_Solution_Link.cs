using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Smart_Solution_Link
    {
        [Key]
        public int Id { get; set; }
        public string? Link { get; set; }
        public string? Path { get; set; }

        public int? Smart_SolutionId { get; set; }
        public Smart_Solution? Smart_Solution { get; set; }
    }
}
