using TodoApplication.Dto;
using TodoApplication.Interface;
using TodoApplication.Models;

namespace TodoApplication.Repository
{
    public class TaskDetailsService(ITaskDetails taskDetails) : ITaskDetailsService
    {
        private readonly ITaskDetails taskDetails = taskDetails;

        public async Task<TaskDetail> CreateTaskDetailsAsync(TaskDetail taskDetail)
        {
            return await taskDetails.CreateTaskDetailsAsync(taskDetail);
        }

        public async Task<TaskDetail> DeleteTaskDetailsAsync(int id)
        {
            return await taskDetails.DeleteTaskDetailsAsync(id);
        }

        public async Task<IEnumerable<TaskDetail>> GetTaskDetailsAsync()
        {
            return await taskDetails.GetTaskDetailsAsync();
        }

        public async Task<List<TaskDetail>> GetTaskDetailsByUserIdAsync(int userId)
        {
            return await taskDetails.GetTaskDetailsByUserIdAsync(userId);
        }

        public async Task<TaskDetail> UpdateStatusTaskDetailAsync(int id, UpdateStatusDto statusDTO)
        {
            return await taskDetails.UpdateStatusTaskDetailAsync(id, statusDTO);
        }

        public async Task<TaskDetail> UpdateTaskDetailsAsync(int id, TaskDetail taskDetail)
        {
            return await taskDetails.UpdateTaskDetailsAsync(id, taskDetail);
        }
    }
}
