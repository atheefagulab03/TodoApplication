using Task1.DTO;
using Task1.Interface;
using Task1.Models;

namespace Task1.Repository
{
    public class TaskService : ITaskService
    {
        private readonly ITask _taskRepository;

        public TaskService(ITask taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<Todos> CreateTask(Todos todo)
        {
            try
            {
                return await _taskRepository.CreateTask(todo);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentException("Invalid Todo object", ex);
            }
        }

        public async Task<Todos> DeleteTask(Guid id)
        {
            try
            {
                return await _taskRepository.DeleteTask(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException($"Error deleting Todo item: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Todos>> GetAll()
        {
            return await _taskRepository.GetAll();
        }

        public async Task<Todos> Getbyid(Guid id)
        {
            try
            {
                return await _taskRepository.Getbyid(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new ApplicationException($"Todo item with ID {id} not found", ex);
            }
        }

        public async Task<Todos> UpdateStatus(Guid id, UpdateStatusDTO statusDTO)
        {
            try
            {
                return await _taskRepository.UpdateStatus(id, statusDTO);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException($"Error updating status: {ex.Message}", ex);
            }

        }

        public async Task<Todos> UpdateTask(Guid id, Todos todo)
        {
            try
            {
                return await _taskRepository.UpdateTask(id, todo);
            }
            catch (InvalidOperationException ex)
            {
                throw new ApplicationException($"Error updating Todo item: {ex.Message}", ex);
            }
        }
    }
}
