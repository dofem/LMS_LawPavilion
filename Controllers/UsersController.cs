using LIBRARY_MANAGEMENT_SYSTEM.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LIBRARY_MANAGEMENT_SYSTEM.DTOs;
using LIBRARY_MANAGEMENT_SYSTEM.Enums;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Implementation;
using LIBRARY_MANAGEMENT_SYSTEM.Services.Interface;

namespace LIBRARY_MANAGEMENT_SYSTEM.Controllers
{
  

    [ApiController]
    [Route("api/users")]
    [Authorize(Roles = nameof(UserRole.Admin))]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUsers")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
           

        [HttpPut("{id}/role")]
        public IActionResult UpdateRole(int id, [FromBody] UpdateUserRoleDto dto)
        {
            var resp = _userService.UpdateRole(id, dto.Role);
            return Ok(resp);
        }
            
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var resp =  _userService.Delete(id);
            return Ok(resp);
        }
           
    }


}
