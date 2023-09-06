using Blog.Core.Domain.Entities;
using Blog.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    public interface ITokenService
    {
        TokenDto CreateToken(ApplicationUser user, string role);
    }
}
