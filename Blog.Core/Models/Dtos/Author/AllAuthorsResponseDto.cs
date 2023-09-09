using Blog.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Dtos.Author
{
    public class AllAuthorsResponseDto
    {
        public int Id { get; set; }
        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Email { get; set; }

    }
}


