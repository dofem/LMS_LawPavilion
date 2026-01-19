using LIBRARY_MANAGEMENT_SYSTEM.Entities;

namespace LIBRARY_MANAGEMENT_SYSTEM.Services.Interface
{
    public interface ITokenService
    {
        string GenerateToken(User user, out DateTime expires);
    }
}