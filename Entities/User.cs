using LIBRARY_MANAGEMENT_SYSTEM.Enums;

namespace LIBRARY_MANAGEMENT_SYSTEM.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }


}
