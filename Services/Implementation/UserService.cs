using LIBRARY_MANAGEMENT_SYSTEM.Data;
using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Enums;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Interface;
using LIBRARY_MANAGEMENT_SYSTEM.Utilities;

namespace LIBRARY_MANAGEMENT_SYSTEM.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public ApiResponse<IEnumerable<UserResponseDto>> GetAll()
        {
            var users =  _context.Users
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role
                })
                .ToList();
            return ApiResponse<IEnumerable<UserResponseDto>>.Success(users,ApiResponseMessages.UsersRetrieved);
        }
        public ApiResponse<object> UpdateRole(int userId, string role)
        {
            if (!Enum.TryParse<UserRole>(role, true, out var userRole))
            {
                return ApiResponse<object>.Fail(
                    "Invalid role specified",
                    ApiResponseMessages.ErrorCode
                );
            }
            var user = _context.Users.Find(userId);
            if(user is null)
            {
                return ApiResponse<object>.Fail(ApiResponseMessages.UserNotFound, ApiResponseMessages.NotFoundError);
            }
            user.Role = userRole;
            _context.SaveChanges();

            return ApiResponse<object>.Success(ApiResponseMessages.RoleUpdated);
        }
        public ApiResponse Delete(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user is null)
            {
                return ApiResponse<object>.Fail(ApiResponseMessages.UserNotFound, ApiResponseMessages.NotFoundError);
            }
            _context.Users.Remove(user);
            _context.SaveChanges();

            return ApiResponse<object>.Success(ApiResponseMessages.UserDeleted);
        }
    }

}
