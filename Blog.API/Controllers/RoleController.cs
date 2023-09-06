using Blog.Core.IServices;
using Blog.Core.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult<List<GetAllRolesDto>> GetAllRoles()
        {
            return _roleService.GetAllRoles();
        }

        [HttpPost("{roleName}")]
        public async Task<IActionResult> AddRole([FromRoute] string roleName)
        {
            var result = await _roleService.AddRole(roleName);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleDto updateRole)
        {
            var result = await _roleService.UpdateRole(updateRole.RoleName, updateRole.UpdatedName);

            return Ok(result);
        }

        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole([FromRoute] string roleName)
        {
            var result = await _roleService.DeleteRole(roleName);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleDto addUserToRole)
        {
            var result = await _roleService.AddUserToRole(addUserToRole.UserId.ToString(), addUserToRole.RoleName);

            return Ok(result);
        }
    }
}
