﻿using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string ContactType { get; set; }
        public string? Sub_Factory_Name_TH { get; set; }
        public string? Sub_Factory_Name_EN { get; set; }
        public string PlaceName_TH { get; set; }

        public string PlaceName_EN { get; set; }

        public string Location_TH { get; set; }

        public string Location_EN { get; set; }

        public string? CellPhone { get; set; }
        public string? TelePhone { get; set; }
        public string? OfficePhone { get; set; }

        public string? ImagePath { get; set; }
        public string? Email { get; set; }
        public string? GoogleMaps_Url { get; set; }
        public string? YouTube_Url { get; set; }
    }
}
