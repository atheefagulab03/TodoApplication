using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Dto;
using TodoApplication.Interface;
using TodoApplication.Models;


namespace TodoApplication.Controllers;

[Authorize]
[Route("/api/v1/[Controller]")]
[ApiController]
public class TaskDetailsController(ITaskDetailsService taskService) : ControllerBase
{
    private readonly ITaskDetailsService taskService = taskService;


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<TaskDetail>>> Get()
    {
         var emp = await taskService.GetTaskDetailsAsync();
            return Ok(emp);
        
    }



    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TaskDetail>> Insert(TaskDetail taskDetail)
    {
        
            var emp = await taskService.CreateTaskDetailsAsync(taskDetail);
            return Ok(emp);

        
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TaskDetail>> Update(int id, TaskDetail todo)
    {
        
            var emp = await taskService.UpdateTaskDetailsAsync(id, todo);
            return Ok(emp);
        
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TaskDetail>> Delete(int id)
    {
        
            var emp = await taskService.DeleteTaskDetailsAsync(id);
            return Ok(emp);
        
    }

    [HttpPut("/{StatusUpdate}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TaskDetail>> updateTaskStatus(int id, UpdateStatusDto update)
    {
        
            var emp = await taskService.UpdateStatusTaskDetailAsync(id, update);
            return Ok(emp);

      
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<TaskDetail>>> Getbyid(int userId)
    {
        
            var emp = await taskService.GetTaskDetailsByUserIdAsync(userId);
            return Ok(emp);
       
    }

}


