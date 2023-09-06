using Blog.Core.Models.Errors;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Extensions
{
    public static class RoleExtensions
    {
        public static bool ProcessResult(IdentityResult result)
        {
            if (result.Succeeded)
            {
                return true;
            }
            else
            {
                string errorMessage = string.Join(" ", result.Errors.Select(e => e.Description));

                throw new BadRequestException(errorMessage);
            }
        }
    }
}
