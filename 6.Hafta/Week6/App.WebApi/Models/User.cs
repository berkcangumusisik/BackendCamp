using System.ComponentModel.DataAnnotations;

namespace App.WebApi.Models
{
    public class User
    {
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Range(typeof(DateTime), "1900-01-01", "2024-12-31")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(1000)]
        public string Address { get; set; }

        [Required]
        [MinLength(4)]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,24}$")]
        public string Password { get; set; }

        [Required]
        //[Compare("Password")]
        [Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }
    }
}
