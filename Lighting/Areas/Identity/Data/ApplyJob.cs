namespace Lighting.Areas.Identity.Data
{
    public class ApplyJob
    {
        public int Id { get; set; }
        public string PositionName_TH { get; set; }
        public string PositionName_EN { get; set; }
        public string? Date_TH { get; set; }
        public string? Date_EN { get; set; }
        public string? Quantity { get; set; }
        public string? WorkPlace_TH { get; set; }
        public string? WorkPlace_EN { get; set; }
        public string? Respondsibility_TH { get; set; }
        public string? Respondsibility_EN { get; set; }
        public string? Qualification_TH { get; set; }
        public string? Qualification_EN { get; set; }
        public string? Email1 { get; set; }
        //public string? Email2 { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
