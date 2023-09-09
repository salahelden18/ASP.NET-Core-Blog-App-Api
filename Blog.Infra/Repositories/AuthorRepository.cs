using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.Services;
using Blog.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infra.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomApi _api;

        public AuthorRepository(ApplicationDbContext context, CustomApi api)
        {
            _context = context;
            _api = api;
        }

        public async Task<Author?> CreateAuthor(Author author)
        {
             var result = await _context.Authors.AddAsync(author);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Author?> GetAuthorById(Guid id)
        {
            var author = await _context.Authors
                .Include(x => x.User)
                .Where(x => x.User.Id == id).FirstOrDefaultAsync();

            return author;
        }

        public async Task<Author?> GetMe()
        {
            var author = await _context.Authors
                .Include(x => x.User)
                .Where(x => x.User.Id == Guid.Parse(_api.Id)).FirstOrDefaultAsync();

            return author;
        }

        public async Task<bool> FollowUser(Guid authorId)
        {
            var me = await GetMe();

            var author = await GetAuthorById(authorId);

            if (me == null || author == null)
            {
                return false;
            }

            // add the list if the list is null
            me.FollowedAuthors ??= new List<Author>();
            author.Followers ??= new List<Author>();

            // adding the author to followed author and add me to the followers of the author
            me.FollowedAuthors.Add(author);
            author.Followers.Add(me);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            var result = await _context.Authors
                .Include(x => x.User)
                .ToListAsync();

            return result;
        }
    }
}
