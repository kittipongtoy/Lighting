using Lighting.Areas.Identity.GeneraIProperty;
using System.ComponentModel.DataAnnotations;

namespace Lighting.Areas.Identity.Data
{
    public class Board_of_Directors : IProperty
	{
        [Key]
        public int id { get; set; }
        public string? name_th { get; set; }
        public string? name_en { get; set; }
        public string? image_name { get; set; }
        public string? position_th { get; set; }
        public string? position_en { get; set; }
        public int? type_board { get; set; }
        public int? use_status { get; set; }
        public int? sort_number { get; set; }
        public string? position_company_th { get; set; }
        public string? position_company_en { get; set; }
        public string? nationality_th { get; set; }
        public string? nationality_en { get; set; }
        public string? study_th { get; set; }
        public string? study_en { get; set; }
        public string? expertise_th { get; set; }
        public string? expertise_en { get; set; }
        public string? date_appointment_th { get; set; }
        public string? date_appointment_en { get; set; }
        public string? shares_held_th { get; set; }
        public string? shares_held_en { get; set; }
        public string? training_course_th { get; set; }
        public string? training_course_en { get; set; }
        public string? work_history_th { get; set; }
        public string? work_history_en { get; set; }
        public string? holding_position_th { get; set; }
        public string? holding_position_en { get; set; }
        public string? Illegal_history_th { get; set; }
        public string? Illegal_history_en { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}