namespace LIBRARY_MANAGEMENT_SYSTEM.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class LoginRequestDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
