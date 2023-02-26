using StudentInformation.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace StudentInformation.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? StudentRoll { get; set; }
        public string? Password { get; set; }
        public AppRoles Role { get; set; } = AppRoles.Student;
    }
}
