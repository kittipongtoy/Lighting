namespace Lighting.Areas.Identity.Data
{
    public class Download
    {
        public int Id { get; set; }
        public string DownloadType { get; set; }
        public string Name_EN { get; set; }
        public string Name_TH { get; set; }
        public string File_Path { get; set; }
        public string? L_AND_BIM_Link { get; set; }
    }
}
