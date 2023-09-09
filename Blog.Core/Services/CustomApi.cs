using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class CustomApi
    {
        private readonly IHttpContextAccessor _context;
        private readonly ILogger<CustomApi> _logger;
        
        public CustomApi(IHttpContextAccessor httpContextAccessor, ILogger<CustomApi> logger)
        {
            _context = httpContextAccessor;
            _logger = logger;
        }

        public string Id
        {
            get
            {
                return _context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }

        public string EmailAddress => _context.HttpContext.User.FindFirst("email").Value;
        public string FullName => _context.HttpContext.User.FindFirst("fullName").Value;


        public string Role => _context.HttpContext.User.FindFirst(ClaimTypes.Role).Value;
    }
}
