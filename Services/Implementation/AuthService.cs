using LIBRARY_MANAGEMENT_SYSTEM.Data;
using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Entities;
using LIBRARY_MANAGEMENT_SYSTEM.Utilities;
using System.Security.Claims;
using System;
using LIBRARY_MANAGEMENT_SYSTEM.Enums;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Interface;

namespace LIBRARY_MANAGEMENT_SYSTEM.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(AppDbContext context, ITokenService tokenService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _tokenService = tokenService;
            _httpContextAccessor = httpContextAccessor;
        }
        public ApiResponse<object> Register(RegisterRequestDto dto)
        {
            var roleClaim = _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.Role);
            if (!Enum.TryParse<UserRole>(roleClaim, true, out var currentUserRole)
                || currentUserRole != UserRole.Admin)
            {
                return ApiResponse<object>.Fail(
                    "Only Admin can register users",
                    ApiResponseMessages.ErrorCode
                );
            }

            if (_context.Users.Any(u => u.Username == dto.Username))
            {
                return ApiResponse<object>.Fail(
                    "User already exists",
                    ApiResponseMessages.ErrorCode
                );
            }

            if (!Enum.TryParse<UserRole>(dto.Role, true, out var userRole))
            {
                return ApiResponse<object>.Fail(
                    "Invalid role specified",
                    ApiResponseMessages.ErrorCode
                );
            }

            var user = new User
            {
                Username = dto.Username.Trim(),
                PasswordHash = PasswordHasherMethod.Hash(dto.Password),
                Role = userRole
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return ApiResponse<object>.Success(ApiResponseMessages.UserCreated);
        }
        public ApiResponse<AuthResponseDto> Login(LoginRequestDto dto)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == dto.Username);

            if (user == null || !PasswordHasherMethod.Verify(dto.Password, user.PasswordHash))
            {
                return ApiResponse<AuthResponseDto>.Fail(ApiResponseMessages.InvalidCredentials, ApiResponseMessages.InvalidCredentialsCode);
            }

            var token = _tokenService.GenerateToken(user, out DateTime expires);

            var response = new AuthResponseDto
            {           
                Token = token,
                Expires = expires
            };

            return ApiResponse<AuthResponseDto>.Success(response, "Login successful");
        }
    }

}
