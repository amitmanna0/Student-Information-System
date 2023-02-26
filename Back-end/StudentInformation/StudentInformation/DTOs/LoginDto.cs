
using System.ComponentModel.DataAnnotations;

namespace StudentInformation.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; }
    }
}
