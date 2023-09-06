using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.Models.Errors;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser?> GetUserByEmail(string Email)
        {
            var result = await _userManager.FindByEmailAsync(Email);

            return result;
        }

        public async Task<string> GetUserRole(ApplicationUser user)
        {
            var result = await _userManager.GetRolesAsync(user);

            return result[0];// return first role user will have just one role
        }
    }
}
