using TodoApplication.Interface;
using TodoApplication.Models;

namespace TodoApplication.Repository
{
    public class CategoryDetailsService(ICategoryDetails categoryDetails) : ICategoryDetailsService
    {
        private readonly ICategoryDetails categoryDetails = categoryDetails;

        public async Task<Category> CreateCategoryAsync(Category category)
        {
           return await categoryDetails.CreateCategoryAsync(category);
            
        }

        public async Task<Category> DeleteCategoryByCategoryIdAsync(int id)
        {
            return await categoryDetails.DeleteCategoryByCategoryIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoryDetailsAsync()
        {
            return await categoryDetails.GetCategoryDetailsAsync();
        }


        public async Task<List<Category>> GetCategoryDetailsByUserIdAsync(int userId)
        {
            return await categoryDetails.GetCategoryDetailsByUserIdAsync(userId);
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            return await categoryDetails.UpdateCategoryAsync(id, category);
        }
    }
}
