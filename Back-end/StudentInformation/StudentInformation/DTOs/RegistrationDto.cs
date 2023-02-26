using StudentInformation.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace StudentInformation.DTOs
{
    public class RegistrationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? StudentRoll { get; set; }
        public string? Password { get; set; }
       
    }
}
