using Blog.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    public interface IRoleService
    {
        Task<bool> AddRole(string roleName);
        Task<bool> AddUserToRole(string userId, string roleName);
        Task<bool> UpdateRole(string roleName, string updatedName);
        Task<bool> DeleteRole(string roleName);
        List<GetAllRolesDto> GetAllRoles();
    }
}
