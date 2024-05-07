using MediatR;
using MedPro.Application.Commands.User.CreateUser;
using MedPro.Application.Commands.User.DeleteUser;
using MedPro.Application.Commands.User.LoginUser;
using MedPro.Application.Commands.User.UpdateUser;
using MedPro.Application.Queries.User.GetUserById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedPro.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var user = await _mediator.Send(query);
        return Ok(user);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteUserCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(Post), new { id = id });
    }
    
    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var userViewModel = await _mediator.Send(command);
        
        if (userViewModel == null)
        {
            return Unauthorized();
        }
        
        return Ok(userViewModel);
    } 
}