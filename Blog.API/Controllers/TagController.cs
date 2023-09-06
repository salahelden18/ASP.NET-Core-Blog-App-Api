using Blog.Core.IServices;
using Blog.Core.Models.Dtos.Tags;
using Blog.Core.Models.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag(TagRequestDto tagRequestDto)
        {
            var result = await _tagService.CreateTag(tagRequestDto);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var result = await _tagService.GetAllTags();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagById([FromRoute] int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Invalid Id, Id sould be greater than 0");
            }

            var result = await _tagService.GetTagById(id);

            return Ok(result);
        }

        [HttpGet("ByName/{name}")]
        public async Task<IActionResult> GetTagByName([FromRoute] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("Please Enter Valid Name");
            }

            var result = await _tagService.GetTagByName(name);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTag([FromRoute] int id)
        {
            if(id <= 0)
            {
                throw new BadRequestException("Please Enter Valid Id");
            }

            await _tagService.DeleteTag(id);

            return NoContent();
        }


        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTag([FromRoute] int id, TagRequestDto tagRequestDto)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Please Enter Valid Id");
            }

            var result = await _tagService.UpdateTag(id, tagRequestDto);

            return Ok(result);
        }
    }
}
