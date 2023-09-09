using Blog.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.RepositoryInterfaces
{
    public interface IBlogPostRepository
    {
        Task<BlogPost> AddBlog(BlogPost blog);
    }
}
