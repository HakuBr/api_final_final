
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIsprint.Models
{
    [Table("tbl_Person")]
    public class Person
    {
        [Key]
        public int person_id { get; set; }

        [Required]
        [MaxLength(40)]
        public string person_name { get; set; }

        [Required]
        [MaxLength(40)]
        public string person_surname { get; set; }

        [Required]
        [StringLength(11)]
        public string cpf { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string occupation { get; set; }

        public decimal monthly_income { get; set; }
    }
}