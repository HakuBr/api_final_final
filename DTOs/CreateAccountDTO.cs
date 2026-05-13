using APIsprint.Models;
using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.AccountDTOs
{
    public class CreateAccountDTO
    {
        [Required]
        public Account_type account_type { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal balance { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal credit { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(40)]
        public string email { get; set; }

        [Required]
        [MaxLength(255)]
        public string pass_word { get; set; }

        [Required]
        public int person_id { get; set; }
    }
}