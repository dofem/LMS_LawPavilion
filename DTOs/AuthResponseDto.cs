namespace LIBRARY_MANAGEMENT_SYSTEM.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }             // JWT token
        public DateTime Expires { get; set; }         // UTC expiration
    }

}
