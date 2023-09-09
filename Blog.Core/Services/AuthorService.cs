using AutoMapper;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.IServices;
using Blog.Core.Models.Dtos.Author;
using Blog.Core.Models.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<bool> FollowAuthor(Guid authorId)
        {
            var followed = await _authorRepository.FollowUser(authorId);

            if(followed)
            {
                return true;
            }

            throw new NotFoundException("No Author With the Provided Id");
        }

        public async Task<List<AllAuthorsResponseDto>> GetAllAuthors()
        {
            var result = await _authorRepository.GetAllAuthors();

            return _mapper.Map<List<AllAuthorsResponseDto>>(result);
        }

        public async Task<List<AllAuthorsResponseDto>> GetUserFollowedList()
        {
            var author = await _authorRepository.GetMe();
            
            if(author?.FollowedAuthors == null)
            {
                return new List<AllAuthorsResponseDto>();
            }

            return _mapper.Map<List<AllAuthorsResponseDto>>(author.FollowedAuthors);
        }

        public async Task<List<AllAuthorsResponseDto>> GetUserFollowersList()
        {
            var author = await _authorRepository.GetMe();

            if (author?.Followers == null)
            {
                return new List<AllAuthorsResponseDto>();
            }

            return _mapper.Map<List<AllAuthorsResponseDto>>(author.Followers);
        }
    }
}
