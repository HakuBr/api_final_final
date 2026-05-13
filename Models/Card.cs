
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIsprint.Models
{
    [Table("tbl_Card")]
    public class Card
    {
        [Key]
        public int card_id { get; set; }

        public int account_id { get; set; }

        [ForeignKey("account_id")]
        public Account Account { get; set; }

        [Required]
        [MaxLength(7)]
        public string card_type { get; set; }

        [Required]
        public decimal card_limit { get; set; }

        [Required]
        [Column(TypeName = "date")] 
        public DateOnly expiration_date { get; set; }
    }
}