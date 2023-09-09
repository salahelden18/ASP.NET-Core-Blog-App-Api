using Blog.Core.IServices;
using Blog.Core.Models.Dtos.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogPostService _blogService;

        public BlogController(IBlogPostService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> CreateBlog([FromForm] AddBlogRequest blog)
        {
            var result = await _blogService.AddBlog(blog);

            return Ok(result);

        }
    }
}
