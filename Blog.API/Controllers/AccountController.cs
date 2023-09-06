using Blog.Core.Domain.Entities;
using Blog.Core.IServices;
using Blog.Core.Models.Dtos;
using Blog.Core.Models.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            // validation
            if(!ModelState.IsValid)
            {
                string errorMessage = string.Join(" ", ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
                throw new BadRequestException(errorMessage);
            }

            var result = await _accountService.SignUp(signUpDto);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            // validation
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join(" ", ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage));
                throw new BadRequestException(errorMessage);
            }

            var result = await _accountService.Login(loginDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> IsEmailAlreadyRegistered(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                return Ok(true);
            }
            return Ok(false);
        }
    }
}
