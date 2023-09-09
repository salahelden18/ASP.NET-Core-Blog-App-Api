using Blog.Core.Models.Errors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Helpers
{
    public static class HelpersValidators
    {
        public static void ValidateFileUpload(IFormFile image)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(image.FileName)))
            {
                throw new BadRequestException("Unsupported File Extensions");
            }

            // 10 MB
            if (image.Length > 10485760)
            {
                throw new BadRequestException("File Size more than 10MB please upload a smaller file size.");
            }
        }
    }
}
