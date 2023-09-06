using Blog.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Domain.RepositoryInterfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategory(Category category);
        Task<List<Category>> AllCategories();
        Task<Category?> GetCategoryByName(string categoryName);
        Task<Category> DeleteCategory(Category category);
        Task<Category?> UpdateCategory(int id, string newName);
    }
}
