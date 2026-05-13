using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.CardDTOs
{
    public class CreateCardDTO
    {
        [Required]
        public int account_id { get; set; }

        [Required]
        [MaxLength(7)]
        public string card_type { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal card_limit { get; set; }

        [Required]
        public DateTime expiration_date { get; set; }
    }
}