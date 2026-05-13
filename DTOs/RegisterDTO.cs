using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}