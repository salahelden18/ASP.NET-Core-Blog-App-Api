using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.Extensions;
using Blog.Core.Models.Errors;
using Microsoft.AspNetCore.Identity;

namespace Blog.Infra.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AddUserToRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId) ?? throw new NotFoundException("No User With the Provided Id");
            _ = await _roleManager.FindByNameAsync(roleName) ?? throw new NotFoundException("No Role With the Provided Id");

            var result = await _userManager.AddToRoleAsync(user, roleName);

            return RoleExtensions.ProcessResult(result);
        }

        public async Task<bool> AddRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new ApplicationRole
            {
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                Id = Guid.NewGuid(),
            });

            return RoleExtensions.ProcessResult(result);
        }

        public async Task<bool> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName) ?? throw new NotFoundException("No Role With the Specified Name Exist");
            
            var result = await _roleManager.DeleteAsync(role);

            return RoleExtensions.ProcessResult(result);
        }

        public async Task<bool> UpdateRole(string roleName, string updatedName)
        {
            var role = await _roleManager.FindByNameAsync(roleName) ?? throw new NotFoundException("No Role With the Specified Name Exist");

            role.Name = updatedName;
            role.NormalizedName = updatedName.ToUpper();

            var result = await _roleManager.UpdateAsync(role);

            return RoleExtensions.ProcessResult(result);
        }

        public List<ApplicationRole> GetAllRoles()
        {
            return (_roleManager.Roles.AsEnumerable()).ToList();
        }
    }
}
