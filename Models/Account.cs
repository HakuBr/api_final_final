
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIsprint.Models
{
    

    public enum Account_type {
        Corrente = 1,
        Poupanca = 2
        
    }

    [Table("tbl_Account")]
    public class Account
    {
        [Key]
        public int account_id { get; set; }

        [Required]
        public Account_type account_type { get; set; }

        [Required]
        public decimal balance { get; set; }

        [Required]
        public decimal credit { get; set; }

        [Required]
        [MaxLength(40)]
        public string email { get; set; }

        [Required]
        [MaxLength(255)]
        public string pass_word { get; set; }

        public int person_id { get; set; }

        [ForeignKey("person_id")]
        public Person Person { get; set; }
    }
}