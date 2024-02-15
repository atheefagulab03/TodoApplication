using TodoApplication.Models;

namespace TodoApplication.Interface
{
    public interface ICategoryDetailsService
    {
         Task<IEnumerable<Category>> GetCategoryDetailsAsync();

         Task<List<Category>> GetCategoryDetailsByUserIdAsync(int userId);

         Task<Category> CreateCategoryAsync(Category category);

         Task<Category> UpdateCategoryAsync(int id, Category category);

         Task<Category> DeleteCategoryByCategoryIdAsync(int id);
    }
}
