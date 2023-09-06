using Blog.Core.Domain.Entities;
using Blog.Core.Domain.RepositoryInterfaces;
using Blog.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> AllCategories()
        {
            var categories = await _context.Categories.ToListAsync();

            return categories;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            var returnedCategory = await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return returnedCategory.Entity;
        }

        public async Task<Category> DeleteCategory(Category category)
        {
            var result = _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Category?> GetCategoryByName(string categoryName)
        {
            var category = await _context.Categories.Where(x => x.Name.ToLower() == categoryName.ToLower()).FirstOrDefaultAsync();
            
            return category;
        }

        public async Task<Category?> UpdateCategory(int id, string newName)
        {
            var extractedCategory = await _context.Categories.FindAsync(id);
            
            if(extractedCategory != null)
            {
                extractedCategory.Name = newName;
                await _context.SaveChangesAsync();
            }
            
            return extractedCategory;
        }
    }
}
