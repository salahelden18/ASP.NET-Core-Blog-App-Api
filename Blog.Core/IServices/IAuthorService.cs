using Blog.Core.Models.Dtos.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    public interface IAuthorService
    {
        Task<bool> FollowAuthor(Guid authorId);
        Task<List<AllAuthorsResponseDto>> GetAllAuthors();
        Task<List<AllAuthorsResponseDto>> GetUserFollowedList();
        Task<List<AllAuthorsResponseDto>> GetUserFollowersList();
    }
}
