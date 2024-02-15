using Microsoft.AspNetCore.Mvc;
using TodoApplication.Authentication;
using TodoApplication.Dto;
using TodoApplication.Interface;
using TodoApplication.Models;

namespace TodoApplication.Controllers;

[Route("/api/v1/[Controller]")]
[ApiController]
public class UserDetailsController(IUserDetailsService userDetailsService, ITokenGeneration tokenGeneration) : ControllerBase
{
    private readonly IUserDetailsService userDetailsService = userDetailsService;

    private readonly ITokenGeneration tokenGeneration = tokenGeneration;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
    {
        var result = await userDetailsService.GetUserDetailsAsync();
        return Ok(result);
    }

    [HttpPost("Register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> UserRegister(User user)
    {
        var result = await userDetailsService.UserRegisterAsync(user);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<User>> GetUserDeatilsByUserId(int id)
    {
        var emp = await userDetailsService.GetUserDetailsByUserIdAsync(id);
        return Ok(emp);
    }

    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<User>> UserLogin(UserLoginDto user)
    {
        var result = await userDetailsService.LoginUserDetailsAsync(user);
        var token = tokenGeneration.GenerateToken(result);
        return Ok(token);

    }
}
