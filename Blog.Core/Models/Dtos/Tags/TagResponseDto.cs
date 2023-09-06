using Blog.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Dtos.Tags
{
    public class TagResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BlogPost>? BlogPosts { get; set; }
    }
}
