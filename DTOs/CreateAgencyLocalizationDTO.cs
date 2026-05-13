using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.AgencyLocalizationDTOs
{
    public class CreateAgencyLocalizationDTO
    {
        [Required]
        public int agency_id { get; set; }

        [Required]
        [StringLength(5)]
        public string agency_number_identification { get; set; }

        [Required]
        [MaxLength(40)]
        public string agency_city { get; set; }

        [Required]
        [MaxLength(40)]
        public string agency_neighbordhood { get; set; }

        [Required]
        [MaxLength(40)]
        public string agency_road { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public short agency_number { get; set; }
    }
}