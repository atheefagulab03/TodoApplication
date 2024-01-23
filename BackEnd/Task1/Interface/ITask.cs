using Task1.DTO;
using Task1.Models;

namespace Task1.Interface
{
    public interface ITask
    {
        public Task<IEnumerable<Todos>> GetAll();

        public Task<Todos> Getbyid(Guid id);

        public Task<Todos> CreateTask(Todos todo);

        public Task<Todos> UpdateTask(Guid id,Todos todo);

        public Task<Todos> DeleteTask(Guid id);

        public Task<Todos> UpdateStatus(Guid id, UpdateStatusDTO statusDTO);
    }
}