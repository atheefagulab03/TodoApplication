using Microsoft.EntityFrameworkCore;
using TodoApplication.Interface;
using TodoApplication.Models;

namespace TodoApplication.Repository
{
    public class CategoryDetailsRepository(TaskContext taskContext , ILogger<CategoryDetailsRepository> logger) : ICategoryDetails
    {
        private readonly TaskContext taskContext = taskContext;
        private readonly ILogger<CategoryDetailsRepository> logger =logger;



        public async Task<Category> CreateCategoryAsync(Category category)
        {
            if (category != null)
            {
                await taskContext.Categories.AddAsync(category);
                await taskContext.SaveChangesAsync();
                return category;
                
            }


            throw new ArgumentNullException("The Category object cannot be null");

        }

        public async Task<Category> DeleteCategoryByCategoryIdAsync(int id)
        {
            var delete = await taskContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (delete != null)
            {
                taskContext.Remove(delete);
                await taskContext.SaveChangesAsync();
                return delete;
            }
            throw new KeyNotFoundException($"Task item with CategoryId {id} not found for deletion");


        }

        public async Task<IEnumerable<Category>> GetCategoryDetailsAsync()
        {
            var result = await taskContext.Categories.ToListAsync();
            return result;

            //remove
        }

        public async Task<List<Category>> GetCategoryDetailsByUserIdAsync(int userId)
        {


            var result = await taskContext.Categories.Where(x => x.UserId == userId).ToListAsync();

            if (result != null)
            {
                return result;
            }



            throw new KeyNotFoundException($"No categories found for user with ID {userId}");
        }

        public async Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            var existingCategory = await taskContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCategory != null)
            {

                taskContext.Update(category);

                await taskContext.SaveChangesAsync();

                return existingCategory;
            }

            throw new InvalidOperationException("category item not found To Be Updated");


        }
    }
}
