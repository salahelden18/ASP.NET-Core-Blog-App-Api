using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tags> CreateTag(Tags tag)
        {
            var createdTag = await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();

            return createdTag.Entity;
        }

        public async Task<Tags?> DeleteTag(int id)
        {
            var tagExist = await GetTagById(id);

            if (tagExist != null)
            {
                _context.Tags.Remove(tagExist);
                await _context.SaveChangesAsync();
            }

            return tagExist;
        }

        public async Task<List<Tags>> GetAllTags()
        {
            var tags = await _context.Tags.ToListAsync();

            return tags;
        }

        public async Task<Tags?> GetTagById(int id)
        {
            var tag = await _context.Tags.SingleOrDefaultAsync(x => x.Id == id);

            return tag;
        }

        public async Task<Tags?> GetTagByName(string name)
        {
            var tag = await _context.Tags.SingleOrDefaultAsync(x => x.Name == name);

            return tag;
        }

        public async Task<Tags?> UpdateTag(int id, Tags tag)
        {
            var fetchedTag = await GetTagById(id);

            if(fetchedTag != null)
            {
                fetchedTag.Name = tag.Name;
                await _context.SaveChangesAsync();
            }

            return fetchedTag;
            
        }
    }
}
