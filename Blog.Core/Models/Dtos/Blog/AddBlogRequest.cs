using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Models.Dtos.Blog
{
    public class AddBlogRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public IFormFile BlogImage { get; set; }
    }
}
