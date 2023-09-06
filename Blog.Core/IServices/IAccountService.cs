using Blog.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    public interface IAccountService
    {
        Task<TokenDto> Login(LoginDto loginDto);
        Task<TokenDto> SignUp(SignUpDto signUpDto);
    }
}
