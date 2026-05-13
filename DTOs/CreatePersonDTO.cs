using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.PersonDTOs
{
    public class CreatePersonDTO
    {
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
        [Range(1, 120)]
        public int age { get; set; }

        [Required]
        [MaxLength(40)]
        public string occupation { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal monthly_income { get; set; }
    }
}