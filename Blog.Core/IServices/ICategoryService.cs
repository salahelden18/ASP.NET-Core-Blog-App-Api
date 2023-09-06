using Blog.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IServices
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllCategories();
        Task<CategoryResponseDto> CreateCategory(CategoryDto category);
        Task DeleteCategory(CategoryDto categoryDto);
        Task<CategoryResponseDto> UpdateCategory(int id, CategoryDto categoryDto);
    }
}
