using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.AgencyDTOs
{
    public class CreateAgencyDTO
    {
        [Required]
        public int account_id { get; set; }

        [Required]
        [MaxLength(40)]
        public string bank_name { get; set; }
    }
}