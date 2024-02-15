using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Interface;
using TodoApplication.Models;

namespace TodoApplication.Controllers;
[Authorize]
[Route("/api/v1/[Controller]")]
[ApiController]
public class CategoryDetailsController(ICategoryDetailsService categoryService) : ControllerBase
{
    private readonly ICategoryDetailsService categoryService = categoryService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoryDetails()
    {
        
            var emp = await categoryService.GetCategoryDetailsAsync();
            return Ok(emp);
          
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<Category>>> GetUserIdCategoryDetails(int userId)
    {
       var emp = await categoryService.GetCategoryDetailsByUserIdAsync(userId);
            return Ok(emp);
        

    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult<Category>> InsertCategoryDetails(Category category)
    {
        
            var emp = await categoryService.CreateCategoryAsync(category);
            return Ok(emp);
        
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public async Task<ActionResult<Category>> UpdateCategoryDetails(int id, Category category)
    {
        
            var emp = await categoryService.UpdateCategoryAsync(id, category);
            return Ok(emp);
        
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Category>> DeleteCategoryByCategoryId(int id)
    {
       
            var emp = await categoryService.DeleteCategoryByCategoryIdAsync(id);
            return Ok(emp);
        
    }
}
