using Blog.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.RepositoryInterfaces
{
    public interface IRoleRepository
    {
        List<ApplicationRole> GetAllRoles();
        Task<bool> AddRole(string roleName);
        Task<bool> AddUserToRole(string userId, string roleName);
        Task<bool> UpdateRole(string roleName, string updatedName);
        Task<bool> DeleteRole(string roleName);

    }
}
