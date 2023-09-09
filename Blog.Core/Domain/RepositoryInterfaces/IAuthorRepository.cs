using Blog.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        Task<Author?> CreateAuthor(Author author);
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetMe();
        Task<Author?> GetAuthorById(Guid id);
        Task<bool> FollowUser(Guid authorId);
        // Task<List<Author>> GetUserFollowerList();
    }
}
