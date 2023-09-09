using Blog.Core.Models.Dtos.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    public interface IBlogPostService
    {
        Task<BlogResponse> AddBlog(AddBlogRequest blog);
    }
}
