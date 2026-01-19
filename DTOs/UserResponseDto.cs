using LIBRARY_MANAGEMENT_SYSTEM.Enums;

namespace LIBRARY_MANAGEMENT_SYSTEM.DTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
    }

    public class UpdateUserRoleDto
    {
        public string Role { get; set; }
    }

}
