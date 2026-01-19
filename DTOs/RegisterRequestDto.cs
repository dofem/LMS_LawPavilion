using LIBRARY_MANAGEMENT_SYSTEM.Enums;
using System.ComponentModel.DataAnnotations;

namespace LIBRARY_MANAGEMENT_SYSTEM.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
