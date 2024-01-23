using Microsoft.EntityFrameworkCore;
using Task1.DTO;
using Task1.Interface;
using Task1.Models;

namespace Task1.Repository
{
    public class TaskRepository : ITask
    {
        private readonly TodoContext _todoContext;

        public TaskRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }
        public async Task<Todos> CreateTask(Todos todo)
        {

            if (todo != null)
            {
                await _todoContext.Todos.AddAsync(todo);
                await _todoContext.SaveChangesAsync();
                return todo;
            }
            throw new ArgumentNullException(nameof(todo), "The Todo object cannot be null");
        }

        public async Task<Todos> DeleteTask(Guid id)
        {
            var delete = await _todoContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (delete != null)
            {
                _todoContext.Remove(delete);
                await _todoContext.SaveChangesAsync();
                return delete;
            }
            throw new InvalidOperationException($"Todo item with ID {id} not found for deletion");

        }

        public async Task<Todos> Getbyid(Guid id)
        {
            var todo = await _todoContext.Todos.FindAsync(id);
            if (todo != null)
            {
                return todo;
            }
            throw new KeyNotFoundException($"Todo item with ID {id} not found");

        }

        public async Task<IEnumerable <Todos>> GetAll()
        {
            var result = await _todoContext.Todos.ToListAsync();
            return result;

        }

        public async Task<Todos> UpdateTask(Guid id, Todos todo)
        {
            var existingTodo = await _todoContext.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTodo != null && existingTodo.TaskStatus != "Completed")
            {

                existingTodo.TaskName = todo.TaskName;
                existingTodo.TaskStatus = todo.TaskStatus;
                existingTodo.Note = todo.Note;
                existingTodo.PriorityFlag = todo.PriorityFlag;
                existingTodo.Due = todo.Due;

                await _todoContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Todo item not found or cannot be updated");
            }
            return existingTodo;




        }

        public async Task<Todos> UpdateStatus(Guid id, UpdateStatusDTO statusDTO)
        {
            var existingTodo = await _todoContext.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTodo != null)
            {
                existingTodo.TaskStatus = statusDTO.TaskStatus;
                await _todoContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Todo item not found ");
            }
            return existingTodo;
        }
        
    }
}
