using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Utilities;

namespace LIBRARY_MANAGEMENT_SYSTEM.Services.Interface
{
    public interface IAuthService
    {
        ApiResponse<AuthResponseDto> Login(LoginRequestDto dto);
        ApiResponse<object> Register(RegisterRequestDto dto);
    }
}