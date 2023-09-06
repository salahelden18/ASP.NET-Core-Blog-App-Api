using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.IServices;
using Blog.Core.Models.Dtos;
using Blog.Core.Models.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IAuthorRepository _authorRepository;

        public AccountService(
            IAccountRepository accountRepository, 
            ITokenService tokenService,
            IUserRepository userRepository,
            IAuthorRepository authorRepository)
        {
            _accountRepository = accountRepository;
            _tokenService = tokenService;
            _userRepository = userRepository;
            _authorRepository = authorRepository;
        }

        public async Task<TokenDto> SignUp(SignUpDto signUpDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                Email = signUpDto.Email,
                PhoneNumber = signUpDto.PhoneNumber,
                UserName = signUpDto.Email,
                FullName = signUpDto.Name,
                Address = signUpDto.Address,
            };

            var result = await _accountRepository.CreateUser(user, signUpDto.Password);

            if (result != null)
            {
                // create Author
                var author = new Author { UserId = user.Id };

                author = await _authorRepository.CreateAuthor(author);

                if(author != null)
                {
                    // create the token
                    var tokenRsult = _tokenService.CreateToken(user, "Author");
                    return tokenRsult;
                }
                else
                {
                    throw new InternalServerException("Error While Creating Author Account! If The Problem Presisted Please Contact Us");
                }
            }else
            {
                throw new InternalServerException("Error While Creating Your Account Please Try Agian Later!, Contact Support If Error Presisted");
            }
        }

        public async Task<TokenDto> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email) ?? throw new NotFoundException("Email Or Password Is Incorrect");

            bool loginResult = await _accountRepository.LoginUser(user, loginDto.Password);

            if (loginResult)
            {
                // get user role
                var role = await _userRepository.GetUserRole(user);

                var tokenRsult = _tokenService.CreateToken(user, role);
                return tokenRsult;
            }
            else
            {
                throw new BadRequestException("User Email Or Password is Incorrect");
            }
        }
    }
}
