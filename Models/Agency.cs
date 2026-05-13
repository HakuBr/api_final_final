
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIsprint.Models
{
    [Table("tbl_Agency")]

    public class Agency
    {
        [Key]
        public int agency_id { get; set; }

        public int account_id { get; set; }

        [ForeignKey("account_id")]
        public Account Account { get; set; }    

        [Required]
        [MaxLength(40)]
        public string bank_name { get; set; }

    }
}