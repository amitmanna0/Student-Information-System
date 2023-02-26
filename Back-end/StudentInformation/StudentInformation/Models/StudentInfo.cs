using System.ComponentModel.DataAnnotations;


namespace StudentInformation.Models
{
    public class StudentInfo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Student roll Can't be Blank")]
        public string? StudentRoll { get; set; }
        [Required(ErrorMessage = "Name Can't be Blank")]
        public string? StudentName { get; set; }
        [Required(ErrorMessage = "Father name Can't be Blank")]
        public string? FatherName { get; set; }
        [Required(ErrorMessage = "Phone number Can't be Blank")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Only 10 digit allow")]
        public int PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Address Can't be Blank")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Course Can't be Blank")]
        public string? Course { get; set; }
        [Required(ErrorMessage = "Deparment Can't be Blank")]
        public string? Department { get; set; }
        [Required(ErrorMessage = "Admission Can't be Blank")]
        public int AdmissionYear { get; set; }
    }
}
