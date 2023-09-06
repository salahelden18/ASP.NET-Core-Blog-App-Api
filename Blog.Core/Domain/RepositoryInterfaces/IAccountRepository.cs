using Blog.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.RepositoryInterfaces
{
    public interface IAccountRepository
    {
        Task<ApplicationUser?> CreateUser(ApplicationUser user, string password);
        Task<bool> LoginUser(ApplicationUser user, string password);
    }
}
