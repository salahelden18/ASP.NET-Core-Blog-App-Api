using Blog.Core.Models.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    public interface ITagService
    {
        Task<List<TagResponseDto>> GetAllTags();
        Task<TagResponseDto> GetTagById(int id);
        Task<TagResponseDto> GetTagByName(string name);
        Task<TagResponseDto> CreateTag(TagRequestDto tagRequestDto);
        Task<TagResponseDto> UpdateTag(int id, TagRequestDto tagRequestDto);
        Task DeleteTag(int id);
    }
}
