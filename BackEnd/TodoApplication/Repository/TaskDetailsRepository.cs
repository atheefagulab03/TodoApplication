using Microsoft.EntityFrameworkCore;
using TodoApplication.Dto;
using TodoApplication.Interface;
using TodoApplication.Models;

namespace TodoApplication.Repository
{
    public class TaskDetailsRepository(TaskContext taskContext) : ITaskDetails
    {
        private readonly TaskContext taskContext = taskContext;

        public async Task<TaskDetail> CreateTaskDetailsAsync(TaskDetail taskDetail)
        {
            if (taskDetail != null)
            {
                await taskContext.TaskDetails.AddAsync(taskDetail);
                await taskContext.SaveChangesAsync();
                return taskDetail;
            }
            throw new ArgumentNullException("The Todo object cannot be null");
        }

        public async Task<TaskDetail> DeleteTaskDetailsAsync(int id)
        {
            var delete = await taskContext.TaskDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (delete != null)
            {
                taskContext.Remove(delete);
                await taskContext.SaveChangesAsync();
                return delete;
            }
            throw new KeyNotFoundException($"Todo item with ID {id} not found for deletion");
        }

        public async Task<IEnumerable<TaskDetail>> GetTaskDetailsAsync()
        {
            return await taskContext.TaskDetails.ToListAsync();
        }

        public async Task<List<TaskDetail>> GetTaskDetailsByUserIdAsync(int userId)
        {
            var result = await taskContext.TaskDetails.Where(x => x.UserId == userId).ToListAsync();
            if (result != null)
            {
                return result;
            }
            throw new KeyNotFoundException("The UserId Does not have any Task");

        }

        public async Task<TaskDetail> UpdateStatusTaskDetailAsync(int id, UpdateStatusDto statusDTO)
        {
            var existingTodo = await taskContext.TaskDetails.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTodo != null)
            {
                existingTodo.TaskStatus = statusDTO.TaskStatus;
                await taskContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Todo item not found ");
            }
            return existingTodo;


        }

        public async Task<TaskDetail> UpdateTaskDetailsAsync(int id, TaskDetail taskDetail)
        {
            var existingTodo = await taskContext.TaskDetails.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTodo != null && existingTodo.TaskStatus != "Completed")
            {

                 taskContext.Update(taskDetail);

                await taskContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Todo item not found or cannot be updated");
            }
            return existingTodo;
        }
    }
}
