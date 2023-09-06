using Blog.Core.Domain.Entities;
using Blog.Core.Models.Dtos.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.RepositoryInterfaces
{
    public interface ITagRepository
    {
        Task<List<Tags>> GetAllTags();
        Task<Tags?> GetTagByName(string name);
        Task<Tags?> GetTagById(int id);
        Task<Tags> CreateTag(Tags tag);
        Task<Tags?> UpdateTag(int id, Tags tag);
        Task<Tags?> DeleteTag(int id);
    }
}
