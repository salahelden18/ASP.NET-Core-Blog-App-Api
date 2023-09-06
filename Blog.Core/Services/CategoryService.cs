using AutoMapper;
using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Core.IServices;
using Blog.Core.Models.Dtos;
using Blog.Core.Models.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryResponseDto> CreateCategory(CategoryDto categorydto)
        {
            var isCategoryExist = await _categoryRepository.GetCategoryByName(categorydto.Name);

            if(isCategoryExist == null)
            {
                var domainCategory = _mapper.Map<Category>(categorydto);

                domainCategory = await _categoryRepository.CreateCategory(domainCategory);

                return _mapper.Map<CategoryResponseDto>(domainCategory);
            }
            else
            {
                throw new BadRequestException("Category Already Exist");
            }
            
        }

        public async Task<List<CategoryResponseDto>> GetAllCategories()
        {
            List<Category> domainCategories = await _categoryRepository.AllCategories();

            var modelCategory = _mapper.Map<List<CategoryResponseDto>>(domainCategories);

            return modelCategory;
        }

        public async Task DeleteCategory(CategoryDto categoryDto)
        {

            var domainCategory = await _categoryRepository.GetCategoryByName(categoryDto.Name);

            if (domainCategory == null)
            {
                throw new NotFoundException("No Category With the Provided Credentials");
            }

            _ = await _categoryRepository.DeleteCategory(domainCategory) ?? throw new BadRequestException("No Category With the provided Data Exist");
        }

        public async Task<CategoryResponseDto> UpdateCategory(int id, CategoryDto categoryDto)
        {
            var domainResult = await _categoryRepository.UpdateCategory(id, categoryDto.Name);

            if(domainResult == null)
            {
                throw new NotFoundException("No Category With the Provided id");
            }
            else
            {
                // map tp categoryResponse
                return _mapper.Map<CategoryResponseDto>(domainResult);
            }
        }
    }
}
