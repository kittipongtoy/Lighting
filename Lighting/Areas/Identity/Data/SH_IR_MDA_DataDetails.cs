﻿using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class SH_IR_MDA_DataDetails : IProperty
    {
        [Key]
        public int id { get; set; }
        public string? title { get; set; } 
        public DateTime? year { get; set; }
        public string? file_name { get; set; }
        public string? file_name_ENG { get; set; }
        public int? active_status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
