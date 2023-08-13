﻿using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class IR_LIGHTING_EQUIPMENT : IProperty
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Title_TH { get; set; }
        public string? Title_EN { get; set; }
        public string? SubTitle_TH { get; set; }
        public string? SubTitle_EN { get; set; }
        public string? RegisterTH { get; set; }
        public string? RegisterEN { get; set; }
        public string? Link_TH { get; set; }
        public string? Link_EN { get; set; }
        public int? Status { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
