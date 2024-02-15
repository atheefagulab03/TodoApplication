using TodoApplication.Dto;
using TodoApplication.Models;

namespace TodoApplication.Interface
{
    public interface ITaskDetailsService
    {
        Task<IEnumerable<TaskDetail>> GetTaskDetailsAsync();

        Task<List<TaskDetail>> GetTaskDetailsByUserIdAsync(int userId);

        Task<TaskDetail> CreateTaskDetailsAsync(TaskDetail taskDetail);

        Task<TaskDetail> UpdateTaskDetailsAsync(int id, TaskDetail taskDetail);

        Task<TaskDetail> DeleteTaskDetailsAsync(int id);

        Task<TaskDetail> UpdateStatusTaskDetailAsync(int id, UpdateStatusDto statusDTO);
    }
}
