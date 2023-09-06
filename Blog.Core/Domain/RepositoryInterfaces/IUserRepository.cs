using Blog.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserByEmail(string Email);
        Task<string> GetUserRole(ApplicationUser user);
    }
}
