using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> AddBlog(BlogPost blog)
        {
            _context.BlogPosts.Add(blog);

            await _context.SaveChangesAsync();

            return blog;
        }
    }
}
