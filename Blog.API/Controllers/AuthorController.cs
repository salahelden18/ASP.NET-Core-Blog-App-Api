using Blog.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorService _author;

        public AuthorController(ILogger<AuthorController> logger, IAuthorService author)
        {
            _author = author;
            _logger = logger;
        }

        [HttpPost]
        [Authorize(Roles = "Author")]
        [Route("follow")]
        public async Task<IActionResult> FollowAuthor(Guid authorId)
        {
            var result =  await _author.FollowAuthor(authorId);

            return Ok(result); 
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var result = await _author.GetAllAuthors();

            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Author")]
        [Route("followed")]
        public async Task<IActionResult> GetFollowedList()
        {
            var result = await _author.GetUserFollowedList();
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Author")]
        [Route("follower")]
        public async Task<IActionResult> GetFollowersList()
        {
            var result = await _author.GetUserFollowersList();
            return Ok(result);
        }
    }
}
