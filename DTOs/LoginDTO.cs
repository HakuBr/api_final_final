using System.ComponentModel.DataAnnotations;

namespace APIsprint.DTOs.AuthDTOs
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }
    }
}