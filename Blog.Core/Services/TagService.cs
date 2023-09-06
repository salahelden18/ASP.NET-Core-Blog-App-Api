using AutoMapper;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.IServices;
using Blog.Core.Models.Dtos.Tags;
using Blog.Core.Models.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagResponseDto> CreateTag(TagRequestDto tagRequestDto)
        {
            var domainModel = _mapper.Map<Tags>(tagRequestDto);

            domainModel = await _tagRepository.CreateTag(domainModel);

            return _mapper.Map<TagResponseDto>(domainModel);
        }

        public async Task<List<TagResponseDto>> GetAllTags()
        {
            var domainModel = await _tagRepository.GetAllTags();

            return _mapper.Map<List<TagResponseDto>>(domainModel);
        }

        public async Task<TagResponseDto> GetTagById(int id)
        {
            var domainModel = await _tagRepository.GetTagById(id) ?? throw new NotFoundException("No Tag With The Provided Id");

            return _mapper.Map<TagResponseDto>(domainModel);
        }

        public async Task<TagResponseDto> GetTagByName(string name)
        {
            var domainModel = await _tagRepository.GetTagByName(name) ?? throw new NotFoundException("No Tag With The Provided Name");

            return _mapper.Map<TagResponseDto>(domainModel);
        }

        public async Task DeleteTag(int id)
        {
            _ = await _tagRepository.DeleteTag(id) ?? throw new NotFoundException("No Tag With The Provided Id");
        }

        public async Task<TagResponseDto> UpdateTag(int id, TagRequestDto tagRequestDto)
        {
            var domainModel = _mapper.Map<Tags>(tagRequestDto);

            domainModel = await _tagRepository.UpdateTag(id, domainModel) ?? throw new NotFoundException("No Tag With The Provided Id");

            return _mapper.Map<TagResponseDto>(domainModel);
        }
    }
}
