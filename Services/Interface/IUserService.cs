using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Enums;
using LIBRARY_MANAGEMENT_SYSTEM.Utilities;

namespace LIBRARY_MANAGEMENT_SYSTEM.Services.Interface
{
    public interface IUserService
    {
        ApiResponse Delete(int userId);
        ApiResponse<IEnumerable<UserResponseDto>> GetAll();
        ApiResponse<object> UpdateRole(int userId, string role);
    }
}