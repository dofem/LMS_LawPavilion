using LIBRARY_MANAGEMENT_SYSTEM.Utilities;
using Microsoft.AspNetCore.Mvc;
using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Implementation;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using LIBRARY_MANAGEMENT_SYSTEM.Enums;
namespace LIBRARY_MANAGEMENT_SYSTEM.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

      
        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestDto dto)
        {
            var resp = _authService.Register(dto);
            return Ok(resp);
        }
           

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            var resp = _authService.Login(dto);
                return Ok(resp);         
        }      
    }
}
