using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.Models.Dtos;
using Blog.Core.Models.Errors;
using Microsoft.AspNetCore.Identity;

namespace Blog.Infra.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser?> CreateUser(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "Author");

                if(roleResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }else
                {
                    string roleErrorMessage = string.Join(" ", roleResult.Errors.Select(e => e.Description));
                    throw new BadRequestException(roleErrorMessage);
                }
                return user;
            }
            else
            {
                string errorMessage = string.Join(" ", result.Errors.Select(e => e.Description));

                throw new BadRequestException(errorMessage);
            }
        }

        public async Task<bool> LoginUser(ApplicationUser user, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return true;
            }
            
            return false;
        }
    }
}