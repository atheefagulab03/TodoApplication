
using Microsoft.AspNetCore.Mvc;
using Task1.DTO;
using Task1.Interface;
using Task1.Models;

namespace Task1.Controllers;

    [Route("/TodoApplication")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;

        public TaskController(ITaskService taskService, ILogger<TaskController> logger)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Todos>>> Get()
        {
            try
            {
                var emp = await _taskService.GetAll();
                return Ok(emp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all Todo items");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Todos>> insert(Todos todo)
        {
            try
            {
                var emp = await _taskService.CreateTask(todo);
                return Ok(emp);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid request for creating a Todo item");
                return BadRequest($"Invalid request: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating a Todo item");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Todos>> update(Guid id, Todos todo)
        {
            try
            {
                var emp = await _taskService.UpdateTask(id, todo);
                return Ok(emp);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, $"Invalid operation updating Todo item with ID {id}");
                return BadRequest($"Invalid operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating Todo item with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Todos>> delete(Guid id)
        {
            try
            {
                var emp = await _taskService.DeleteTask(id);
                return Ok(emp);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, $"Invalid operation deleting Todo item with ID {id}");
                return BadRequest($"Invalid operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting Todo item with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPut("/Status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Todos>> updateTaskStatus(Guid id, UpdateStatusDTO update)
        {
            try
            {
                var emp = await _taskService.UpdateStatus(id, update);
                return Ok(emp);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, $"Invalid operation updating status for Todo item with ID {id}");
                return BadRequest($"Invalid operation: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating status for Todo item with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Todos>>> Getid(Guid id)
        {
            try
            {
                var emp = await _taskService.Getbyid(id);
                return Ok(emp);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, $"Todo item with ID {id} not found");
                return NotFound($"Todo item with ID {id} not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving Todo item with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

    }

