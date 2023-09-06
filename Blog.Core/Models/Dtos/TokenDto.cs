using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Dtos
{
    public class TokenDto
    {
        public string JwtToken { get; set; }
        public DateTime ExpiresIn { get; set; }
        public string Role { get; set; }
    }
}
